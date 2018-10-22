import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {GlobalProvider} from '../global/global'

/*
  Generated class for the CadastrousuarioProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class UsuarioProvider {

  constructor(public http: HttpClient,public global:GlobalProvider) {
    console.log('Hello CadastrousuarioProvider Provider');
  }

  public CriarUsuario(usuario:Object){
    return this.global.put('/user/add', usuario,{});

  }

  public UpdateUsuario(usuario:Object){
    return this.global.post('/user', usuario,{});

  }
    
  public GetUsuario(id:number){
    return this.global.get('/user',{params:{id:id}});
 
  }
  
  public ListarUsuarios(usuario:Object){
    return this.global.get('/user',null);
  }
  public ListarTiposUsuario(){
    return this.global.get('/user/tiposusuario',null);
  }

}
