import { Component, OnInit } from '@angular/core';
import { ReporteService } from 'src/app/servicios/servicio-reporte/reporte.service';

@Component({
  selector: 'app-reporte-inventario',
  templateUrl: './reporte-inventario.component.html',
  styleUrls: ['./reporte-inventario.component.css']
})
export class ReporteInventarioComponent implements OnInit {
  tipos: string[] = [
    'Reporte de empleados',
    'Reporte de clientes',
    'Reporte de productores'
  ];

  tipo: string;
  constructor(private reporteService: ReporteService) { }

  ngOnInit(): void {

  }

  cambiarTipo(e){
    this.tipo = e.target.value;
  }

  generarReporte(){
    this.reporteService.post(this.tipo).subscribe((t) => {
     this.tipo = t;
    });
  }
}
