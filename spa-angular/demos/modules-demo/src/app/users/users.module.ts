import { UsersResolver } from './users-resolver';
import { UsersRoutingModule } from './users-routing.module';
import { UsersService } from './users.service';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { UsersListComponent } from './users-list/users-list.component';
import { UserComponent } from './user/user.component';

@NgModule({
  imports: [
    SharedModule,
    UsersRoutingModule
  ],
  declarations: [UsersListComponent, UserComponent],
  providers: [UsersResolver]
})
export class UsersModule { }
