// Imports
// Deprecated import
import { Routes } from '@angular/router';

import { ExternalLayoutComponent } from './external-layout.component';
import { loginRoutes } from '../account/login/login.routes';
import { homeRoutes } from '../home/home.routes'; 
import { registerRoutes } from '../account/register/register.routes';

 
 
import { errorRoutes } from '../common/error/error.routes';
// Route Configuration
export const externalLayoutRoutes: Routes = [
    {
        path: '',
        component: ExternalLayoutComponent,
        children: [
            ...homeRoutes,
            ...loginRoutes, 
            ...registerRoutes, 
            ...errorRoutes
        ]
    }
];
