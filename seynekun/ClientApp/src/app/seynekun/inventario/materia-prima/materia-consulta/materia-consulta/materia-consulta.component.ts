import { Component, OnInit } from '@angular/core';
import { MateriaPrimaService } from 'src/app/servicios/servicio-materia/materia-prima.service';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';

@Component({
  selector: 'app-materia-consulta',
  templateUrl: './materia-consulta.component.html',
  styleUrls: ['./materia-consulta.component.css']
})
export class MateriaConsultaComponent implements OnInit {

  materiaPrimas: MateriaPrima[];
  listaVacia: boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private materiaPrimaService: MateriaPrimaService) { }

  ngOnInit(): void {
    this.materiaPrimaService.gets().subscribe((result) => {
      this.materiaPrimas = result;
    });
  }

}
