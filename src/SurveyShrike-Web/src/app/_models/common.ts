import { HttpHeaders, HttpParams } from '@angular/common/http';

export class RequestOption {
    public headers: HttpHeaders;
    public params?: HttpParams;
    public responseType?: 'json';
}
 