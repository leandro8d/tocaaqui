import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { CadastraUsuarioPage } from './cadastra-usuario';

@NgModule({
  declarations: [
    CadastraUsuarioPage,
  ],
  imports: [
    IonicPageModule.forChild(CadastraUsuarioPage),
  ],
})
export class CadastraUsuarioPageModule {}
