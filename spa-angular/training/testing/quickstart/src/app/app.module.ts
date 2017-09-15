import { WelcomeComponent } from './tests/dependency/welcome.component';
import { BannerComponent } from './tests/banner-inline.component';
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';

@NgModule({
  imports:      [ BrowserModule ],
  declarations: [ AppComponent, BannerComponent, WelcomeComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
