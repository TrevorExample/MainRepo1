import { TestBed } from '@angular/core/testing';

import { AccountEndpointService } from './account-endpoint.service';

describe('AccountEndpointService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AccountEndpointService = TestBed.get(AccountEndpointService);
    expect(service).toBeTruthy();
  });
});
