import { Component, OnInit } from '@angular/core';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';
import { MateriaPrimaService } from 'src/app/servicios/servicio-materia/materia-prima.service';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { ActivatedRoute } from '@angular/router';
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor';

@Component({
  selector: 'app-materia-prima-productor',
  templateUrl: './materia-prima-productor.component.html',
  styleUrls: ['./materia-prima-productor.component.css']
})
export class MateriaPrimaProductorComponent implements OnInit {
  productor: Productor;
  materiaPrimas: MateriaPrima[];
  listaVacia: boolean = true;
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private materiaPrimaService: MateriaPrimaService, private productorService: ProductorService, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.rutaActiva.snapshot.params.id;
    this.productorService.get(id).subscribe((result) => {
      this.productor = result;
    })
    this.materiaPrimaService.gets().subscribe((result) => {
      this.materiaPrimas = result;
    });
    this
  }
}
