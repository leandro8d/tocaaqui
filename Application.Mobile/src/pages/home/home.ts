import { Component } from '@angular/core';
import { NavController, ModalController } from 'ionic-angular';
import { SessionProvider } from '../../providers/session/session';
import { BandaProvider } from '../../providers/banda/banda';
import { PortifolioPage } from '../portifolio/portifolio';
import { CadastraBandaPage } from '../cadastra-banda/cadastra-banda';
import { GlobalProvider } from '../../providers/global/global';
import { ModalbandaComponent } from '../../components/modalbanda/modalbanda'

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(public navCtrl: NavController, public session: SessionProvider, public bandaProvider: BandaProvider, public global: GlobalProvider, public modal: ModalController) {
    this.bandaProvider.Listar().subscribe(data =>{
      this.bandas = data;
      
    }
    );

  }
  bandas: any = [];

  public verBanda(banda) {

    let bandaModal = this.modal.create(ModalbandaComponent, { 'banda': banda });
    bandaModal.present();
  }

}
