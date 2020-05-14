import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoteRegistroComponent } from './lote-registro.component';

describe('LoteRegistroComponent', () => {
  let component: LoteRegistroComponent;
  let fixture: ComponentFixture<LoteRegistroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoteRegistroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoteRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
