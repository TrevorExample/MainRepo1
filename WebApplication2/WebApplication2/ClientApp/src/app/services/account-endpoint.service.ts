import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';




@Injectable({
  providedIn: 'root'
})
export class AccountEndpointService {

  //get usersUrl() { return this.configurations.baseUrl + '/api/account/users'; }
  //get currentUserUrl() { return this.configurations.baseUrl + '/api/account/users/me'; }

  get usersUrl() { return '/api/account/users'; }
  get currentUserUrl() { return '/api/account/users/me'; }

  constructor(private http: HttpClient) {  }

  //getUpdateUserEndpoint<T>(userObject: any, userId?: string): Observable<T> {
  //getUpdateUserEndpoint<T>(userObject: any, userId?: string): Observable<T> {
  //  const endpointUrl = userId ? `${this.usersUrl}/${userId}` : this.currentUserUrl;

    //return this.http.put<T>(endpointUrl, JSON.stringify(userObject), this.requestHeaders).pipe<T>(
    //  catchError(error => {
    //    return this.errormethod();
    //  }));
  }
 
      

    //return this.http.post<T>(this.usersUrl, JSON.stringify(userObject), this.requestHeaders).pipe<T>(
    //  catchError(error => {
    //    return this.handleError(error, () => this.getNewUserEndpoint(userObject));
    //  }));

//  errormethod() { }
//}




