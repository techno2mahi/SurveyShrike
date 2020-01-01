import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThinFooterComponent } from './thin-footer.component';

describe('ThinFooterComponent', () => {
  let component: ThinFooterComponent;
  let fixture: ComponentFixture<ThinFooterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThinFooterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThinFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
