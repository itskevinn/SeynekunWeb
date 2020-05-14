import { Component, OnInit } from '@angular/core';
import { ProductoService } from 'src/app/servicios/servicio-producto/producto.service';
import { Producto } from 'src/app/seynekun/models/modelo-producto/producto';

@Component({
  selector: 'app-producto-consulta',
  templateUrl: './producto-consulta.component.html',
  styleUrls: ['./producto-consulta.component.css']
})
export class ProductoConsultaComponent implements OnInit {

  productos: Producto[];  
  listaVacia: Boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private productoService: ProductoService) {}

  ngOnInit(): void {
    this.productoService.gets().subscribe((result) => {
      this.productos = result;
    });
  } 

}
