import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { PageTitleService } from '../../_services/page-title.service';
import { fadeInAnimation } from '../../common/route-animation/route.animation';
import { Helper } from '../../_services/helper.service';
import { Router } from '@angular/router';
import { SnackToastService } from '../../_services/snackToast.service';

@Component({
  selector: 'dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.scss'],
  encapsulation: ViewEncapsulation.None,
  host: { '[@fadeInAnimation]': 'true' },
  animations: [fadeInAnimation]
})
export class DashboardAdminComponent implements OnInit {

  rows = [];
  userName = '';

  constructor(private pageTitleService: PageTitleService,
    private router: Router,
    private helper: Helper,
    private toastr: SnackToastService) {
  }

  ngOnInit() {
    this.pageTitleService.setTitle.emit(null);
    this.userName = this.helper.getUserName();
  }

  public manageUserRoles() {
    this.router.navigate(['/manageUserRole']);
  }

  public navigateToSendNotification() {
    this.router.navigate(['/notification']);
  }

  public redirectTo(url: string) {
      const redirectUrl = '/' + url;
      this.router.navigate([redirectUrl]);
  }

  public redirectToFillTheSurvey(url: string) {
    this.toastr.success('Yet to be implemented.');
  }

 
}
