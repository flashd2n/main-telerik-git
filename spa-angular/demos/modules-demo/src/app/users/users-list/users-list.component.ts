import { UsersService } from './../users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css'],
})
export class UsersListComponent implements OnInit {

  private users;
  constructor(private userService: UsersService) { }

  addUser(name: string) {
    const id = this.users.length;
    this.userService.addUser(name, id);
  }

  ngOnInit() {
    this.users = this.userService.getAll();
  }

}
