import { UsersService } from './../users/users.service';
import { NgModule, Optional, SkipSelf } from '@angular/core';

@NgModule({
  providers: [UsersService]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parent: CoreModule) {
    if (parent) {
      throw new Error('Core module is already provided elsewhere');
    }
  }
}
