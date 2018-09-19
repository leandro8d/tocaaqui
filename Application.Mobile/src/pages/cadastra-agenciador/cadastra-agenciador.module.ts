import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { CadastraAgenciadorPage } from './cadastra-agenciador';

@NgModule({
  declarations: [
    CadastraAgenciadorPage,
  ],
  imports: [
    IonicPageModule.forChild(CadastraAgenciadorPage),
  ],
})
export class CadastraAgenciadorPageModule {}
