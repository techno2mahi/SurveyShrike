// Imports
// Deprecated import
import { Routes } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { dashboardRoutes } from '../dashboard/dashboard.routes';
  
import { featuresRoutes } from '../public/features/features.routes';
 
import { errorRoutes } from '../common/error/error.routes';
import { LoggedInUserAuthGuard } from '../_guards';  
import { ManageSurveyRoutes } from '../survey-management/manage-survey/manage-survey.routes';
import { ViewSurveyDetailRoutes } from '../survey-management/view-survey-detail/view-survey-detail.routes';
import { AddUpdateSurveysRoutes } from '../survey-management/add-update-survey/add-update-survey.routes'; 


// Route Configuration
export const layoutRoutes: Routes = [
    {
        path: 'dashboard',
        component: LayoutComponent,
        canActivate: [LoggedInUserAuthGuard],
        children: [
            ...dashboardRoutes,  
            ...errorRoutes,
            ...featuresRoutes, 
            ...ManageSurveyRoutes,
            ...AddUpdateSurveysRoutes,
            ...ViewSurveyDetailRoutes,
        ]
    }
];
