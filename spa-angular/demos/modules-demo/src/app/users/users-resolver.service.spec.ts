/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UsersResolverService } from './users-resolver.service';

describe('Service: UsersResolver', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UsersResolverService]
    });
  });

  it('should ...', inject([UsersResolverService], (service: UsersResolverService) => {
    expect(service).toBeTruthy();
  }));
});