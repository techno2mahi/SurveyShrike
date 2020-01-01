import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSurveyDetailComponent } from './view-survey-detail.component';

describe('EditManageSurveyDetailsComponent', () => {
  let component: ViewSurveyDetailComponent;
  let fixture: ComponentFixture<ViewSurveyDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSurveyDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSurveyDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
