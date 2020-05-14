import { Component, OnInit } from '@angular/core';
import { Empleado } from '../../models/modelo-empleado/empleado';
import { EmpleadoService } from 'src/app/servicios/servicio-de-empleado/empleado.service';


@Component({
  selector: 'app-empleado-consulta',
  templateUrl: './empleado-consulta.component.html',
  styleUrls: ['./empleado-consulta.component.css']
})
export class EmpleadoConsultaComponent implements OnInit {
  empleados: Empleado[];
  empleado: Empleado;
  listaVacia: Boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private empleadoService : EmpleadoService) { }

  ngOnInit(): void {
    this.empleadoService.gets().subscribe(result => {
      this.empleados = result;
    });
  }
  validarTamañoLista() {
    if (this.empleados.length == 0) {
      this.listaVacia == true;
    }
    else this.listaVacia == false;
  }
  contarEmpleados() {
    this.cantidadEmpleados = this.empleados.length;
  }
}
