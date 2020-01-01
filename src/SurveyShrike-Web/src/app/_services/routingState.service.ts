import { Injectable } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AppURLs } from '../shared/constant';

@Injectable()
export class RoutingStateService {
  private history = [];

  constructor(
    private router: Router
  ) {}

  public loadRouting(): void {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(({urlAfterRedirects}: NavigationEnd) => {
        this.history = [...this.history, urlAfterRedirects];
        console.log(JSON.stringify(this.history));
      });
  }

  public getHistory(): string[] {
    return this.history;
  }

  public getPreviousUrl(): string {
    let url = AppURLs.dashboard;
    if (this.history.length > 2) {
        url = this.history[this.history.length - 2];
        this.history.splice(this.history.length - 1, 1);
    } else {
        this.history = [];
    }
    this.removeCurrentUrl();
    return url;
  }

  private removeCurrentUrl() {
    if (this.history.length > 1) {
        this.history.splice(this.history.length - 1, 1);
    }
  }

  public goBack() {
    const url = this.getPreviousUrl();
    this.router.navigate([url]);
  }

  public getCurrentUrl() {
    return this.router.url;
  }
}
