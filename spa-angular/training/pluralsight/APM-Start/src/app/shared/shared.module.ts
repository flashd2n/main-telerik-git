import { ConvertToSpaces } from './convert-to-spaces.pipe';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StarComponent } from './star.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    StarComponent,
    ConvertToSpaces
  ],
  exports: [
    StarComponent,
    ConvertToSpaces,
    CommonModule,
    FormsModule
  ]
})
export class SharedModule { }
