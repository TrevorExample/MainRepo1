
import { Injectable } from '@angular/core';
import { Observable, Subject, forkJoin } from 'rxjs';
import { mergeMap, tap } from 'rxjs/operators';

import { AccountEndpointService } from './account-endpoint.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private accountEndpoint: AccountEndpointService) { }



  updateUser(user:any ) {
  
      //return this.accountEndpoint.getUpdateUserEndpoint(user, user.id);
   
    }
  }

  //updateUser(user: UserEdit) {
  //  if (user.id) {
  //    return this.accountEndpoint.getUpdateUserEndpoint(user, user.id);
  //  } else {
  //    return this.accountEndpoint.getUserByUserNameEndpoint<User>(user.userName).pipe(
  //      mergeMap(foundUser => {
  //        user.id = foundUser.id;
  //        return this.accountEndpoint.getUpdateUserEndpoint(user, user.id);
  //      }));
  //  }
  //}



