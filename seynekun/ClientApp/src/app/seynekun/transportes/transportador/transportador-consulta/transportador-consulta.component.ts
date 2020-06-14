import { Component, OnInit } from '@angular/core';
import { Transportador } from 'src/app/seynekun/models/modelo-transportador/transportador';
import { TransportadorService } from 'src/app/servicios/servicio-transportador/transportador.service';

@Component({
  selector: 'app-transportador-consulta',
  templateUrl: './transportador-consulta.component.html',
  styleUrls: ['./transportador-consulta.component.css']
})
export class TransportadorConsultaComponent implements OnInit {
  
  transportadores: Transportador[] = [];
  textoABuscar: String;

  constructor(private transportadorService: TransportadorService) { }

  ngOnInit(): void {
    this.consultarTransportadadores();
  }

  private consultarTransportadadores(){
    this.transportadorService.gets().subscribe(result => {
      this.transportadores = result;
    });
  }
}
