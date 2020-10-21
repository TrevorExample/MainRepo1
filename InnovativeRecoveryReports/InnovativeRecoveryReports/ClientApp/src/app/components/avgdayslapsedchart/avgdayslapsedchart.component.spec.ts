import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvgDaysLapsedChartComponent } from './avgdayslapsedchart.component';

describe('AvgDaysLapsChartComponent', () => {
  let component: AvgDaysLapsedChartComponent;
  let fixture: ComponentFixture<AvgDaysLapsedChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AvgDaysLapsedChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvgDaysLapsedChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
