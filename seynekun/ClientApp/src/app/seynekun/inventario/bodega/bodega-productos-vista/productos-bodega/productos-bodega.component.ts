import { Component, OnInit } from "@angular/core";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { ActivatedRoute } from "@angular/router";
import { AjusteDeInventario } from "src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario";
import { AjusteInventarioService } from "src/app/servicios/servicio-ajuste/ajuste-inventario.service";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { ProductoEnBodega } from "src/app/seynekun/models/modelo-producto-bodega/producto-en-bodega";

@Component({
  selector: "app-productos-bodega",
  templateUrl: "./productos-bodega.component.html",
  styleUrls: ["./productos-bodega.component.css"],
})
export class ProductosBodegaComponent implements OnInit {
  bodega: Bodega;
  textoABuscar: string;
  ajustes: AjusteDeInventario[];
  seEncontro: boolean;
  productos: Producto[];
  productoEnBodegas: ProductoEnBodega[] = [];
  cantidadProducto: number;
  constructor(
    private bodegaService: BodegaService,
    private rutaActiva: ActivatedRoute,
    private ajusteService: AjusteInventarioService,
    private productoService: ProductoService
  ) {}
  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.productoService.gets().subscribe((result) => {
      this.productos = result;
    });
    this.bodegaService.get(nombre).subscribe((result) => {
      this.bodega = result;
      this.ajustes = this.bodega.ajustes;
      this.bodega != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
      this.obtenerProductosEnBodega();
    });
  }
  private obtenerProductosEnBodega() {    
    this.bodega.ajustes.forEach((ajuste) => {
      var productoEnBodega = new ProductoEnBodega();
      this.productoService.get(ajuste.codigoElemento).subscribe((result) => {
        productoEnBodega.producto = result;
        this.ajusteService
          .getCantidad(this.bodega.nombre, productoEnBodega.producto.codigo)
          .subscribe((result) => {
            productoEnBodega.cantidad = result;
          });
        if (!this.esRepetido(this.productoEnBodegas, productoEnBodega.producto.codigo)) {
          this.productoEnBodegas.push(productoEnBodega);
        }
      });
    });
  }
  private esRepetido(productosEnBodega: ProductoEnBodega[], codigo: string) {
    for (let i = 0; i < productosEnBodega.length; i++) {
      if (productosEnBodega[i].producto.codigo == codigo) return true;
    }
    return false;
  }
}
