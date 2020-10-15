import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionsScoreComponent } from './questions-score.component';

describe('QuestionsScoreComponent', () => {
  let component: QuestionsScoreComponent;
  let fixture: ComponentFixture<QuestionsScoreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionsScoreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionsScoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
