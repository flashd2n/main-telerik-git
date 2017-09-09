import { Injectable } from '@angular/core';

@Injectable()
export class UsersService {

  users = [
    { id: 1, name: 'Steven' },
    { id: 2, name: 'Viktor' },
    { id: 3, name: 'Cuki' },
  ];

  getAll() {
    return this.users;
  }

  addUser(name: string, id: number) {
    this.users.push({
      id: id,
      name: name
    });
  }
}
