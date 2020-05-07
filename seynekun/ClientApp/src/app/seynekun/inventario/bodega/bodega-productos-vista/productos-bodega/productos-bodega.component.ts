import { Component, OnInit } from '@angular/core';
import { Bodega } from 'src/app/seynekun/models/modelo-bodega/bodega';
import { Producto } from 'src/app/seynekun/models/modelo-producto/producto';
import { BodegaService } from 'src/app/servicios/servicio-bodega/bodega.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productos-bodega',
  templateUrl: './productos-bodega.component.html',
  styleUrls: ['./productos-bodega.component.css']
})
export class ProductosBodegaComponent implements OnInit {
bodega: Bodega;
  textoABuscar: string;
  productos: Producto[];
  seEncontro: boolean;
  constructor(
    private bodegaService: BodegaService,
    private rutaActiva: ActivatedRoute
  ) {}
  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.bodegaService.get(nombre).subscribe((result) => {
      this.bodega = result;
      this.productos = this.bodega.productos;
      this.bodega != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });    
  }

}
