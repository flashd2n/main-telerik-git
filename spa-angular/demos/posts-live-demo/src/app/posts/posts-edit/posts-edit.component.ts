import { IPost } from './../posts.models';
import { PostsService } from './../posts.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-posts-edit',
  templateUrl: './posts-edit.component.html',
  styleUrls: ['./posts-edit.component.css']
})
export class PostsEditComponent implements OnInit {

  public editForm: FormGroup;

  constructor(private postsService: PostsService) { }

  ngOnInit() {
    const title = new FormControl('asd', Validators.required);
    const body = new FormControl();

    this.editForm = new FormGroup({
      title: title,
      body: body
    });
  }

  edit(data: IPost) {
    console.log(data);
  }

}
