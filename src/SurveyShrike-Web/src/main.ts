import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { environment } from 'environments/environment';
import { AppModule } from 'app';

if (environment.production) {
  enableProdMode();
}

const bootstrap = () => {
  platformBrowserDynamic().bootstrapModule(AppModule);
  };

if (!!window['cordova']) {
  document.addEventListener('deviceready', bootstrap, false);
  } else {
   bootstrap();
  }


// // for app
// document.addEventListener('deviceready', () =>
//   platformBrowserDynamic().bootstrapModule(AppModule), false);

// // for web aplication
// platformBrowserDynamic().bootstrapModule(AppModule);


