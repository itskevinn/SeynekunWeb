import { Component, OnInit } from '@angular/core';
import { Control } from 'src/app/seynekun/models/modelo-control/control';
import { ControlService } from 'src/app/servicios/servicio-control/control.service';

@Component({
  selector: 'app-control-consulta',
  templateUrl: './control-consulta.component.html',
  styleUrls: ['./control-consulta.component.css']
})
export class ControlConsultaComponent implements OnInit {

  textoABuscar: String;
  controles: Control[] = [];
  
  constructor(private controlService: ControlService) { }

  ngOnInit(): void {
    this.buscarControles();
  }

  private buscarControles(){
    this.controlService.gets().subscribe((result) => {
      this.controles = result;
    });
  }
}
