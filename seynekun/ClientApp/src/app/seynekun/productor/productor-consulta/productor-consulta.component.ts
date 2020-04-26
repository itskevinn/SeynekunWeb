import { Component, OnInit } from '@angular/core';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { Productor } from '../../models/modelo-productor/productor';

@Component({
  selector: 'app-productor-consulta',
  templateUrl: './productor-consulta.component.html',
  styleUrls: ['./productor-consulta.component.css']
})
export class ProductorConsultaComponent implements OnInit {
  productores: Productor[];
  productor: Productor;
  tieneDatos: Boolean = false;
  cantidadProductores: Number;
  textoABuscar: String;
  constructor(private productorService: ProductorService) { }

  ngOnInit(): void {        
    this.productorService.gets().subscribe(result => {
      this.productores = result;
      this.productores = [{
        nombreProductor: "Kevin",
        nombrePredio: "La Camita",
        apellidoProductor: "Pontón",
        numeroTelefono: "3213213214",
        cedulaCafetera: "1AB3",
        cedulaProductor: "119322",
        afiliacionSalud: "Sisben",
        codigoFinca: "K01P",
        codigoSica: "123Pnnt",
        municipio: "Valledupar",
        vereda: "Mareigua"
      },
      {
        nombreProductor: "Juan",
        nombrePredio: "La Casita",
        apellidoProductor: "Ortiz",
        numeroTelefono: "3222222222",
        cedulaCafetera: "1JO3",
        cedulaProductor: "Juank",
        afiliacionSalud: "Salud",
        codigoFinca: "J01O",
        codigoSica: "123Orrt",
        municipio: "Pueblo Bello",
        vereda: "Casco Urbano"
      }]
    });    
  }
  alDigitar(event: any) {
    this.validarTamañoLista();
    }
  validarTamañoLista() {
    if (this.productores.length == 0) {
      this.tieneDatos = false;
    }
    else this.tieneDatos = true;
  }
  contarProductores() {
    this.cantidadProductores = this.productores.length;
  }
}
