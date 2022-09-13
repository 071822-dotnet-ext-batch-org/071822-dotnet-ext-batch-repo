import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestTestComponent } from './request-test.component';

describe('RequestTestComponent', () => {
  let component: RequestTestComponent;
  let fixture: ComponentFixture<RequestTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestTestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
