import { ElementRef, Directive, Renderer } from '@angular/core';
import { ValidationService } from '../../_services/validation.service';
import { Helper } from '../../_services/helper.service';
import { SnackToastService } from '../../_services/snackToast.service';

@Directive({
    selector: '[handleValidation]'
})
export class HandleValidationDirective {
    private spanErrCssClass = 'mat-text-warn';
    private spanErrCustomCssClass = 'custom-error';
    constructor(private el: ElementRef, private renderer: Renderer,
        private tostr: SnackToastService,
        private validationService: ValidationService,
        private helper: Helper) {
        this.validationService.validationChanged.subscribe(() => this.handleErrors());

        // Don't remove can be used for client side validation
        renderer.listen(el.nativeElement, 'blur', event => this.handleClienValidation(event));
    }

    handleErrors() {
        const name = this.el.nativeElement.name;
        const handler = this.validationService.getErrors(location.pathname);

        if (name) {
            const parent = this.helper.findParentNodeByTagName('mat-form-field', this.el.nativeElement).parentNode;
            this.removeChildBlocks(parent);

            if (handler && handler.errors && handler.errors.modelState) {
                const modelState = handler.errors.modelState;
                const error = this.helper.getErrorMessageFromModelState(modelState, name);
                if (error) {
                    this.renderer.setElementClass(parent, 'has-error', true);
                    this.addErrorBlock(parent, error);
                }
            }
        } else {
            // this.removeChildBlocks(this.el.nativeElement);
            // const block = this.renderer.createElement(this.el.nativeElement, 'small');
            // this.renderer.setElementClass(block, this.spanErrCssClass, true);
            // this.renderer.setElementClass(block, this.spanErrCustomCssClass, true);
            // this.renderer.setText(block, handler.error);
            // block.innerText = handler.error;

            const errors = [handler.error];
            this.tostr.error(handler.error);
        }
    }

    handleClienValidation(event: any) {
        const el = event.target;
        const name = this.el.nativeElement.name;
        //const parent = this.helper.findParentNodeByTagName('mat-form-field', this.el.nativeElement).parentNode;
        let error = '';
        this.clearError(parent);
        if (!el.validity.valid) {
            if (el.validity.valueMissing) { error = el.getAttributeNode('fieldname').value + ` is required`; }
            if (el.validity.tooShort) { error = `Value must be at least ${this.el.nativeElement.minLength} characters long`; }
            if (el.validity.tooLong) { error = `Value cannot exceed ${this.el.nativeElement.maxLength} characters`; }
            if (el.validity.patternMismatch) { error = `Invalid ` + el.getAttributeNode('fieldname').value; }
            if (el.validity.rangeUnderflow) { error = `Value is under minimum of ${this.el.nativeElement.min}`; }
            if (el.validity.rangeOverflow) { error = `Value is over maximum of ${this.el.nativeElement.max}`; }


            this.renderer.setElementClass(parent, 'has-error', true);
            if (error) {
                this.addErrorBlock(parent, error);
            }
        }
    }

    addErrorBlock(el: any, error: string) {
        const block = this.renderer.createElement(el, 'small');
        this.renderer.setElementClass(block, this.spanErrCssClass, true);
        this.renderer.setElementClass(block, this.spanErrCustomCssClass, true);
        this.renderer.setText(block, error);
        block.innerText = error;
    }

    clearError(el: any) {
        this.renderer.setElementClass(el, 'has-error', false);
        this.removeChildBlocks(el);
    }

    private removeChildBlocks(el: any) {
        try {
            // IE does NOT support forEach from childNodes
            const array = Array.from(el.childNodes);
            array.forEach((element: any) => {
                if (element && element.classList) {
                    if (element.classList.contains(this.spanErrCssClass) && element.classList.contains(this.spanErrCustomCssClass)) {
                        el.removeChild(element);
                    }
                }
            });
        } catch (e) {
            console.log(e);
        }
    }
}
