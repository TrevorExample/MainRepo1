import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusreportsComponent } from './statusreports.component';

describe('StatusreportsComponent', () => {
  let component: StatusreportsComponent;
  let fixture: ComponentFixture<StatusreportsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatusreportsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusreportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
