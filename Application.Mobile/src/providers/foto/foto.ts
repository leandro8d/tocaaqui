import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {GlobalProvider} from '../global/global';
import {SessionProvider} from '../session/session';
import { HttpHeaders } from '@angular/common/http';
/*
  Generated class for the FotoProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class FotoProvider {


  constructor(public http: HttpClient,public global:GlobalProvider,public session:SessionProvider) {
    console.log('Hello CadastrobandaProvider Provider');
  }

  public CriarPortifolio(portifolio:any){
  
    return this.global.put('/banda/portifolio', portifolio, {});

  }

  


}
