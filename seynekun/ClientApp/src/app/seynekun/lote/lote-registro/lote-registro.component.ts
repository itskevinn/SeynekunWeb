import { Component, OnInit } from '@angular/core';
import { Lote } from '../../models/lote';
import { LoteService } from 'src/app/servicios/lote.service';

@Component({
  selector: 'app-lote-registro',
  templateUrl: './lote-registro.component.html',
  styleUrls: ['./lote-registro.component.css']
})
export class LoteRegistroComponent implements OnInit {
  lote: Lote;
  constructor(private loteService: LoteService) { }

  ngOnInit(): void {
    this.lote = new Lote();
  }
  registrar() {
    this.loteService.post(this.lote).subscribe(l => {
      if (l != null) {
        alert('Lote registrado exitosamente');
        this.lote = l;
      }
    });
  }

}
