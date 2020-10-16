import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from "@angular/router";

import { AccountService } from '../services/account.service';
import { ApiService } from '../services/api.service';
import { MessageserviceService } from '../services/messageservice.service';


@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {




  public forecasts: Questions[];

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private accountService: AccountService,
    private apiService: ApiService,

    private router: Router) {
    http.get<Questions[]>(baseUrl + 'questions/GetQuestions').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }



  ngOnInit() {


  

  }

  myVar = 0;
  endVar: number = 0;
  selectedEntry;



  templateForm(value: any) {
    if (this.endVar == 0) { for (var c in this.forecasts) { this.endVar++ }; }

    if (value['gender'] == this.forecasts[this.myVar].answer) {
      if (this.myVar == (this.endVar - 1)) { this.forecasts[this.myVar].score = true;}
      else { this.myVar++; }
      alert(this.myVar + " " + (this.endVar - 1))
      this.forecasts[this.myVar-1].score = true;
    }
    else {
      if (this.myVar == (this.endVar - 1)) { this.forecasts[this.myVar].score = false;}
      else { this.myVar++; }
      alert("wrong answer");
      this.forecasts[this.myVar-1].score = false;
    }
  }

  baseURL: string = "http://localhost:50893/";
  input = "asdfasdfasdf";
  input2 = "asdfasdfasdf";
  clickEvent() {

    //this.accountService.updateUser(this.userEdit).subscribe(response => this.saveSuccessHelper(), error => this.saveFailedHelper(error));


    this.apiService.UpdateUser(this.input)
      .subscribe(data => {
        alert(JSON.stringify(data))

      })
  }

  cat: Questions = { question: "", answer: "", answer2: "", answe3: "", answer4: "", answerChoice: "", score: false };



  clickEvent2() {

    this.cat.question = "";
    this.cat.answer = "";
    this.cat.answer2 = "";
    this.cat.answe3 = "";
    this.cat.answer4 = "";
    this.cat.answerChoice = "";
    this.cat.score = false;



    // = [{ QuestionNumber: 1, Question: "what is your name", Answer: "hello", Answer2: "hello2", Answer3: "hello3", Score: false }];
    //this.accountService.updateUser(this.userEdit).subscribe(response => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
    alert("click2");



    this.apiService.CheckObject((this.cat))
      .subscribe(data => {
        alert(JSON.stringify(data)), error => alert(error)

      })
  }

  clickEvent3() {

    alert("click3");

    this.apiService.CheckScore((this.forecasts))
      .subscribe(data => {
        alert(JSON.stringify(data)), error => alert(error)

      })

  }

  clickEvent4() {
    this.apiService.createRole(this.input)
      .subscribe(data => {
        alert("done")

      })
  }


  public gotoProductDetails(url) {
    this.router.navigate([url]).then((e) => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });
    alert("questions-score");

    this.apiService.CheckScore((this.forecasts))
      .subscribe(data => {
        alert(JSON.stringify(data)), error => alert(error)

      })

  

  }

}
 
  //saveSuccessHelper() { alert("successs") };
  //saveFailedHelper(error) { alert("fail") };







interface Questions {

  question: string;
  answer: string;
  answer2: string;
  answe3: string;
  answer4: string;
  answerChoice: string;
  score: boolean;
}
