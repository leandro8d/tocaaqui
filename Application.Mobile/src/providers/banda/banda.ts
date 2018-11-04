import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {GlobalProvider} from '../global/global'
import {SessionProvider} from '../session/session'

/*
  Generated class for the CadastrobandaProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class BandaProvider {

  constructor(public http: HttpClient,public global:GlobalProvider,public session:SessionProvider) {
    console.log('Hello CadastrobandaProvider Provider');
  }

  public CriarBanda(banda:any){
    banda.Responsavel = this.session.CurrentUser.Usuario._implementation;
    return this.global.put('/banda', banda,{});

  }

  public UpdateBanda(banda:Object){
    return this.global.post('/banda', banda,{});

  }
    
  public GetBanda(id:number){
    return this.global.get('/banda',{params:{id:id}});

  }

  public GetPortifolio(id:number){
    return this.global.get('/banda/'+id+'/portifolio',{});

  }
  
  public ListarBandasUsuario(idBanda:number){
    return this.global.get('/banda/'+idBanda+'/bandas',{});
  }
  public ListarTiposMusicais(){
    return this.global.get('/banda/estilosmusicais',{});
  }

  public Listar(){
    return this.global.get('/banda/listar',{});
  }

}
