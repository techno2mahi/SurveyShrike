/* tslint:disable:no-unused-variable */

import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { MatCardModule, MatToolbarModule, MatButtonModule, MatIconModule, MatIconRegistry } from '@angular/material';

describe('App: BeCompany RSS Reader', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        MatCardModule,
        MatToolbarModule,
        MatButtonModule,
        MatIconModule
      ],
      declarations: [
        AppComponent,
        SpinnerComponent
      ],
      providers: [MatIconRegistry]
    });
  });

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));

  it('should render "BeCompany news" in a span tag', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('span.center').textContent).toContain('BeCompany news');
  }));
});
