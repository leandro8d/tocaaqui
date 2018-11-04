import { Component } from '@angular/core';
import { NavParams, NavController } from 'ionic-angular';

/**
 * Generated class for the ModalbandaComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'modalbanda',
  templateUrl: 'modalbanda.html'
})
export class ModalbandaComponent {

  banda: any = { Portifolio: {} };

  public fechar() {
    this.navCtrl.pop();
  }

  constructor(public nav: NavParams, public navCtrl: NavController ) {
    this.banda = nav.get('banda');
  }

}
