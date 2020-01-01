import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../_services/auth.service';
import { UserService } from '../../_services/user.service';
import { Helper } from '../../_services/helper.service';
import { SnackToastService } from '../../_services/snackToast.service';
import { AccountView,  AppSettings, ValidationConstants, AppURLs } from '../../shared/constant';
 

@Component({
    selector: 'login',
    styleUrls: ['../account.component.scss'],
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    public model: any = {};
    public loading = false;
    public currentView = AccountView.Default;
    public viewtype = AccountView;
    public sendOTP = false;
    public loginType: any;
    public extAccessToken = '';
    public extuserId = '';

    constructor(
        private _router: Router,
        private _helper: Helper,
        private _authService: AuthService,
        private _userService: UserService,
        private toastr: SnackToastService
    ) {
        
    }

    ngOnInit() {
        if (this._authService.isLoggedIn()) {
            this._router.navigate(['/']);
         }
        this.model.username = 'admin@gmail.com';
        this.model.password = 'password';
    }

    public logOut() {
        localStorage.clear();
    }

    login() {
        this._helper.showAppLoader.emit(true);
        this._authService.login(this.model.username, this.model.password)
            .subscribe(
                data => {
                    this._helper.showAppLoader.emit(false);
                    this._router.navigate([AppURLs.dashboard]);
                },
                error => {
                    const errorDetails = this._helper.getErrorDetails(error);
                    if (errorDetails.error && errorDetails.error.toLowerCase() === ValidationConstants.PhoneNotConfirmed) {
                        this.sendOTP = true;
                    } else {
                        this.toastr.error(errorDetails.message);
                    }
                    this._helper.showAppLoader.emit(false);
                });
    }
   
 
   
}

