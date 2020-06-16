import { Component, OnInit } from '@angular/core';
import { InsumoService } from 'src/app/servicios/servicio-insumo/insumo.service';
import { Insumo } from 'src/app/seynekun/models/modelo-insumo/insumo';

@Component({
  selector: 'app-insumo-consulta',
  templateUrl: './insumo-consulta.component.html',
  styleUrls: ['./insumo-consulta.component.css']
})
export class InsumoConsultaComponent implements OnInit {
  insumos: Insumo[];
  listaVacia: boolean = true;
  textoABuscar: String;
  constructor(private insumoService: InsumoService) { }

  ngOnInit(): void {
    this.insumoService.gets().subscribe((result) => {
      this.insumos = result;
    });
  }
}
