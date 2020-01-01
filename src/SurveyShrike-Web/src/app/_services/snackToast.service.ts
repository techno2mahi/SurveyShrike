import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MatSnackBar } from '@angular/material';

@Injectable()
export class SnackToastService {
  private duration = 2000;
  constructor(private toastr: ToastrService, private snackBar: MatSnackBar) { }

  public success(message: string, title?: string) {
    this.toastr.success(message, title);
  }

  public warning(message: string, title?: string) {
    this.toastr.warning(message, title);
  }

  public error(message: string, title?: string) {
    this.toastr.error(message, title);
  }

  public errorObj(message: any, title?: string) {
    this.error(JSON.stringify(message), title);
  }
}
