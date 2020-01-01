import { Component, OnInit } from '@angular/core';
import { PageTitleService } from '../../_services/page-title.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AppURLs } from '../../shared/constant';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { ISurvey, Survey } from '../../_models/survey';
import { SurveyService } from '../../_services/survey.service';
import { SnackToastService } from '../../_services/snackToast.service';
import { CommonService } from 'app/_services/common.service';

@Component({
  selector: 'add-update-survey',
  templateUrl: './add-update-survey.component.html',
  styleUrls: ['./add-update-survey.component.scss']
})
export class AddUpdateSurveyComponent implements OnInit {
  public loading: boolean;
  public spinLoading = false;
  public survey: ISurvey;
  public surveyId: string;
  private ngUnsubscribe: Subject<void>;
  public headerText = 'Create Survey';
  constructor(private pageTitleService: PageTitleService,
    private route: ActivatedRoute,
    private surveyService: SurveyService,
    private _commonService: CommonService,
    private toastr: SnackToastService,
    private _router: Router) {
    this.ngUnsubscribe = new Subject<void>();
  }

  ngOnInit() {
    this.pageTitleService.setTitle.emit('Add/Update Survey');
    this.route.params.pipe(
      takeUntil(this.ngUnsubscribe))
      .subscribe((params) => {
        this.surveyId = params['id']; // (+) converts string 'id' to a number
        if (this.surveyId && +this.surveyId > 0) {
          this.headerText = 'Update Survey';
          this.getSurveyDetails(this.surveyId);
        } else {
          this.survey = new Survey();
        }
        this.pageTitleService.setTitle.emit(this.headerText);
      });
  }

  public addUpdateSurvey(isValid: boolean) {
    if (isValid) {
      this.loading = true;
     
      if (this.survey.id > 0) {
        this.updateSurvey();
      } else {
        this.addSurvey();
      }
    }
  }
 
  public onCancelClick() {
    this._router.navigate([AppURLs.manageSurveys]);
  }

  private addSurvey() {
    this.surveyService.addSurvey(this.survey)
      .subscribe(
        data => {
          this.loading = false;
          this.toastr.success('Survey added successfully.');
          this._router.navigate([AppURLs.manageSurveys]);
        },
        error => {
          this.toastr.errorObj(error, 'Oops!');
          this.loading = false;
        });
  }

  private updateSurvey() {
    this.surveyService.updateSurvey(this.survey)
      .subscribe(
        data => {
          this.loading = false;
          this.toastr.success('Survey details updated successfully.');
          this._router.navigate([AppURLs.viewSurveyDetail, data.id]);
        },
        error => {
          this.toastr.errorObj(error, 'Oops!');
          this.loading = false;
        });
  }


 

  private getSurveyDetails(surveyId: string) {
    this.surveyService.getSurveyDetailsById(surveyId)
      .pipe(
        takeUntil(this.ngUnsubscribe))
      .subscribe(
        data => {
          this.survey = data;
        },
        error => {
          console.log(error);
        });
  }
}
