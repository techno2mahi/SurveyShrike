import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AuthService } from './auth.service';
import { ValidationService } from './validation.service';
import { RequestOption } from '../_models/common';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Messages } from '../shared/constant';

@Injectable()
export class CustomHttpSevice {
    private http: HttpClient;
    constructor(http: HttpClient,
        private _authService: AuthService,
        private validationService: ValidationService
    ) {
        this.http = http;
    }

    public get<T>(url: string, options?: RequestOption): Observable<T> {
    
            return this.http.get(url, this.getRequestOptionArgs(options)).catch((error) => {
                return this.handleError(error);
            });
       
    }

    public post<T>(url: string, body: any, options?: RequestOption): Observable<T> {
       
            return this.http.post(url, body, this.getRequestOptionArgs(options)).catch((error) => {
                return this.handleError(error);
            });
        
    }

    public put<T>(url: string, body: any, options?: RequestOption): Observable<T> {
      
            return this.http.put(url, body, this.getRequestOptionArgs(options)).catch((error) => {
                return this.handleError(error);
            });
       
    }

    public delete<T>(url: string, options?: RequestOption): Observable<T> {
       
            return this.http.delete(url, this.getRequestOptionArgs(options)).catch((error) => {
                return this.handleError(error);
            });
        
    }

    private getRequestOptionArgs(options?: RequestOption): RequestOption {
        if (typeof options === 'undefined' || options === null) {
            options = new RequestOption();
        }
        if (typeof options.headers === 'undefined' || options.headers === null) {
            options.headers = new HttpHeaders();
        }
        const authToken = this._authService.getToken();
        if (authToken) {
            options.headers = options.headers.append('Authorization', 'Bearer ' + authToken);
        }
        return options;
    }

    // displaying error message
    private handleError(error: any): Observable<any> {
        this.validationService.handleError(error)
        return Observable.throw(error);
    }
}
