
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Person } from '../person';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })

export class ApiService {

  baseURL: string = "http://localhost:50893/";
  url = window.location.protocol + '//' + window.location.host +'/';

  constructor(private http: HttpClient) {
  }



  UpdateUser(input: string): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(input);
   
    return this.http.post(this.url + 'questions/UpdateUser?input=asdfasfd', body, { 'headers': headers });
  }

  CheckObject(input2: Questions): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(input2);

    return this.http.post(this.url + 'questions/CheckObject', body, { 'headers': headers });
  }

  CheckScore(input2: Questions[]): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(input2);

    return this.http.post(this.url + 'questions/CheckScore', body, { 'headers': headers });
  }

}

interface Questions {

  question: string;
  answer: string;
  answer2: string;
  answe3: string;
  answer4: string;
  answerChoice: string;
  score: boolean;
}
