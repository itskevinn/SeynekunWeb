import { Component, OnInit } from '@angular/core';
import { Transportador } from 'src/app/seynekun/models/modelo-transportador/transportador';
import { TransportadorService } from 'src/app/servicios/servicio-transportador/transportador.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-transportador-vista',
  templateUrl: './transportador-vista.component.html',
  styleUrls: ['./transportador-vista.component.css']
})
export class TransportadorVistaComponent implements OnInit {

  seEncontro: Boolean;
  transportador: Transportador;

  constructor(
    private transportadorService: TransportadorService,
    private rutaActiva: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.buscarTransportador();
  }

  private buscarTransportador(){
    const identificacion = this.rutaActiva.snapshot.params.id
    this.transportadorService.get(identificacion).subscribe((result) => {
      this.transportador = result
      this.transportador != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false)
    })
  }
}
