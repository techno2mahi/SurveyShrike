import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LoaderComponent } from './loader.component';

describe('LoaderComponent', () => {
    let component: LoaderComponent;
    let fixture: ComponentFixture<LoaderComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [LoaderComponent],
            schemas: [NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
            imports: [FormsModule, NgbModule.forRoot()],
            providers: [NgbActiveModal]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(LoaderComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();

    });

    it('should be created', () => {
        expect(component).toBeTruthy();
    });

    it('should be loading Text', () => {
        //expect(component.loadingText).toBe(true);
        expect(component.loadingText).toString();
        const loadingPassedText = fixture.nativeElement.querySelector('#loaderDiv .loadingText');
        expect(loadingPassedText.innerText.trim()).toString();
    });
});