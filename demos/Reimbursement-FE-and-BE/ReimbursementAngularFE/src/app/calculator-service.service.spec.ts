import { TestBed } from '@angular/core/testing';

import { CalculatorServiceService } from './calculator-service.service';

describe('CalculatorServiceService', () => {
  let service: CalculatorServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculatorServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
