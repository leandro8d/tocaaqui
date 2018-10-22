import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { ImagePicker } from '@ionic-native/image-picker';
import { Base64 } from '@ionic-native/base64';
import { File } from '@ionic-native/file';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { BandasPage } from '../pages/bandas/bandas';
import { LoginPage } from '../pages/login/login';
import { CadastraUsuarioPage } from '../pages/cadastra-usuario/cadastra-usuario';
import { CadastraBandaPage } from '../pages/cadastra-banda/cadastra-banda';
import { PortifolioPage } from '../pages/portifolio/portifolio';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { SessionProvider } from '../providers/session/session';
import { GlobalProvider } from '../providers/global/global';

import {TokenInterceptor} from '../configs/interceptor';
import {JwtInterceptor} from '../configs/jwtinterceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { UsuarioProvider } from '../providers/usuario/usuario';
import { BandaProvider } from '../providers/banda/banda';
import { FotoProvider } from '../providers/foto/foto';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    BandasPage,
    LoginPage,
    CadastraUsuarioPage,
    CadastraBandaPage,
    PortifolioPage
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
    CadastraBandaPage,
    PortifolioPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    SessionProvider,
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
    UsuarioProvider,
    BandaProvider,
    ImagePicker,
    Base64,
    File,
    FotoProvider
  ]
})
export class AppModule {}
