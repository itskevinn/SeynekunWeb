import { Component, OnInit } from '@angular/core';
import { Lote } from '../../models/modelo-lote/lote';


@Component({
  selector: 'app-lote-consulta',
  templateUrl: './lote-consulta.component.html',
  styleUrls: ['./lote-consulta.component.css']
})
export class LoteConsultaComponent implements OnInit {
  lotes: Lote[];
  constructor() { }

  ngOnInit(): void {
  /*  this.loteService.get().subscribe(result => {
      this.lotes = result;
    });*/
  }
}
