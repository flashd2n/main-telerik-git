import { UsersService } from './users.service';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class UsersResolver implements Resolve<any> {

    private users;
    constructor(private userService: UsersService) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.userService.getAll();
    }

}
