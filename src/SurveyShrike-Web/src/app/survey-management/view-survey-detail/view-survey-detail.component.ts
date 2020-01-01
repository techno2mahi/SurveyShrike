import { Component, OnInit } from '@angular/core';
import { PageTitleService } from '../../_services/page-title.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AppURLs } from '../../shared/constant';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { ISurvey } from '../../_models/survey';
import { SurveyService } from '../../_services/survey.service';

@Component({
  selector: 'app-view-survey-detail',
  templateUrl: './view-survey-detail.component.html',
  styleUrls: ['./view-survey-detail.component.scss']
})
export class ViewSurveyDetailComponent implements OnInit {
  public survey: ISurvey;
  private ngUnsubscribe: Subject<void>;

  constructor(private pageTitleService: PageTitleService,
    private route: ActivatedRoute,
    private surveyService: SurveyService,
    private _router: Router) {
    this.ngUnsubscribe = new Subject<void>();
  }

  ngOnInit() {
    this.pageTitleService.setTitle.emit('View Survey Detail');
    this.route.params.pipe(
      takeUntil(this.ngUnsubscribe))
      .subscribe((params) => {
        const surveyId = params['id']; 
        this.getSurveyDetails(surveyId);
      });
  }

 

  public editDetails() {
    this._router.navigate([AppURLs.addUpdateSurvey, this.survey.id]);
  }

  public onCancelClick() {
    this._router.navigate([AppURLs.manageSurveys]);
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

  public learnMore() {
    alert('Learn More');
  }

}
