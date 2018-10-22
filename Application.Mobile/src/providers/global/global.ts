import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { AlertController, LoadingController,ToastController } from 'ionic-angular';
/*
Generated class for the GlobalProvider provider.

See https://angular.io/guide/dependency-injection for more info on providers
and Angular DI.
*/
@Injectable()
export class GlobalProvider {
  
  constructor(public http: HttpClient, public loadingCtrl:LoadingController,public alertCtrl:AlertController, public toastCtrl: ToastController) {
    console.log('Hello GlobalProvider Provider');
  }
  
  globalUrl = "http://192.168.15.8:5000/api";
  loading:any;
  get = function (url:string,params:any){
  
    return this.http.get(this.globalUrl+url,params);
  }
  post = function (url:string,params:any,option:any){
    
    return this.http.post(this.globalUrl+url, params,option);
  }

  put = function (url:string,params:any,option){
    
    return this.http.put(this.globalUrl+url, params,option);
  }

 getEstados(){
   return this.http.get('https://br-cidade-estado-nodejs.glitch.me/estados',{});
 }
 getCidadesEstados(estado){
  return this.http.get('https://br-cidade-estado-nodejs.glitch.me/estados/'+estado+'/cidades',{});
 }

 showLoader(){
  this.loading = this.loadingCtrl.create({
      content: 'Aguarde...'
  });

  this.loading.present();
}

dismissLoader(){
  this.loading.dismiss();
}

showAlertConfirm(title,msg){
  let alert = this.alertCtrl.create({
    title: title,
    subTitle: msg,
    buttons: ['OK']
  });
  alert.present();

}

showToast(msg){

  let toast = this.toastCtrl.create({
    message: msg,
    duration: 3000,
    position: 'top'
  });

  toast.present();
}

 
}
