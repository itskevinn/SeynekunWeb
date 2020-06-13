import { Component, OnInit } from '@angular/core';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';

@Component({
  selector: 'app-consulta-productor',
  templateUrl: './consulta-productor.component.html',
  styleUrls: ['./consulta-productor.component.css']
})
export class ConsultaProductorComponent implements OnInit {
  productores: Productor[];
  cantidadProductores: Number;
  textoABuscar: String;
  id: string;
  constructor(private productorService: ProductorService, public activeModal: NgbActiveModal, private eventoServicio: EventoService) { }

  ngOnInit(): void {
    this.productorService.gets().subscribe(result => {
      this.productores = result;
    });
  }
  enviarId(id: string) {
    this.eventoServicio.cambiarId(id);
    console.log(id)
  }
}
