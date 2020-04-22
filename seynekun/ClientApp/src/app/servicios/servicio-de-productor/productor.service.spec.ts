import { TestBed } from '@angular/core/testing';

import { ProductorService } from './productor.service';

describe('ProductorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductorService = TestBed.get(ProductorService);
    expect(service).toBeTruthy();
  });
});
