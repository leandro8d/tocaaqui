import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {UsuarioProvider} from '../../providers/usuario/usuario'
import {GlobalProvider} from '../../providers/global/global'
import {LoginPage} from '../login/login'
/**
 * Generated class for the CadastraUsuarioPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-cadastra-usuario',
  templateUrl: 'cadastra-usuario.html',
})
export class CadastraUsuarioPage {

  constructor(public navCtrl: NavController, public navParams: NavParams, public provider: UsuarioProvider,public global:GlobalProvider) {
  }



  public login:any = {Usuario:{}};
  public tipos:any;

  banda:any = {};
  estados;
  cidades;
 
public onSelectEstado(){
 this.global.getCidadesEstados(this.login.Usuario.Estado).subscribe(data=>{
   this.cidades = data
 }, error => this.global.showToast(error.error));
}
  public criarUsuario(usr:Object){
    this.global.showLoader();
    this.provider.CriarUsuario(usr).subscribe(data=>{ this.global.dismissLoader(); this.global.showToast(data); this.navCtrl.push(LoginPage);console.log(data)}, error => {this.global.showToast(error.error);this.global.dismissLoader();});
  }
  ionViewDidLoad() {
    this.global.getEstados().subscribe(data=>{
      this.estados = data
    }, error => this.global.showToast(error.error));
  }

}
