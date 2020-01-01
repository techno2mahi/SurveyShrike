import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AppSettings, LocalStorageKeys } from '../shared/constant';
import { Helper } from './helper.service';
import { CustomHttpSevice } from './custom.http.service';
import { ValidationService } from './validation.service';
import { UserProfile, IVerifyUser } from '../_models/user';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {
    constructor(
        private helper: Helper,
        private validationService: ValidationService,
        private _http: CustomHttpSevice) { }

    public getUser(): Observable<UserProfile> {
        const url: string = AppSettings.API_GetUser;
        return this._http.get<UserProfile>(url);
    }
 
    public logOut() {
        const url: string = AppSettings.API_LogOut;
        const headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
        const authToken = this.getToken();
        if (authToken) {
            headers.append('Authorization', 'Bearer ' + authToken);
            return this._http.post<any>(url, null, { headers: headers })
            .map((res) => {
                return res;
            });
        }
    }
   
    public getToken() {
        return this.helper.getObjectFromLocalStorage(LocalStorageKeys.AuthToken);
    }
}
