import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { SessionProvider } from '../../providers/session/session';
import { CadastraUsuarioPage } from '../cadastra-usuario/cadastra-usuario';
import {GlobalProvider} from '../../providers/global/global'
import { StatusBar } from '@ionic-native/status-bar';


/**
* Generated class for the LoginPage page.
*
* See https://ionicframework.com/docs/components/#navigation for more info on
* Ionic pages and navigation.
*/

@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {
  
  constructor(public navCtrl: NavController, public navParams: NavParams,public sessionProvider: SessionProvider,public global:GlobalProvider, public bar:StatusBar) {
    
  }
 
  user = {_Login:undefined,Password:undefined};

    logar(userData){ 
    this.sessionProvider.Login(userData);
  }

  criarUsuario(){
    this.navCtrl.push(CadastraUsuarioPage);
  }
  
  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  this.bar.show();   
 
  }
  
}
