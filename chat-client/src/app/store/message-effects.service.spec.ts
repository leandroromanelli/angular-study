import { TestBed } from '@angular/core/testing';

import { MessageEffectsService } from './message-effects.service';

describe('MessageEffectsService', () => {
  let service: MessageEffectsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MessageEffectsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
