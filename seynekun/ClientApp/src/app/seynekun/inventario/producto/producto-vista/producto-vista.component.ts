import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { BodegaProducto } from "src/app/seynekun/models/modelo-bodega-producto/bodega-producto";
import { BodegaStockService } from "src/app/servicios/servicio-bodega-stock/bodega-stock.service";

@Component({
  selector: "app-producto-vista",
  templateUrl: "./producto-vista.component.html",
  styleUrls: ["./producto-vista.component.css"],
})
export class ProductoVistaComponent implements OnInit {
  producto: Producto;
  seEncontro: Boolean;
  textoABuscar: string;
  bodegaStocks: BodegaProducto[];
  constructor(
    private productoService: ProductoService,
    private rutaActiva: ActivatedRoute,
    private bodegaSockService: BodegaStockService,
  ) { }

  ngOnInit(): void {
    const codigo = this.rutaActiva.snapshot.params.id;
    this.productoService.get(codigo).subscribe((result) => {
      this.producto = result;
      this.producto != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
    this.bodegaSockService.get(codigo).subscribe((resutlt) => {
      this.bodegaStocks = resutlt;
    })
  }
}
