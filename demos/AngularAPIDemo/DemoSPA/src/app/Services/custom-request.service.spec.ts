import { TestBed } from '@angular/core/testing';

import { CustomRequestService } from './custom-request.service';

describe('CustomRequestService', () => {
  let service: CustomRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
