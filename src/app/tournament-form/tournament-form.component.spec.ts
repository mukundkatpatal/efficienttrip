import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TournaamentFormComponent } from './tournaament-form.component';

describe('TournaamentFormComponent', () => {
  let component: TournaamentFormComponent;
  let fixture: ComponentFixture<TournaamentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TournaamentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TournaamentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
