import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/*
Generated class for the GlobalProvider provider.

See https://angular.io/guide/dependency-injection for more info on providers
and Angular DI.
*/
@Injectable()
export class GlobalProvider {
  
  constructor(public http: HttpClient) {
    console.log('Hello GlobalProvider Provider');
  }
  
  globalUrl = "http://localhost:5000/api";
  
  get = function (url,params,options){
    return this.http.get(this.globalUrl+url, params,);
  }
  post = function (url,params,options){
    return this.http.post(this.globalUrl+url, params,);
  }
  
}
