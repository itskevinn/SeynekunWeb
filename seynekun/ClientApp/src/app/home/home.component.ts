import { Component } from '@angular/core';
import { BodegaService } from '../servicios/servicio-bodega/bodega.service';
import { ProductoService } from '../servicios/servicio-producto/producto.service';
import { Bodega } from '../seynekun/models/modelo-bodega/bodega';
import { Producto } from '../seynekun/models/modelo-producto/producto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  bodegas: Bodega[];
  productos: Producto[];
  bodegasTraidas: boolean;
  productosTraidos: boolean;
  constructor(
    private productoService: ProductoService,
    private bodegaService: BodegaService, ) {
  }

  ngOnInit(): void {
    this.obtenerBodegas();
    this.obtenerProductos();
  }
  obtenerBodegas() {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
      this.bodegasTraidas = true;
    });
  }
  obtenerProductos() {
    this.productoService.gets().subscribe((result) => {
      this.productos = result;
      this.productosTraidos = true;
    });
  }
}
