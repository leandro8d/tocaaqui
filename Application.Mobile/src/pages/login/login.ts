import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { UserProvider } from '../../providers/user/user';
import { HomePage } from '../home/home';
import {GlobalProvider} from '../../providers/global/global'



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
  
  constructor(public navCtrl: NavController, public navParams: NavParams,userProvider: UserProvider,public global:GlobalProvider) {
    this.userprovider = userProvider;
    this.homePage = HomePage;
  }
  userprovider;
  homePage;
  user = {_Login:undefined,Password:undefined};
  login = function(userData){ 
    this.userprovider.Login(userData);
    // .subscribe(
    //   res => {
    //     this.navCtrl.push(this.homePage);
    //   },
    //   err => {
    //     console.log("Error occured");
    //   }
    // ); 

   
    // this.global.get('/User').subscribe(res => 
    //   console.log(res)
    // )
    

  }
  
  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
 
  }
  
}
