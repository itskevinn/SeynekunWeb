import { Component, OnInit } from "@angular/core";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { ActivatedRoute } from "@angular/router";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { ProductStockService } from "src/app/servicios/servicio-producto-stock/producto-stock.service";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { ProductoEnBodega } from "src/app/seynekun/models/modelo-producto-bodega/producto-en-bodega";

@Component({
  selector: "app-bodega-vista",
  templateUrl: "./bodega-vista.component.html",
  styleUrls: ["./bodega-vista.component.css"],
})
export class BodegaVistaComponent implements OnInit {
  bodega: Bodega;
  textoABuscar: string;
  productos: Producto[];
  productoEnBodegas: ProductoEnBodega[] = [];
  seEncontro: boolean;
  constructor(
    private bodegaService: BodegaService,
    private rutaActiva: ActivatedRoute,
    private productoService: ProductoService,
    private productoStockService: ProductStockService,
  ) { }

  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.bodegaService.get(nombre).subscribe((result) => {
      this.bodega = result;
      this.bodega != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
    this.obtenerProductosEnBodega();
  }
  private obtenerProductosEnBodega() {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.productoStockService.get(nombre).subscribe((result) => {
      this.productoEnBodegas = result;
      this.productoEnBodegas != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }
}
