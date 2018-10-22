import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import{GlobalProvider} from '../../providers/global/global';
import {BandaProvider} from '../../providers/banda/banda';
import {HomePage} from '../home/home'
import { ImagePicker,ImagePickerOptions   } from '@ionic-native/image-picker';
import { Base64 } from '@ionic-native/base64';
import { DomSanitizer } from '@angular/platform-browser';
import { File } from '@ionic-native/file';

/**
* Generated class for the CadastraBandaPage page.
*
* See https://ionicframework.com/docs/components/#navigation for more info on
* Ionic pages and navigation.
*/

declare var google;

@Component({
  selector: 'page-cadastra-banda',
  templateUrl: 'cadastra-banda.html',
})
export class CadastraBandaPage {
  
  constructor(public navCtrl: NavController, public navParams: NavParams,public global:GlobalProvider,public service:BandaProvider, private imagePicker: ImagePicker,
    private base64: Base64,public DomSanitizer: DomSanitizer,private file: File) {
    }
    
    imgPreview = '../../assets/imgs/logo.png';
    banda:any = {EstilosMusicais:[] = new Array(),FotoBanda:{}};
    estados:any;
    cidades:any;
    estilosMusicais:any;
    foto:any;
    formBanda:FormData =  new FormData();
    inclusao:boolean=false;
    
    getPhoto() {
      
      let options = {
        maximumImagesCount: 1,
        width:600,
        height:390,
        outputType:1
      };
      this.imagePicker.getPictures(options).then((results) => {
        for (var i = 0; i < results.length; i++) {         
          this.banda.Foto = results[i];          
        }
      }, (err) => { });
    }
    
    public onSelectEstado(){
      this.global.getCidadesEstados(this.banda.Estado).subscribe(data=>{
        this.cidades = data
      }, error => console.log(error));
    }
    
    public criarBanda(banda){
      this.global.showLoader();
      if(!this.inclusao){
        this.service.UpdateBanda(banda).subscribe(rsp=>
          {
            this.global.dismissLoader();
            this.global.showToast(rsp);
            this.navCtrl.push(HomePage);
          },error => { this.global.showToast(error.error)});
        }
        else{
          this.service.CriarBanda(banda).subscribe(rsp=>
            {
              this.global.showToast(rsp);
              this.navCtrl.push(HomePage);
            },error => { this.global.showToast(error.error)});
          }
        }
        
        public addEstilo(estilo){
          this.banda.EstilosMusicais.push(estilo);
        }
        
        ionViewDidLoad() {
          
          this.global.getEstados().subscribe(data=>{
            this.estados = data
          }, error => this.global.showToast(error.error));
          
          this.service.ListarTiposMusicais().subscribe(data =>{
            this.estilosMusicais = data;
          })
          
          this.inclusao = this.navParams.get("inclusao")?this.navParams.get("inclusao"):true;
          if(!this.inclusao){
            
            this.banda = this.navParams.get("banda");
            this.onSelectEstado();
          }
          
        }
        
      }
      