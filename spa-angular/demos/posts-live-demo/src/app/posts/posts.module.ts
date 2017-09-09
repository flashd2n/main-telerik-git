import { MydirDirective } from './posts-create/shared/mydir.directive';
import { SomePipe } from './posts-create/shared/some.pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostsRoutingModule } from './posts-routing.module';
import { PostsListComponent } from './posts-list/posts-list.component';
import { PostsCreateComponent } from './posts-create/posts-create.component';
import { PostsService } from './posts.service';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PostsEditComponent } from './posts-edit/posts-edit.component';

@NgModule({
  imports: [
    CommonModule,
    PostsRoutingModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    PostsListComponent,
    PostsCreateComponent,
    PostsEditComponent,
    SomePipe,
    MydirDirective
],
  providers: [
    PostsService
  ]
})
export class PostsModule { }
