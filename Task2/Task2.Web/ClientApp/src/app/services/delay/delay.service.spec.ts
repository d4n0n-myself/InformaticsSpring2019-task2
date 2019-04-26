import { TestBed } from '@angular/core/testing';

import { DelayService } from './delay.service';

describe('DelayService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DelayService = TestBed.get(DelayService);
    expect(service).toBeTruthy();
  });
});
