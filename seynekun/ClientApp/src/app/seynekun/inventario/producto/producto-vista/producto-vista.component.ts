import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";

@Component({
  selector: "app-producto-vista",
  templateUrl: "./producto-vista.component.html",
  styleUrls: ["./producto-vista.component.css"],
})
export class ProductoVistaComponent implements OnInit {
  producto: Producto;
  seEncontro: Boolean;
  constructor(
    private productoService: ProductoService,
    private rutaActiva: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.productoService.get(nombre).subscribe((result) => {
      this.producto = result;
      this.producto != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }
}
