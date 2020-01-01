import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { SpinLoaderComponent } from './spin-loader.component';

describe('Spin Loader Component', () => {
    let component: SpinLoaderComponent;
    let fixture: ComponentFixture<SpinLoaderComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [SpinLoaderComponent],
            schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
            imports: [FormsModule, NgbModule.forRoot()],
            providers: [NgbActiveModal]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(SpinLoaderComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('Verify it should have a defined component', () => {
        expect(component).toBeDefined();
    });
});