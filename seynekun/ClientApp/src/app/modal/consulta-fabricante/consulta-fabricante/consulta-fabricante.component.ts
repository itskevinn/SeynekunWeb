import { Component, OnInit } from '@angular/core';
import { FabricanteService } from 'src/app/servicios/servicio-fabricante/fabricante.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';
import { Fabricante } from 'src/app/seynekun/models/modelo-fabricante/fabricante';

@Component({
  selector: 'app-consulta-fabricante',
  templateUrl: './consulta-fabricante.component.html',
  styleUrls: ['./consulta-fabricante.component.css']
})
export class ConsultaFabricanteComponent implements OnInit {

  fabricantes: Fabricante[]
  textoABuscar: string;
  constructor(private fabricanteService: FabricanteService, public activeModal: NgbActiveModal, private eventoService: EventoService) { }

  ngOnInit(): void {
    this.fabricanteService.gets().subscribe((fabricantes) => this.fabricantes = fabricantes);
  }
  enviarId(id: string) {
    this.eventoService.cambiarIdFabricante(id);
    console.log(id);
  }
}
