import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AppSettings, LocalStorageKeys } from '../shared/constant';
import { Helper } from './helper.service';
import { ValidationService } from './validation.service';

export interface AuthToken {
    token: string;
}

@Injectable()
export class AuthService {
    private _token: AuthToken;

    constructor(
        private _http: HttpClient,
        private validationService: ValidationService,
        private helper: Helper) { }

    private get token(): AuthToken {
        return this._token;
    }

    public getToken() {
        return this.helper.getObjectFromLocalStorage(LocalStorageKeys.AuthToken);
    }

    public login(username: string, password: string): Observable<any> {
        const url: string = AppSettings.API_Login;
        const headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
        const data = 'grant_type=password&username=' + username + '&password=' + password;
        return this._http.post<any>(url, data, { headers: headers })
            .catch((error) => {
                return this.handleError(error);
            })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                const user = response;
                this.setUserDataLocally(user);
            });
    }
    
    public register(newUserData: any): Observable<any> {
        const url: string = AppSettings.API_Register;
        const headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this._http.post<any>(url, newUserData, { headers: headers })
            .catch((error) => {
                return this.handleError(error);
            })
    }

    public isLoggedIn(): boolean {
        let isLoogedIn = false;
        const authToken = this.getToken();
        if (authToken) {
            isLoogedIn = true;
        }
        return isLoogedIn;
    }
 
    private handleError(errorRes: any) {
        this.validationService.handleError(errorRes)
        // return Observable.throw((errorRes.error && (errorRes.error.message
        //     || errorRes.error.errorMessage || errorRes.error.error_description)) || 'Server error');
        return Observable.throw(errorRes);
    }

    private setUserDataLocally(user: any) {
        if (user && user.access_token) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            this.helper.setObjectInLocalStorage(LocalStorageKeys.User, user);
            this.helper.setObjectInLocalStorage(LocalStorageKeys.AuthToken, user.access_token);
        }
    }
}
