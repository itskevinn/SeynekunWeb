import { Component, OnInit } from "@angular/core";
import { Empleado } from "../../models/modelo-empleado/empleado";
import { EmpleadoService } from "src/app/servicios/servicio-de-empleado/empleado.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-empleado-vista",
  templateUrl: "./empleado-vista.component.html",
  styleUrls: ["./empleado-vista.component.css"],
})
export class EmpleadoVistaComponent implements OnInit {
  empleado: Empleado;
  textoABuscar: string;
  seEncontro: Boolean;
  constructor(
    private empleadoService: EmpleadoService,
    private rutaActiva: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const identificacion = this.rutaActiva.snapshot.params.id;
    this.empleadoService.get(identificacion).subscribe((result) => {
      this.empleado = result;
      this.empleado != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }
}
