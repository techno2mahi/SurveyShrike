import { Injectable, EventEmitter } from '@angular/core';
import { LocalStorageKeys } from '../shared/constant';

@Injectable()
export class Helper {
    public loadProfileImage: EventEmitter<boolean>;
    public showAppLoader: EventEmitter<boolean>;

    constructor() {
        this.loadProfileImage = new EventEmitter();
        this.showAppLoader = new EventEmitter();
    }
    public getObjectFromLocalStorage(key): any {
        const keyData = localStorage.getItem(key);
        if (keyData && keyData !== 'undefined') {
            return JSON.parse(keyData);
        }
        return null;
    }

    public setObjectInLocalStorage(key, data): any {
        localStorage.setItem(key, JSON.stringify(data));
    }

    public getUserName() {
        let userName = '';
        const user = this.getObjectFromLocalStorage(LocalStorageKeys.User);
        if (user) {
            userName = user.firstName;
        }
        return userName;
    }

    public getUserProfileMediaId() {
        let mediaId = 0;
        const user = this.getObjectFromLocalStorage(LocalStorageKeys.User);
        if (user) {
            mediaId = user.profileMediaId;
        }
        return mediaId;
    }

 
    public getErrorMessageFromModelState(modelState: any, controlName: string): string {
        let errorMessage = '';
        for (const fieldName in modelState) {
            if (modelState.hasOwnProperty(fieldName)) {
                const formControlName = this.getErrorControlName(fieldName);
                if (formControlName && controlName && formControlName.toLocaleLowerCase() === controlName.toLocaleLowerCase()) {
                    if (Array.isArray(modelState[fieldName])) {
                        errorMessage = modelState[fieldName][0];
                    } else {
                        errorMessage = modelState[fieldName];
                    }
                    break;
                }
            }
        }
        return errorMessage;
    }

    public findParentNode(parentName, childObj) {
        let testObj = childObj.parentNode;
        let count = 1;
        while (testObj.getAttribute('name') !== parentName) {
            alert('My name is ' + testObj.getAttribute('name') + '. Let\'s try moving up one level to see what we get.');
            testObj = testObj.parentNode;
            count++;
        }
        // now you have the object you are looking for - do something with it
        alert('Finally found ' + testObj.getAttribute('name') + ' after going up ' + count + ' level(s) through the DOM tree');
    }

    public findParentNodeByTagName(tagName: string, childObj: any) {
        let testObj = childObj.parentNode;
        let count = 1;
        while (testObj && testObj.tagName && testObj.tagName.toLocaleLowerCase() !== tagName.toLocaleLowerCase()) {
            testObj = testObj.parentNode;
            count++;
        }
        // now you have the object you are looking for - do something with it
        return testObj;
    }

    public getErrorControlName(fieldName: string): string {
        let retVal = fieldName;
        if (fieldName.indexOf('.')) {
            const arr = fieldName.split('.');
            retVal = arr[arr.length - 1];
        }
        return retVal;
    }

    public getErrorDetails(errorRes: any) {
        const errorDetails: any = {
            error: '',
            message: 'Server error',
            modelState: null
        };
        if (errorRes) {
            if (errorRes.error) {
                errorDetails.error = errorRes.error.error;
                if (errorRes.error && errorRes.error.modelState) {
                    errorDetails.modelState = errorRes.error.modelState;
                }
                if (errorRes.error.message) {
                    errorDetails.message = errorRes.error.message;
                } else if (errorRes.error.errorMessage) {
                    errorDetails.message = errorRes.error.errorMessage;
                } else if (errorRes.error.error_description) {
                    errorDetails.message = errorRes.error.error_description;
                }
            }
        }
        return errorDetails;

    }

    public getSurveyFromLocalStorage(): any {
        const survey = this.getObjectFromLocalStorage(LocalStorageKeys.Survey);
        return survey;
    }

    public getSurveyInitials(input: string) {
        let initials = '';
        if (input) {
            initials = (input.match(/\b(\w)/g)).join('');
        }
        return initials;
    }
}
