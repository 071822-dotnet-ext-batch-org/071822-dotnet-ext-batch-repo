import { TestBed } from '@angular/core/testing';

import { AssociateServiceService } from './associate-service.service';

describe('AssociateServiceService', () => {
  let service: AssociateServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AssociateServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
