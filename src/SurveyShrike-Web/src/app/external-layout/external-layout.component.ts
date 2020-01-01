import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services';
import { Helper } from '../_services/helper.service';
import { Menu } from '../_models/menu';

const screenfull = require('screenfull');

@Component({
    selector: 'external-layout',
    templateUrl: './external-layout.html',
    styleUrls: ['./external-layout.scss']
})
export class ExternalLayoutComponent implements OnInit {
    public customizerIn = false;
    public loading = false;
    public menus = Array<Menu>();
    constructor(
        private _route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private authService: AuthService,
        private helper: Helper
    ) {
    }

    ngOnInit() {
        this.getHomeMenus();
    }

    public onActivate(e, scrollContainer) {
        scrollContainer.scrollTop = 0;
    }

    private getHomeMenus() {

        this.menus = [
            {
                systemName: 'LOGIN_REGISTER',
                selected: false,
                title: 'Login/Register',
                url: 'login',
                type: 'link',
                childNodes: Array<Menu>(),
                icon: 'account_circle',
                permissions: null,
                isHidden: false
            }, {
                systemName: 'DASHBOARD',
                title: 'Gaurav',
                url: 'dashboard',
                type: 'link',
                icon: 'account_circle',
                permissions: null,
                childNodes: Array<Menu>(),
                selected: false,
                isHidden: false
            }  , {
                'systemName': 'LOGOUT',
                'title': 'Logout',
                'url': 'logout',
                'type': 'link',
                childNodes: Array<Menu>(),
                'icon': 'power_settings_new',
                'permissions': 'view',
                selected: false,
                isHidden: false
            }];
            this.setUserMenus();
    }

    private setUserMenus() {
        if (this.authService.isLoggedIn()) {
            this.menus.forEach(menu => {
                if (menu.systemName.toLowerCase() === 'login_register') {
                    menu.isHidden = true;
                } else if (menu.systemName.toLowerCase() === 'dashboard') {
                    menu.title = this.helper.getUserName();
                }
            });
        } else {
            this.menus.forEach(menu => {
                if (menu.systemName.toLowerCase() === 'dashboard' || menu.systemName.toLowerCase() === 'logout') {
                    menu.isHidden = true;
                } else {
                    menu.isHidden = false;
                }
            });
        }
        // return menus;
    }
 
    public customizerFunction() {
        this.customizerIn = !this.customizerIn;
    }

    public redirectTo(url: string) {
        if (url.toLowerCase().indexOf('logout') >= 0) {
            this.logout();
        } else {
            const redirectUrl = '/' + url;
            this.router.navigate([redirectUrl]);
        }
        this.setUserMenus();
    }

    public sideNavClick(url: string) {
        this.redirectTo(url);
        this.customizerFunction();
    }

    private logout() {
        localStorage.clear();
        this.router.navigate(['/login']);
        // this.userService.logOut()
        // .subscribe((data) => {
        //     this.router.navigate(['/login']);
        // },
        // error => {
        //     this.toastr.errorObj(error, 'Oops!');
        // });
    }
}
