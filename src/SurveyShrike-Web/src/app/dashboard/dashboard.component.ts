import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UserRole } from '../_models/security';
import { SecurityService } from '../_services/security.service';
import { Router } from '@angular/router';
import { AppURLs } from 'app/shared/constant';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard-component.html',
  styleUrls: ['./dashboard-component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements OnInit  {

  public currentRole: UserRole = UserRole.None;
  public userRole = UserRole;
  constructor(private securityService: SecurityService,
    private router: Router
    ) {
  }
  ngOnInit() {
    this.currentRole = this.securityService.getCurrentUserRole();
    if (this.currentRole === UserRole.User) {
    }
  }
}
