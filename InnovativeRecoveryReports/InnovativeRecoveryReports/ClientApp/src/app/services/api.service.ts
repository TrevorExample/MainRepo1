import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  url = window.location.protocol + '//' + window.location.host + '/';


  getPlacementReport(input: string): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(input);

    return this.http.post(this.url + 'placement/getPlacementReport?input=asdfasfd', body, { 'headers': headers });
  }




}
