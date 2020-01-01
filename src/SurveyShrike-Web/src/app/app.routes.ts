// Imports
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// import { loginRoutes } from './account/login/login.routes';
// import { homeRoutes } from './home/home.routes';
// import { externalLoginRoutes } from './account/external-login/external-login.routes';
// import { blankRoutes } from './account/blank-route/blank.routes';
// import { registerRoutes } from './account/register/register.routes';
// import { forgotPasswordRoutes } from './account/forgot-password/forgot-password.routes';
import { layoutRoutes } from './layout/layout.routes';
import { externalLayoutRoutes } from './external-layout/external-layout.routes';
// import { aboutUsRoutes } from './about-us/about-us.routes';
// import { contactUsRoutes } from './contact-us/contact-us.routes';
// import { featuresRoutes } from './features/features.routes';
// import { careersRoutes } from './careers/careers.routes';
// import { downloadAppRoutes } from './download-app/download-app.routes';
// Route Configuration
export const routes: Routes = [
  // ...homeRoutes,
  // ...loginRoutes,
  // ...externalLoginRoutes,
  // ...registerRoutes,
  // ...forgotPasswordRoutes,
  ...layoutRoutes,
  ...externalLayoutRoutes
  // ...featuresRoutes,
  // ...aboutUsRoutes,
  // ...contactUsRoutes,
  // ...careersRoutes,
  // ...downloadAppRoutes
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes, { useHash: false });
