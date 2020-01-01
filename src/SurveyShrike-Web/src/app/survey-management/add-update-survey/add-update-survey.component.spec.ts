import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateSurveyComponent } from './add-update-survey.component';

describe('UpdateManageSurveyDetailsComponent', () => {
  let component: AddUpdateSurveyComponent;
  let fixture: ComponentFixture<AddUpdateSurveyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddUpdateSurveyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateSurveyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
