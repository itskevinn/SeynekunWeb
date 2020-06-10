import { Component, OnInit } from '@angular/core';
import { Venta } from 'src/app/seynekun/models/modelo-venta/venta';
import { VentaService } from 'src/app/servicios/servicio-venta/venta.service';

@Component({
  selector: 'app-venta-consulta',
  templateUrl: './venta-consulta.component.html',
  styleUrls: ['./venta-consulta.component.css']
})
export class VentaConsultaComponent implements OnInit {
  ventas: Venta[];
  listaVacia: Boolean = true;  
  textoABuscar: String;
  
  constructor(private ventaService: VentaService) { }

  ngOnInit(): void {
    this.ventaService.gets().subscribe((result) => {
      this.ventas = result;
    });
  }
}
