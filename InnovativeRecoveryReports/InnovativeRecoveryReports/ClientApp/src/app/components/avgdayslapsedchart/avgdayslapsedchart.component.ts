import { Component, OnInit, Inject, ElementRef, AfterViewInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { ApiService } from '../../services/api.service';

import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-avg-days-laps-chart',
  templateUrl: './avgdayslapsedchart.component.html',
  styleUrls: ['./avgdayslapsedchart.component.css']
})
export class AvgDaysLapsedChartComponent implements OnInit {

  constructor(private apiService: ApiService, private elementRef: ElementRef, @Inject(DOCUMENT) private _document: Document) { }

  input = "asdfasdfasdf";
  public placements: avgDaysLapsed[];
  ngOnInit() {

    this.apiService.getAvgDaysLapsedReport(this.input)
      .subscribe(result => {
        this.barChartLabels = result;
        //alert(JSON.stringify(result));

      })
    //this.apiService.getAvgDaysLapsedReport2(this.input)
    //  .subscribe(result => {
    //    this.barChartData = result;
    //    //alert(JSON.stringify(result));

    //  })

  }


  public barChartOptions: ChartOptions = {
    onClick: this.graphClickEvent,
    //responsive: true,
    //maintainAspectRatio: false,
    // We use these empty structures as placeholders for dynamic theming.
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public barChartLabels: Label[] = ['Deep Ellum Lofts', 'STONE CANYON APARTMENTS', 'REFLECTIONS APARTMENTS', 'SOCO', 'COURTHOUSE SQUARE', 'JEFFERSON PLACE APARTMENTS', 'DAVIDSON'];
  public barChartType: ChartType = 'horizontalBar';
  //public barChartLegend = true;
  public barChartPlugins = [pluginDataLabels];

  public barChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 81, 56, 55, 40], label: 'Avg Days Lapsed' },
  ];

  public chartColors: Array<any> = [{ // first color
    backgroundColor: '#7af589',
    pointBackgroundColor: '#7af589',
  },];

  // events
  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);

  }

  graphClickEvent(event, array) {
    alert('clicked on data index '+ array[0]._index)
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  //public randomize(): void {
  //  // Only Change 3 values
  //  this.barChartData[0].data = [
  //    Math.round(Math.random() * 100),
  //    59,
  //    80,
  //    (Math.random() * 100),
  //    56,
  //    (Math.random() * 100),
  //    40];
  //}

  ngAfterViewInit() {
  //  var s = document.createElement("script");
  //  s.type = "text/javascript";
  //  //s.type = "application/javascript;charset=utf-8";
  //  //s.innerHTML = " alert('testfilload');";
  //  //s.src = "../clientapp/src/assets/testalert.js";
  //  s.src = "assets/testalert.js";
  //  this.elementRef.nativeElement.appendChild(s);
  }



 



}


interface avgDaysLapsed {

  Creditor: string;
  DaysLapsed: string;
}
