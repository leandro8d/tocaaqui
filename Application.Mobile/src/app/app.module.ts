import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { BandasPage } from '../pages/bandas/bandas';
import { LoginPage } from '../pages/login/login';
import { CadastraUsuarioPage } from '../pages/cadastra-usuario/cadastra-usuario';
import { CadastraAgenciadorPage } from '../pages/cadastra-agenciador/cadastra-agenciador';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { UserProvider } from '../providers/user/user';
import { GlobalProvider } from '../providers/global/global';

import {TokenInterceptor} from '../configs/interceptor';
import {JwtInterceptor} from '../configs/jwtinterceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    BandasPage,
    LoginPage,
    CadastraUsuarioPage,
    CadastraAgenciadorPage,
    
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    HttpClientModule,
    HttpModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    BandasPage,
    LoginPage,
    CadastraUsuarioPage,
    CadastraAgenciadorPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    UserProvider,
    GlobalProvider,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    
  ]
})
export class AppModule {}
