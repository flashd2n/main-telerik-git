import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

@Injectable()
export class ProductGuardService implements CanActivate {
  constructor() { }

  canActivate(): boolean {
    return true;
  }
}
