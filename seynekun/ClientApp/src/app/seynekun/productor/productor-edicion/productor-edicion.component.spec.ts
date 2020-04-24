import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductorEdicionComponent } from './productor-edicion.component';

describe('ProductorEdicionComponent', () => {
  let component: ProductorEdicionComponent;
  let fixture: ComponentFixture<ProductorEdicionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductorEdicionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductorEdicionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
