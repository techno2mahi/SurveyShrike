import { MaterialModule } from './MaterialModule';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ToastrModule } from 'ngx-toastr';
import { NguCarouselModule } from '@ngu/carousel';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { Select2Module } from 'ng2-select2';
import { CalendarModule } from 'angular-calendar';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

// routing
import { routing } from './app.routes';

// guards
import { LoggedInUserAuthGuard, SurveyAuthGuard } from './_guards';

import { AppComponent } from './app.component';
import { StripHtmlTagsPipe } from './_pipes/strip-html-tags.pipe';
import { SpinnerComponent } from './common/spinner/spinner.component';
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './account/register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DashboardAdminComponent } from './dashboard/dashboard-admin/dashboard-admin.component';
import { BreadcrumbsComponent } from './common/breadcrumb/breadcrumb.component';
import { LoaderComponent } from './common/loader/loader.component';
import { SpinLoaderComponent } from './common/spin-loader/spin-loader.component';
import { LayoutComponent } from './layout/layout.component';
import { ExternalLayoutComponent } from './external-layout/external-layout.component';

// directives
import { HandleValidationDirective } from './_directives/validation/handle-validation.directive';

// Services
import { AuthService } from './_services/auth.service';
import { CustomHttpSevice } from './_services/custom.http.service';
import { Helper } from './_services/helper.service';
import { UserService } from './_services/user.service';
import { CommonService } from './_services/common.service';
import { PageTitleService } from './_services/page-title.service';
import { BreadcrumbService } from './common/breadcrumb/breadcrumb.service';
import { SecurityService } from './_services/security.service';
import { SurveyService } from './_services/survey.service';
import { ValidationService } from './_services/validation.service';
import { RoutingStateService } from './_services/routingState.service';
import { SnackToastService } from './_services/snackToast.service';
import { MenuToggleModule } from './common/menu/menu-toggle.module';

import { FeaturesComponent } from './public/features/features.component';

import { FooterComponent } from './common/footer/footer.component';
import { ErrorComponent } from './common/error/error.component';
import { ThinFooterComponent } from './common/thin-footer/thin-footer.component'; 
import { ManageSurveyComponent } from './survey-management/manage-survey/manage-survey.component'; 
import { ViewSurveyDetailComponent } from './survey-management/view-survey-detail/view-survey-detail.component'; 
import { AddUpdateSurveyComponent } from './survey-management/add-update-survey/add-update-survey.component';

@NgModule({
  entryComponents: [ 
  ],
  declarations: [
    AppComponent,
    StripHtmlTagsPipe,
    SpinnerComponent,
    LoginComponent,
    HomeComponent, 
    RegisterComponent,
    DashboardComponent,
    BreadcrumbsComponent,
    LayoutComponent,
    DashboardAdminComponent,
    LoaderComponent,
    SpinLoaderComponent,
    FeaturesComponent,
    HandleValidationDirective,
    ExternalLayoutComponent,
    FooterComponent,
    ErrorComponent,
    ThinFooterComponent, 
    ManageSurveyComponent, 
    AddUpdateSurveyComponent,
    ViewSurveyDetailComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    CustomFormsModule,
    HttpClientModule,
    routing,
    MaterialModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MenuToggleModule,
    ReactiveFormsModule,
    NguCarouselModule,
    NgxDatatableModule,
    Select2Module,
    ToastrModule.forRoot(),
    CalendarModule.forRoot(),
    NgbModalModule.forRoot()

  ],
  providers: [
    AuthService,
    CustomHttpSevice,
    Helper,
    UserService,
    CommonService,
    PageTitleService,
    BreadcrumbService,
    SecurityService,
    SurveyService,
    ValidationService,
    RoutingStateService,
    SnackToastService,
    LoggedInUserAuthGuard,
    SurveyAuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
