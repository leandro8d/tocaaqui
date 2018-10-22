import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {FotoProvider} from '../../providers/foto/foto'
import { ImagePicker,ImagePickerOptions   } from '@ionic-native/image-picker';
import { File } from '@ionic-native/file';
import { Base64 } from '@ionic-native/base64';
import { DomSanitizer } from '@angular/platform-browser';
import { GlobalProvider } from '../../providers/global/global';
/**
* Generated class for the PortifolioPage page.
*
* See https://ionicframework.com/docs/components/#navigation for more info on
* Ionic pages and navigation.
*/

@Component({
  selector: 'page-portifolio',
  templateUrl: 'portifolio.html',
})
export class PortifolioPage {
  
  constructor(public navCtrl: NavController, public navParams: NavParams, public fotoProvider: FotoProvider, private imagePicker: ImagePicker,
    private file:File, private base64:Base64, public domSanitizer:DomSanitizer, public global: GlobalProvider) {
    }
    files:any;
    portifolio:any = {Fotos:[]};
    preview:any = [];
    inclusao:boolean = true;
    
    ionViewDidLoad() {
      this.portifolio.IdBanda = this.navParams.get("idBanda");
      this.inclusao = this.navParams.get("inclusao");
      if(!this.inclusao){
        this.portifolio = this.navParams.get("portifolio");
      }
    }
    
    
    getPhoto() {
      
      let options = {
        maximumImagesCount: (5-this.portifolio.Fotos.length),
        width:600,
        height:390,
        outputType:1
      };
      this.imagePicker.getPictures(options).then((results) => {
        for (var i = 0; i < results.length; i++) {
          let current = results[i];
          let filename = current.substring(current.lastIndexOf('/')+1);
          let path =  current.substring(0,current.lastIndexOf('/')+1);
          
          //then use the method reasDataURL  btw. var_picture is ur image variable
          // this.file.readAsDataURL(path, filename).then(res =>  current  = res  );
          
          //this.base64.encodeFile(results[i]).then((base64File: string) => {
          this.portifolio.Fotos.push(current);
          
          //}, (err) => {
          //   console.log(err);
          //});
        }
      }, (err) => { });
    }
    
    changeListener($event) : void {
      this.files = $event.target.files[0];
    }
    criarPortifolio(portifolio){
      if(this.inclusao){
        this.fotoProvider.CriarPortifolio(portifolio).subscribe(data=>{
          
        }, msg =>  this.global.showToast(msg.error));
      }
      else
      {
        
      }
    };
    
    
  }
  