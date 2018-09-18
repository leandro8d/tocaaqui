import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { UserProvider } from '../../providers/user/user';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  
  constructor(public navCtrl: NavController,public userprovider:UserProvider) {
    console.log( this.userprovider.isAuthenticated());
    console.log(this.userprovider.isTokenExpired());
    console.log(this.userprovider.getTokenExpirationDate());
  }
  
}
