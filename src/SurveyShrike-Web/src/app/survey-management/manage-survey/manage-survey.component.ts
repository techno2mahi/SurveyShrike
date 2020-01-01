import { Component, OnInit } from '@angular/core';
import { ISurvey } from '../../_models/survey';
import { PageTitleService } from '../../_services/page-title.service';
import { SurveyService } from '../../_services/survey.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AppURLs } from '../../shared/constant';
import { SnackToastService } from '../../_services/snackToast.service';

@Component({
  selector: 'app-manage-survey',
  templateUrl: './manage-survey.component.html',
  styleUrls: ['./manage-survey.component.scss']
})
export class ManageSurveyComponent implements OnInit {
  public surveys: Array<ISurvey>;
  private ngUnsubscribe: Subject<void>;
  public loading: boolean;
  constructor(private pageTitleService: PageTitleService,
    private router: Router,
    private toastr: SnackToastService,
    private surveyService: SurveyService) {
        this.ngUnsubscribe = new Subject<void>();
}

  ngOnInit() {
    this.initialize();
    this.pageTitleService.setTitle.emit('Manage Survey');
    this.loading = true;
    }

    public manageSurveyDetail(surveyId: number) {
      this.router.navigate([AppURLs.viewSurveyDetail, surveyId]);
    }

    public onClickAddSurvey() {
      this.router.navigate([AppURLs.addUpdateSurvey, 0]);
    }

    
    public deleteSurvey() {
      this.toastr.warning('Yet to be implemented.');
    }
    private getUserSurveys() {
      this.surveyService.getSurveys()
      .pipe(
          takeUntil(this.ngUnsubscribe))
          .subscribe(
              data => {
                this.loading = false;
                  this.surveys = data;
              },
              error => {
                  console.log(error);
                  this.loading = false;
              });
    }

    private initialize() {
        this.getUserSurveys();
    }
 
    public learnMore() {
      alert('Learn More');
    }
}
