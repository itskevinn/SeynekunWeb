import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/seynekun/models/modelo-categoria/categoria';
import { CategoriaService } from 'src/app/servicios/servicio-categoria/categoria.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: "app-categoria-vista",
  templateUrl: "./categoria-vista.component.html",
  styleUrls: ["./categoria-vista.component.css"],
})
export class CategoriaVistaComponent implements OnInit {
  categoria: Categoria;
  textoABuscar: string;
  seEncontro: boolean;
  constructor(
    private categoriaService: CategoriaService,
    private rutaActiva: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.categoriaService.get(nombre).subscribe((result) => {
      this.categoria = result;
      this.categoria != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }
}
