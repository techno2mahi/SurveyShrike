import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SnackToastService } from '../../_services/snackToast.service';

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html',
  styleUrls: ['./features.component.scss']
})
export class FeaturesComponent implements OnInit {

  constructor(private router: Router, private toastr: SnackToastService) { }

  ngOnInit() {
  }

  public redirectTo(url: string) {
    const redirectUrl = '/' + url;
    this.router.navigate([redirectUrl]);
  }

  public toBeImplemented(url: string) {

    this.toastr.success('Yet to be implemented.');
  }




}
