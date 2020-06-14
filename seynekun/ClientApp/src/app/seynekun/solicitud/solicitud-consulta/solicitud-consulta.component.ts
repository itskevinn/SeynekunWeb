import { Component, OnInit } from '@angular/core';
import { Productor } from '../../models/modelo-productor/productor';
import { SolicitudService } from 'src/app/servicios/servicio-solicitud/solicitud.service';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';

@Component({
  selector: 'app-solicitud-consulta',
  templateUrl: './solicitud-consulta.component.html',
  styleUrls: ['./solicitud-consulta.component.css']
})
export class SolicitudConsultaComponent implements OnInit {
  productores: Productor[];
  textoABuscar: String;
  productor: Productor;
  constructor(private solicitudService: SolicitudService, private productorService: ProductorService) { }

  ngOnInit(): void {
    this.solicitudService.gets().subscribe(result => {
      this.productores = result;
    });
  }
  aceptarSolicitud(id: string, productor: Productor) {
    console.log(id);
    this.productorService.putEstado(id, productor).subscribe(result => this.productor = result);
  }
  rechazarSolicitud(id: string, productor: Productor) {
    this.productorService.putEstado(id, productor).subscribe(result => this.productor = result);
  }
}
