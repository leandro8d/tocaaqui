import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { SessionProvider } from '../../providers/session/session';
import {BandaProvider} from '../../providers/banda/banda';
import {PortifolioPage} from '../portifolio/portifolio'
import {CadastraBandaPage} from '../cadastra-banda/cadastra-banda'
import {GlobalProvider} from '../../providers/global/global'

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  
  constructor(public navCtrl: NavController,public session:SessionProvider,public bandaProvider:BandaProvider, public global: GlobalProvider) {
    console.log( this.session.isAuthenticated());
    console.log(this.session.isTokenExpired());
    console.log(this.session.getTokenExpirationDate());
    this.usuarioLogado = this.session.CurrentUser;
    this.bandaProvider.ListarBandasUsuario(this.usuarioLogado.Usuario._implementation.IdUsuario).subscribe(data => 
      {
        this.bandasUsuario = data
      }
      ,error => {this.global.showToast(error.error);});
      
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
  