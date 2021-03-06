import { Component, ViewChild } from '@angular/core';
import { Nav, Platform } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';


import { HomePage } from '../pages/home/home';
import { BandasPage } from '../pages/bandas/bandas';
import { LoginPage } from '../pages/login/login';
import { CadastraUsuarioPage } from '../pages/cadastra-usuario/cadastra-usuario';
import { CadastraBandaPage } from '../pages/cadastra-banda/cadastra-banda';
import { PortifolioPage } from '../pages/portifolio/portifolio';


@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  @ViewChild(Nav) nav: Nav;

  rootPage: any = LoginPage;
  home = HomePage;

  pages: Array<{title: string, component: any}>;

  constructor(public platform: Platform, public statusBar: StatusBar, public splashScreen: SplashScreen) {
    this.initializeApp();
    localStorage.removeItem('token');

    // used for an example of ngFor and navigation
    this.pages = [
      { title: 'Home', component: HomePage },
      { title: 'Minhas Bandas', component: BandasPage },
      { title: 'Cadastro de Usuários', component: CadastraUsuarioPage},
      { title: 'Cadastro de Banda', component: CadastraBandaPage}
    ];

    platform.registerBackButtonAction(() => {
      if ( this.nav.canGoBack()) { // CHECK IF THE USER IS IN THE ROOT PAGE.
        this.nav.pop(); // IF IT'S NOT THE ROOT, POP A PAGE.
      } else {
        platform.exitApp(); // IF IT'S THE ROOT, EXIT THE APP.
      }
    });

  }

  initializeApp() {
    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.statusBar.show();
      this.splashScreen.hide();
      
    });
  }

  openPage(page) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.setRoot(page.component);
  }
}
