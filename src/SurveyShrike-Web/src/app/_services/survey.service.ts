import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../shared/constant';
import { CustomHttpSevice } from './custom.http.service';

@Injectable()
export class SurveyService {

    constructor(
        private _http: CustomHttpSevice) { }

    public getSurveys(): Observable<any> {
        const url: string = AppSettings.API_GetSurveys;
        return this._http.get(url);
    }

    public getSurveyDetailsById(surveyId: string): Observable<any> {
        const url: string = AppSettings.API_GetSurveyById.replace('{:id}', surveyId);
        return this._http.get(url);
    }

    public addSurvey(survey: any): Observable<any> {
        const url: string = AppSettings.API_AddSurvey;
        return this._http.post(url, survey);
    }

    public updateSurvey(survey: any): Observable<any> {
        const url: string = AppSettings.API_UpdateSurvey.replace('{:id}', survey.id);
        return this._http.put(url, survey);
    }

}
