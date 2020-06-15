import { Component, OnInit } from '@angular/core';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';
import { BodegaService } from 'src/app/servicios/servicio-bodega/bodega.service';
import { Bodega } from 'src/app/seynekun/models/modelo-bodega/bodega';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-consulta-bodega',
  templateUrl: './consulta-bodega.component.html',
  styleUrls: ['./consulta-bodega.component.css']
})
export class ConsultaBodegaComponent implements OnInit {
  bodegas: Bodega[]
textoABuscar: string
  constructor(private eventoServicio: EventoService, private bodegaService: BodegaService, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.bodegaService.gets().subscribe(result => {
      this.bodegas = result;
    });
  }
  enviarId(id: string) {
    this.bodegaService.cambiarNombreBodega(id);
    console.log(id)
  }
}
