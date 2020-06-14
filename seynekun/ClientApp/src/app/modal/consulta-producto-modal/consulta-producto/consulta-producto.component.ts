import { Component, OnInit } from '@angular/core';
import { ProductoService } from 'src/app/servicios/servicio-producto/producto.service';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Producto } from 'src/app/seynekun/models/modelo-producto/producto';

@Component({
  selector: 'app-consulta-producto',
  templateUrl: './consulta-producto.component.html',
  styleUrls: ['./consulta-producto.component.css']
})
export class ConsultaProductoComponent implements OnInit {

  productos: Producto[];
  cliente: Producto;
  listaVacia: Boolean = true;
  cantidadproductos: Number;
  textoABuscar: String;
  constructor(private productoService: ProductoService, private eventoServicio: EventoService, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.productoService.gets().subscribe(result => {
      this.productos = result;
    });
  }
  enviarId(id: string) {
    this.eventoServicio.cambiarId(id);
    console.log(id)
  }
}
