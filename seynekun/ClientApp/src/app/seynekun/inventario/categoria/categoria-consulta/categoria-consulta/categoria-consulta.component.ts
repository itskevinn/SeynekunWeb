import { Component, OnInit } from '@angular/core';
import { CategoriaService } from 'src/app/servicios/servicio-categoria/categoria.service';
import { Categoria } from 'src/app/seynekun/models/modelo-categoria/categoria';

@Component({
  selector: "app-categoria-consulta",
  templateUrl: "./categoria-consulta.component.html",
  styleUrls: ["./categoria-consulta.component.css"],
})
export class CategoriaConsultaComponent implements OnInit {
  categorias: Categoria[];
  listaVacia: Boolean = true;  
  textoABuscar: String;
  constructor(private categoriaService: CategoriaService) {}

  ngOnInit(): void {
    this.categoriaService.gets().subscribe((result) => {
      this.categorias = result;
    });
  }
}
