import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'home',
  styleUrls: ['./home-component.scss'],
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public customizerIn = false;
  constructor(
  ) {

  }


  public customizerFunction() {
    this.customizerIn = !this.customizerIn;
  }
}

