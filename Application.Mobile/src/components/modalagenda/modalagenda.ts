import { Component } from '@angular/core';

/**
 * Generated class for the ModalagendaComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'modalagenda',
  templateUrl: 'modalagenda.html'
})
export class ModalagendaComponent {

  text: string;

  constructor() {
    console.log('Hello ModalagendaComponent Component');
    this.text = 'Hello World';
  }

}
