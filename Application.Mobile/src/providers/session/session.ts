import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import {App} from "ionic-angular";
import { HomePage } from '../../pages/home/home';

import {GlobalProvider} from '../global/global'


/*
Generated class for the UserProvider provider.

See https://angular.io/guide/dependency-injection for more info on providers
and Angular DI.
*/

@Injectable()
export class SessionProvider {
  
  constructor(public http: HttpClient, public app:App, public global: GlobalProvider) {
    console.log('Hello UserProvider Provider');
  }
  
  CurrentUser:any = {};
  
  Login(objCredentials){
    this.global.showLoader();
    return this.http.post(this.global.globalUrl+'/Token', objCredentials).subscribe(
    res =>  {
      this.CurrentUser = res; 
      localStorage.setItem('token',this.CurrentUser.Token);
      let nav = this.app.getActiveNav();
      this.global.dismissLoader();
      
      nav.setRoot(HomePage);
    },
    msg =>
    { 
      console.error(`Error: ${msg.error} ${msg.statusText}`) ;
      this.global.showToast(msg.error);
      this.global.dismissLoader();
    }
    );
  }
  public getToken(): string {
    return localStorage.getItem('token');
  }
  public isAuthenticated(): boolean {
    // get the token
    // return a boolean reflecting 
    // whether or not the token is expired
    return this.isTokenExpired();
  }
  
  public getTokenExpirationDate(): Date {
    let token = this.getToken();
    if(token){
      const decoded = jwt_decode(this.getToken());
      
      if (decoded.exp === undefined) return null;
      
      const date = new Date(0); 
      date.setUTCSeconds(decoded.exp);
      return date;
    }
    return new Date();
  }
  
  public isTokenExpired(): boolean {
    let token =  this.getToken();
    if(!token) token = this.getToken();
    if(!token) return true;
    
    const date = this.getTokenExpirationDate();
    if(date === undefined) return false;
    return !(date.valueOf() > new Date().valueOf());
  }
  
}


