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
      this.empleados = [{
        nombre: "Kevin",
        apellido: "Pontón",
        numeroTelefono: "3213213214",
        cedula: "119322",
        email: "keviinpn2@gmail.com",
        estado: "Activo",
        cargo: "Auxiliar de Planta"
      },
      {
        nombre: "Moises",
        apellido: "Villadiegos",
        numeroTelefono: "3223213214",
        cedula: "0999",
        email: "moises@gmail.com",
        estado: "Inhabilitado",
        cargo: "Secretario"
      }]
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
