import { Component, OnInit } from '@angular/core';
import { ProductoEnBodega } from 'src/app/seynekun/models/modelo-producto-bodega/producto-en-bodega';
import { ProductoService } from 'src/app/servicios/servicio-producto/producto.service';
import { MateriaPrimaService } from 'src/app/servicios/servicio-materia/materia-prima.service';
import { ActivatedRoute } from '@angular/router';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';
import { ProductStockService } from 'src/app/servicios/servicio-producto-stock/producto-stock.service';

@Component({
  selector: 'app-productos-materia-productor',
  templateUrl: './productos-materia-productor.component.html',
  styleUrls: ['./productos-materia-productor.component.css']
})
export class ProductosMateriaProductorComponent implements OnInit {
  productos: ProductoEnBodega[];
  listaVacia: Boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  materia: MateriaPrima;
  constructor(private productoStockService: ProductStockService, private materiaService: MateriaPrimaService, private rutaActiva: ActivatedRoute) { }
  ngOnInit(): void {
    const id = this.rutaActiva.snapshot.params.id;
    this.productoStockService.getProductosxMateria(id).subscribe((result) => {
      this.productos = result;
    });
    this.materiaService.getInfo(id).subscribe((result) => { this.materia = result; })
  }

}
