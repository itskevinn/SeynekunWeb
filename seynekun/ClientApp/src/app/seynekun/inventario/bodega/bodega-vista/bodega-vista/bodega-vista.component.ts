import { Component, OnInit } from "@angular/core";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { ActivatedRoute } from "@angular/router";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";

@Component({
  selector: "app-bodega-vista",
  templateUrl: "./bodega-vista.component.html",
  styleUrls: ["./bodega-vista.component.css"],
})
export class BodegaVistaComponent implements OnInit {
  bodega: Bodega;
  textoABuscar: string;
  seEncontro: Boolean;
  constructor(
    private bodegaService: BodegaService,
    private rutaActiva: ActivatedRoute  
  ) {}

  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.bodegaService.get(nombre).subscribe((result) => {
      this.bodega = result;
      this.bodega != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }
}
