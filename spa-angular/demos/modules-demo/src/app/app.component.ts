import { UsersService } from './users/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'app';
  users;

  constructor(private userService: UsersService) { }

  ngOnInit(): void {
    this.users = this.userService.getAll();
  }
}
