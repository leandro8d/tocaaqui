import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


/*
Generated class for the UserProvider provider.

See https://angular.io/guide/dependency-injection for more info on providers
and Angular DI.
*/

@Injectable()
export class UserProvider {
  
  constructor(public http: HttpClient) {
    console.log('Hello UserProvider Provider');
  }
  
  CurrentUser = {};
  
  Login(objCredentials){
    return this.http.post('http://localhost:5000/api/Token', objCredentials).toPromise().then(
    res => this.CurrentUser = res,
    msg => console.error(`Error: ${msg.status} ${msg.statusText}`) 
  );
}

}
