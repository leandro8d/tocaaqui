import { Component } from '@angular/core';
import { NavController,ModalController } from 'ionic-angular';
import { SessionProvider } from '../../providers/session/session';
import {BandaProvider} from '../../providers/banda/banda';
import {PortifolioPage} from '../portifolio/portifolio';
import {CadastraBandaPage} from '../cadastra-banda/cadastra-banda';
import {GlobalProvider} from '../../providers/global/global';
import {ModalbandaComponent} from '../../components/modalbanda/modalbanda'

@Component({
  selector: 'page-bandas',
  templateUrl: 'bandas.html'
})
export class BandasPage {
  selectedItem: any;
  icons: string[];
  items: Array<{title: string, note: string, icon: string}>;

  constructor(public navCtrl: NavController,public session:SessionProvider,public bandaProvider:BandaProvider, public global: GlobalProvider, public modal: ModalController) {
    this.global.showLoader();
    this.usuarioLogado = this.session.CurrentUser;
    this.bandaProvider.ListarBandasUsuario(this.usuarioLogado.Usuario._implementation.IdUsuario).subscribe(data => 
      {
        this.global.dismissLoader();
        this.bandasUsuario = data
      }
      ,error => {
        this.global.showToast(error.error);
        this.global.dismissLoader();});
  }


  public usuarioLogado; 
  public bandasUsuario:Array<Object>;

  public criarPortifolio(banda){
    this.navCtrl.push(PortifolioPage,{idBanda:banda.IdBanda,inclusao:true})
  }

  
  public editarPortifolio(banda){
    this.navCtrl.push(PortifolioPage,{portifolio:banda.Portifolio,inclusao:false})
  }

  public editarBanda(banda){
    this.navCtrl.push(CadastraBandaPage,{banda:banda,inclusao:false})
  }



}
