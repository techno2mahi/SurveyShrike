import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../shared/constant';
import { Helper } from './helper.service';
import { CustomHttpSevice } from './custom.http.service';

@Injectable()
export class CommonService {
    constructor(
        private _http: CustomHttpSevice) { }

 
}
