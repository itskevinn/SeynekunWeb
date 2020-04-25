import { Component, OnInit } from '@angular/core';
import { Empleado } from '../../models/empleado';

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
  constructor() { }

  ngOnInit(): void {
    
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
