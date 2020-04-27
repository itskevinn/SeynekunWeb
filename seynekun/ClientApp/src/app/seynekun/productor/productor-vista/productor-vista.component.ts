import { Component, OnInit } from '@angular/core';
import { Productor } from '../../models/modelo-productor/productor';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productor-vista',
  templateUrl: './productor-vista.component.html',
  styleUrls: ['./productor-vista.component.css']
})
export class ProductorVistaComponent implements OnInit {
  productor: Productor;
  textoABuscar: string;
  seEncontro: Boolean;
  constructor(private productorService: ProductorService, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    const identificacion = this.rutaActiva.snapshot.params.id;
    this.productorService.get(identificacion).subscribe(result => {
      this.productor = result;
      this.productor != null ? this.seEncontro = true : this.seEncontro = false;
    });
  }
}
