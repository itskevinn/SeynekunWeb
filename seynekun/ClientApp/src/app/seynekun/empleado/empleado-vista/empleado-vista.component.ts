import { Component, OnInit } from '@angular/core';
import { Empleado } from '../../models/modelo-empleado/empleado';
import { EmpleadoService } from 'src/app/servicios/servicio-de-empleado/empleado.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-empleado-vista',
  templateUrl: './empleado-vista.component.html',
  styleUrls: ['./empleado-vista.component.css']
})
export class EmpleadoVistaComponent implements OnInit {
  empleados: Empleado[];
  empleado: Empleado;
  textoABuscar: string;
  seEncontro: Boolean;
  constructor(private empleadoService: EmpleadoService, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    const identificacion = this.rutaActiva.snapshot.params.id;
    //this.empleadoService.get(identificacion).subscribe(result => {
    // this.empleado = result;
    //this.empleado != null ? this.seEncontro = true : this.seEncontro = false;
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
    this.empleados.forEach(e => {
      if(e.cedula == identificacion)
      this.empleado = e;
      this.seEncontro= true;
    });
  };
}
