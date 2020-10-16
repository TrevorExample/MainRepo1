import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-placement',
  templateUrl: './placement.component.html',
  styleUrls: ['./placement.component.css']
})
export class PlacementComponent implements OnInit {

  constructor(private apiService: ApiService,) { }

  ngOnInit() {

    //alert("start");
    this.clickEvent();
  }

  input = "asdfasdfasdf";
  public placements: Placements[];


  clickEvent() {



    this.apiService.getPlacementReport(this.input)
      .subscribe(result => {
        this.placements = result;
        //alert(JSON.stringify(result));

      })
  }


}


interface Placements {

  ClientNumber: string;
  ManagementNumber: string;
  Community: string;
  FirstName: string;
  LastName: string;
  SSN: string;
  TenantCode: string;
  ListedDate: string;
  MoveInDate: string;
  MoveOutDate: string;
  Principal: string;
  amtdueclient: string;
  amtremaining: string;
 
}

