import { Component, OnInit } from '@angular/core';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { Productor } from '../../models/modelo-productor/productor';

@Component({
  selector: 'app-productor-consulta',
  templateUrl: './productor-consulta.component.html',
  styleUrls: ['./productor-consulta.component.css']
})
export class ProductorConsultaComponent implements OnInit {
  productores: Productor[];
  productor: Productor;
  listaVacia: Boolean = true;
  cantidadProductores: Number;
  constructor(private productorService: ProductorService) { }

  ngOnInit(): void {
    this.productorService.gets().subscribe(result => {
      this.productores = result;
    });
  }
  validarTamañoLista() {
    if (this.productores.length == 0) {
      this.listaVacia == true;
    }
    else this.listaVacia == false;
  }
  contarProductores() {
    this.cantidadProductores = this.productores.length;
  }
}
