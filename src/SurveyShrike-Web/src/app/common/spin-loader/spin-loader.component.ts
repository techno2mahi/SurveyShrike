'use strict';

import { Component, Input } from '@angular/core';

@Component({
    selector: 'spin-loader',
    styleUrls: ['spin-loader.scss'],
    templateUrl: 'spin-loader.html'
})
export class SpinLoaderComponent {
    @Input() public loadingText: string;
    @Input() public isSmallLoader: boolean;
}
