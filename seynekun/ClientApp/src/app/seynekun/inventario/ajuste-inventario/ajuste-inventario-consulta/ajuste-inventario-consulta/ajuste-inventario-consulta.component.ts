import { Component, OnInit } from "@angular/core";
import { AjusteDeInventario } from "src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario";
import { AjusteInventarioService } from "src/app/servicios/servicio-ajuste/ajuste-inventario.service";

@Component({
  selector: "app-ajuste-inventario-consulta",
  templateUrl: "./ajuste-inventario-consulta.component.html",
  styleUrls: ["./ajuste-inventario-consulta.component.css"],
})
export class AjusteInventarioConsultaComponent implements OnInit {
  ajusteInventarios: AjusteDeInventario[];
  listaVacia: boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private ajusteInventarioService: AjusteInventarioService) {}

  ngOnInit(): void {
    this.ajusteInventarioService.gets().subscribe((result) => {
      this.ajusteInventarios = result;
    });
  }
}
