import { PostsService } from './../posts.service';
import { IPost } from './../posts.models';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-posts-create',
  templateUrl: './posts-create.component.html',
  styleUrls: ['./posts-create.component.css']
})
export class PostsCreateComponent implements OnInit {

  private title = 'Pesho';
  private body = 'Lorem';


  constructor(private postService: PostsService) { }

  ngOnInit() {
  }

  create(data: IPost) {
    this.postService.createPost(data);
    console.log(data);
  }

}
