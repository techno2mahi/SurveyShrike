import { Component, OnInit } from '@angular/core';

// Add the RxJS Observable operators we need in this app.
import './rxjs-operators';
import { AuthService } from './_services/auth.service';
import { Router } from '@angular/router';
import { AppURLs, AppSettings } from './shared/constant';
import { RoutingStateService } from './_services/routingState.service';
import { Helper } from './_services/helper.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

declare var cordova;
declare var navigator;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

    public showLoader: boolean;
    private ngUnsubscribe: Subject<void>;
    constructor(
        private router: Router,
        private authService: AuthService,
        private _helper: Helper,
        private routingStateService: RoutingStateService,
    ) {
        this.ngUnsubscribe = new Subject<void>();
        this._helper.showAppLoader.pipe(takeUntil(this.ngUnsubscribe))
                    .subscribe((value: boolean) => this.showAppLoader(value));
        routingStateService.loadRouting();
      
     }

    public ngOnInit() {
        this.checkUserAuthentication();
    }

    public showAppLoader(value: boolean) {
        this.showLoader = value;
    }

    checkUserAuthentication() {
        const authToken = this.authService.getToken();
        if (window.location.href.indexOf('external-login') > -1) {
            this.router.navigate(['/external-login', window.location.hash]);
        }
    }

    navigateToUrl() {
        this.router.navigate(['']);
    }

    
}
