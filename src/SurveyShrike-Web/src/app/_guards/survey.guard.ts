import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { Observable , of,  Subject } from 'rxjs';
import { Helper } from 'app/_services/helper.service';
import { SnackToastService } from 'app/_services/snackToast.service';

@Injectable()
export class SurveyAuthGuard implements CanActivate {

    constructor(private _helper: Helper,
        private toastr: SnackToastService,
        private _router: Router) { }

    public canActivate(): Observable<boolean> {
        return this.isAllowedAccess();
    }

    private isAllowedAccess(): Observable<boolean> {
        const survey = this._helper.getSurveyFromLocalStorage();
        if (!survey) {
            this.toastr.warning('Please select survey');
            this._router.navigate(['/dashboard']);
            return of(false);
        }
        return of(true);
    }
}
