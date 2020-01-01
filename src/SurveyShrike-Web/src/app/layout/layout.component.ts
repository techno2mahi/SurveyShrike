import { Component, OnInit, OnDestroy, ViewChild, ViewEncapsulation, ChangeDetectorRef } from '@angular/core';
import { PageTitleService } from '../_services/page-title.service';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { MediaChange, ObservableMedia } from '@angular/flex-layout';
import { Helper } from '../_services/helper.service';
import { Constants, AppSettings, AppURLs, LocalStorageKeys } from '../shared/constant';
import { filter } from 'rxjs/operators';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { RoutingStateService } from '../_services/routingState.service';
import { ISurvey } from '../_models/survey';
import { UserRole } from 'app/_models/security';
import { SecurityService } from 'app/_services/security.service';

@Component({
    selector: 'layout',
    templateUrl: './layout.html',
    styleUrls: ['./layout.scss'],
    encapsulation: ViewEncapsulation.None
})
export class LayoutComponent implements OnInit, OnDestroy {
    private _router: Subscription;
    header: string;
    url: string;
    showSettings = false;
    dark: boolean;
    boxed: boolean;
    collapseSidebar: boolean;
    compactSidebar: boolean;
    customizerIn = false;
    root = 'ltr';
    chatpanelOpen = false;
    isFullscreen = false;
    userName = '';
    public surveys = Array<ISurvey>();
    public selectedSurvey: ISurvey;
    public userRole: any;

    private _mediaSubscription: Subscription;
    public sidenavOpen = true;
    public sidenavMode = 'side';
    public isMobile = false;
    public showBackButton: boolean;
    public showSurveyList: boolean;
    public imageUrl = Constants.NoAvatar;
    private _routerEventsSubscription: Subscription;
    private ngUnsubscribe: Subject<void>;
    @ViewChild('sidenav') sidenav;
    public currentRole: UserRole = UserRole.None;
    constructor(private securityService: SecurityService,
        private _changeDetector: ChangeDetectorRef,
        private pageTitleService: PageTitleService,
        private routingStateService: RoutingStateService,
        private router: Router,
        private media: ObservableMedia,
        private helper: Helper) {
        this.userRole = UserRole;
        this.ngUnsubscribe = new Subject<void>();
        this.currentRole = this.securityService.getCurrentUserRole();
        if (this.currentRole === UserRole.User) {
        }
    }

    ngOnInit() {
        this.setHeader(this.router.url);
        console.log(this.router.url);
        this.pageTitleService.setTitle.pipe(
            takeUntil(this.ngUnsubscribe))
            .subscribe((val: string) => {
                this.header = val;
                this._changeDetector.detectChanges();
            });


        this._router = this.router.events.pipe(filter(event => event instanceof NavigationStart)).subscribe((event: NavigationStart) => {
            this.setHeader(event.url);
            this._changeDetector.detectChanges();
        });

        this._mediaSubscription = this.media.asObservable().subscribe((change: MediaChange) => {
            const isMobile = (change.mqAlias === 'xs') || (change.mqAlias === 'sm');

            this.isMobile = isMobile;
            this.sidenavMode = (isMobile) ? 'over' : 'side';
            this.sidenavOpen = !isMobile;
        });

        this._routerEventsSubscription = this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd && this.isMobile) {
                this.sidenav.close();
            }
        });
        if (this.media.isActive('xs') || this.media.isActive('sm')) {
            this.isMobile = true;
            this.sidenavMode = (this.isMobile) ? 'over' : 'side';
            this.sidenavOpen = !this.isMobile;
        } 

        this.setUserData();
    } 

    private setUserData() {
        this.userName = this.helper.getUserName();
    }

    public toggleSurveyList() {
        this.showSurveyList = !this.showSurveyList;
    }

    public goBack() {
        this.routingStateService.goBack();
    }

    private setHeader(url: string) {
        if (url !== AppURLs.dashboard && (this.media.isActive('xs') || this.media.isActive('sm'))) {
            this.showBackButton = true;
        } else {
            this.showBackButton = false;
        }
    }

    ngOnDestroy() {
        this._changeDetector.detach();
        this._router.unsubscribe();
        this._mediaSubscription.unsubscribe();
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public menuMouseOver(): void {
        if (window.matchMedia(`(min-width: 960px)`).matches && this.collapseSidebar) {
            this.sidenav.mode = 'over';
        }
    }

    public menuMouseOut(): void {
        if (window.matchMedia(`(min-width: 960px)`).matches && this.collapseSidebar) {
            this.sidenav.mode = 'side';
        }
    }

    public customizerFunction() {
        this.customizerIn = !this.customizerIn;
    }

    public viewProfile(): void {
        this.router.navigate([AppURLs.profile]);
    }

 
    public goToHome(): void {
        this.router.navigate([AppURLs.dashboard]);
    }

    public onActivate(event, scrollContainer) {
        scrollContainer.scrollTop = 0;
    }

    public logout() {
        localStorage.clear();
        this.router.navigate([AppURLs.login]);
        // this.userService.logOut()
        // .subscribe((data) => {
        //     this.router.navigate(['/login']);
        // },
        // error => {
        //     this.toastr.errorObj(error, 'Oops!');
        // });
    }

    public onSurveySelection(surveyId: number) {
        this.showSurveyList = false;
        this.selectedSurvey = this.surveys.find((item) => {
            return surveyId === item.id;
        });
        this.helper.setObjectInLocalStorage(LocalStorageKeys.Survey, this.selectedSurvey);
    }
 
}
