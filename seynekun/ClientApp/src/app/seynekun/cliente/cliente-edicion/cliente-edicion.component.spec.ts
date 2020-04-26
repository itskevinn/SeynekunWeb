import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClienteEdicionComponent } from './cliente-edicion.component';

describe('ClienteEdicionComponent', () => {
  let component: ClienteEdicionComponent;
  let fixture: ComponentFixture<ClienteEdicionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClienteEdicionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClienteEdicionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
