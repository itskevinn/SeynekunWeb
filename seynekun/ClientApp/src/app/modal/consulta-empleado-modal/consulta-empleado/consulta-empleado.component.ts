import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from 'src/app/servicios/servicio-de-empleado/empleado.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Empleado } from 'src/app/seynekun/models/modelo-empleado/empleado';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';

@Component({
  selector: 'app-consulta-empleado',
  templateUrl: './consulta-empleado.component.html',
  styleUrls: ['./consulta-empleado.component.css']
})
export class ConsultaEmpleadoComponent implements OnInit {
  empleados: Empleado[]
  textoABuscar: string;
  constructor(private empleadoService: EmpleadoService, public activeModal: NgbActiveModal, private eventoService: EventoService) { }

  ngOnInit(): void {
    this.empleadoService.gets().subscribe((empleados) => this.empleados = empleados);
  }
  enviarId(id: string) {
    this.eventoService.cambiarCodigoEmpleado(id);
    console.log(id);
  }
}
