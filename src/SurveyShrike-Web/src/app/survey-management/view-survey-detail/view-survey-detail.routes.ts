// Imports
// Deprecated import
import { Routes } from '@angular/router';

import { ViewSurveyDetailComponent } from './view-survey-detail.component';

// Route Configuration
export const ViewSurveyDetailRoutes: Routes = [
    { path: 'view-survey/:id', component: ViewSurveyDetailComponent }
];
