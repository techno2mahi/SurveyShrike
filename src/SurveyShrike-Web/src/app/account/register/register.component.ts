import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../_services/auth.service';
import { SnackToastService } from '../../_services/snackToast.service';
import { UserService } from '../../_services/user.service';
import { AccountView } from '../../shared/constant';
import { Helper } from '../../_services/helper.service';

@Component({
    selector: 'register',
    styleUrls: ['../account.component.scss'],
    templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
    public model: any = {};
    public loading = false;
    public currentView = AccountView.Default;
    public viewtype = AccountView;
    private registration = {
        userName: '',
        mobileNo: '',
        name: '',
        email: '',
        password: '',
        confirmPassword: ''
    };

    constructor(
        private _helper: Helper,
        private _userService: UserService,
        private toastr: SnackToastService,
        private _authService: AuthService) { }

    ngOnInit() {
        // reset login status
        this.logOut();
    }

    public logOut() {
        localStorage.clear();
        // this._userService.logOut()
        // .subscribe((data) => {
        //     this.loading = false;
        // },
        // error => {
        //     this.toastr.errorObj(error, 'Oops!');
        //     this.loading = false
        // });
    }

    public register() {
        this._helper.showAppLoader.emit(true);
        this.getRegistrationdata();
        this._authService.register(this.registration)
            .subscribe(
            data => {
                this.toastr.success('Registered Successfully.');
                this._helper.showAppLoader.emit(false);
                this.currentView = AccountView.Default;
            },
            error => {
                const errorDetails = this._helper.getErrorDetails(error);
                this.toastr.error(errorDetails.message);
                this._helper.showAppLoader.emit(false);
            });
    }

    private getRegistrationdata() {
        this.registration.email = this.model.email;
        this.registration.password = this.model.password;
        this.registration.name = this.model.name;
        this.registration.mobileNo = this.model.mobileNo;
    }
}
