import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {UserProvider} from '../user/user'
/*
Generated class for the GlobalProvider provider.

See https://angular.io/guide/dependency-injection for more info on providers
and Angular DI.
*/
@Injectable()
export class GlobalProvider {
  
  constructor(public http: HttpClient,public user: UserProvider) {
    console.log('Hello GlobalProvider Provider');
  }
  
  globalUrl = "http://localhost:5000/api";
  
  get = function (url,params,options){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    return this.http.get(this.globalUrl+url,httpOptions);
  }
  post = function (url,params,options){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post(this.globalUrl+url, params,httpOptions);
  }
  
}
