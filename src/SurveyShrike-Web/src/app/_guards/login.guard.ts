import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { Observable , of,  Subject } from 'rxjs';

@Injectable()
export class LoggedInUserAuthGuard implements CanActivate {

    constructor(private _authService: AuthService,
        private _router: Router) { }

    public canActivate(): Observable<boolean> {
        return this.isAllowedAccess();
    }

    private isAllowedAccess(): Observable<boolean> {
        if (!this._authService.isLoggedIn()) {
            this._router.navigate(['/login']);
            return of(false);
        }
        return of(true);
    }
}
