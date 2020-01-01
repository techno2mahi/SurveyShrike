import { Injectable, EventEmitter } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class PageTitleService {
    // public title: BehaviorSubject<string> = new BehaviorSubject<string>(null);

    // setTitle(value: string) {
    //     this.title.next(value);
    // }

    public setTitle: EventEmitter<string>;
    constructor() {
        this.setTitle = new EventEmitter();
    }
}
