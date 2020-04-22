import { Component, OnInit } from '@angular/core';
import { Lote } from '../../models/modelo-lote/lote';
import { LoteService } from 'src/app/servicios/servicio-de-lote/lote.service';

@Component({
  selector: 'app-lote-consulta',
  templateUrl: './lote-consulta.component.html',
  styleUrls: ['./lote-consulta.component.css']
})
export class LoteConsultaComponent implements OnInit {
  lotes: Lote[];
  constructor(private loteService: LoteService) { }

  ngOnInit(): void {
    this.loteService.get().subscribe(result => {
      this.lotes = result;
    });
  }

}
