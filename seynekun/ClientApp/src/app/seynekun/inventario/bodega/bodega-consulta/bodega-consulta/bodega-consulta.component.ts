import { Component, OnInit } from "@angular/core";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";

@Component({
  selector: "app-bodega-consulta",
  templateUrl: "./bodega-consulta.component.html",
  styleUrls: ["./bodega-consulta.component.css"],
})
export class BodegaConsultaComponent implements OnInit {
  bodegas: Bodega[];  
  listaVacia: Boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private bodegaService: BodegaService) {}

  ngOnInit(): void {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
    });
  } 
}
