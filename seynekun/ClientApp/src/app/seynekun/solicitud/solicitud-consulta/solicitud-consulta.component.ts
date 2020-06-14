import { Component, OnInit } from '@angular/core';
import { Productor } from '../../models/modelo-productor/productor';
import { SolicitudService } from 'src/app/servicios/servicio-solicitud/solicitud.service';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { AlertaModalPreguntaComponent } from 'src/app/@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ObservadorSolicitudService } from 'src/app/servicios/observador-solicitud.service';

@Component({
  selector: 'app-solicitud-consulta',
  templateUrl: './solicitud-consulta.component.html',
  styleUrls: ['./solicitud-consulta.component.css']
})
export class SolicitudConsultaComponent implements OnInit {
  productores: Productor[];
  textoABuscar: String;
  estado: boolean
  productor: Productor;
  constructor(private solicitudService: SolicitudService, private productorService: ProductorService, private modalService: NgbModal, private observadorSolicitud: ObservadorSolicitudService) { }

  ngOnInit(): void {
    this.actualizarLista();
  }
  actualizarLista() {
    this.solicitudService.gets().subscribe(result => {
      this.productores = result;
    });
  }
  aceptarSolicitud(productor: Productor) {
    const estado = "Activo";
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent)
    messageBox.componentInstance.titulo =
      '¿Desea aceptar este productor?'
    messageBox.result.then((result) => {
      if (result) {
        this.productorService.putEstado(productor.identificacion, estado).subscribe(result => this.productor = result);
        this.actualizarLista();
      }
    })
  }
  rechazarSolicitud(productor: Productor) {
    const estado = "Rechazado";
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent)
    messageBox.componentInstance.titulo =
      '¿Desea rechazar este productor?'
    messageBox.result.then((result) => {
      if (result) {
        this.productorService.putEstado(productor.identificacion, estado).subscribe(result => this.productor = result);
        this.actualizarLista();
      }
    })
  }
}
