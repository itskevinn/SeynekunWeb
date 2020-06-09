import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-insumo-consulta',
  templateUrl: './insumo-consulta.component.html',
  styleUrls: ['./insumo-consulta.component.css']
})
export class InsumoConsultaComponent implements OnInit {
  textoABuscar: string;
  constructor() { }

  ngOnInit(): void {
  }

}
