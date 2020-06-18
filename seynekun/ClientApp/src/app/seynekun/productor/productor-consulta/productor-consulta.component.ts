import { Component, OnInit } from '@angular/core';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { Productor } from '../../models/modelo-productor/productor';
import { SolicitudService } from 'src/app/servicios/servicio-solicitud/solicitud.service';

@Component({
  selector: 'app-productor-consulta',
  templateUrl: './productor-consulta.component.html',
  styleUrls: ['./productor-consulta.component.css']
})
export class ProductorConsultaComponent implements OnInit {
  productores: Productor[];
  productor: Productor;  
  cantidadProductores: Number;
  textoABuscar: String;
  constructor(private productorService: ProductorService,
    private solicitudService: SolicitudService) { }

  ngOnInit(): void {        
    this.productorService.gets().subscribe(result => {
      this.productores = result;
    });         
    this.actualizarListaSignal();
  }

  private actualizarListaSignal(){
    this.solicitudService.signalRecived.subscribe((productores) => {
      this.productores = productores;
    });
  }
}
