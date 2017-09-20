import { EmitterServiceService } from './emitter-service.service';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SomethingCleverComponent } from './somethingClever/somethingClever.component';
import { MyModalComponentComponent } from './my-modal-component/my-modal-component.component';

@NgModule({
  declarations: [
    AppComponent,
    SomethingCleverComponent,
    MyModalComponentComponent
],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ModalDialogModule.forRoot(),
    FormsModule
  ],
  providers: [EmitterServiceService],
  bootstrap: [AppComponent],
  entryComponents: [MyModalComponentComponent]
})
export class AppModule { }
