import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoteConsultaComponent } from './lote-consulta.component';

describe('LoteConsultaComponent', () => {
  let component: LoteConsultaComponent;
  let fixture: ComponentFixture<LoteConsultaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoteConsultaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoteConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
