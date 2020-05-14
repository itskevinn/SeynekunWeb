import { Component, OnInit } from '@angular/core';
import { FabricanteService } from 'src/app/servicios/servicio-fabricante/fabricante.service';
import { Fabricante } from 'src/app/seynekun/models/modelo-fabricante/fabricante';

@Component({
  selector: 'app-fabricante-consulta',
  templateUrl: './fabricante-consulta.component.html',
  styleUrls: ['./fabricante-consulta.component.css']
})
export class FabricanteConsultaComponent implements OnInit {

  fabricantes: Fabricante[];
  fabricante: Fabricante;
  listaVacia: Boolean = true;
  cantidadFabricantes: Number;
  textoABuscar: String;
  constructor(private fabricanteService: FabricanteService) { }

  ngOnInit(): void {
    this.fabricanteService.gets().subscribe(result => {
      this.fabricantes = result;   
    });
  }

  validarTamañoLista() {
    if (this.fabricantes.length == 0) {
      this.listaVacia == true;
    }
    else this.listaVacia == false;
  }

  contarFabricantes() {
    this.cantidadFabricantes = this.fabricantes.length;
  }
}
