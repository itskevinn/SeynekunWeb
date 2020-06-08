import { Component, OnInit } from "@angular/core";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { Categoria } from "src/app/seynekun/models/modelo-categoria/categoria";
import { CategoriaService } from "src/app/servicios/servicio-categoria/categoria.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-productos-categoria",
  templateUrl: "./productos-categoria.component.html",
  styleUrls: ["./productos-categoria.component.css"],
})
export class ProductosCategoriaComponent implements OnInit {
  categoria: Categoria;
  textoABuscar: string;
  productos: Producto[];
  seEncontro: boolean;
  constructor(
    private categoriaService: CategoriaService,
    private rutaActiva: ActivatedRoute
  ) { }
  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.categoriaService.get(nombre).subscribe((result) => {
      this.categoria = result;
      this.productos = this.categoria.productos;
      this.categoria != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }
}
