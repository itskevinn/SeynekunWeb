import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { Productor } from '../../models/modelo-productor/productor';

@Component({
  selector: 'app-productor-registro',
  templateUrl: './productor-registro.component.html',
  styleUrls: ['./productor-registro.component.css']
})
export class ProductorRegistroComponent implements OnInit {
  productor: Productor;
  municipios: string[] = ["Pueblo Bello", "Codazzi"];
  veredas: string[] = ["Jewrwa", "Jwidedy", "Morotrwa", "Seyumake", "Kankanachama", "Kurinha", "Zikuta", "Guacamayal", "Casco Urbano", "Cuesta Plata", "Los Antiguos", "La Florida", "Nabusimake", "Mañakan", "Kochokwa", "Windiwa", "Morotrwa", "Businchama", "Sombrero Cava", "Alto Cicarare", "La Libertad", "Wabini", "Berlin 1", "Gamake", "El Hondo", "Simonorwa", "Marquetalia", "Rincon", "Tranquilidad"];
  formGroup: FormGroup;
  constructor(private ProductorService: ProductorService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.productor = new Productor();
    this.crearFormulario();
  }
  crearFormulario() {
    this.productor.nombreProductor = "";
    this.productor.apellidoProductor = "";
    this.productor.cedulaProductor = null;
    this.productor.nombrePredio = "";
    this.productor.codigoFinca = "";
    this.productor.codigoSica = "";
    this.productor.municipio = "";
    this.productor.vereda = "";
    this.productor.numeroTelefono = null;
    this.productor.afiliacionSalud = "";
    this.productor.cedulaCafetera = "";
    this.formGroup = this.formBuilder.group({
      nombreProductor: [this.productor.nombreProductor, Validators.required],
      apellidoProductor: [this.productor.apellidoProductor, Validators.required],
      cedulaProductor: [this.productor.cedulaProductor, Validators.required],
      cedulaCafetera: [this.productor.cedulaCafetera, Validators.required],
      nombrePredio: [this.productor.nombrePredio, Validators.required],
      codigoFinca: [this.productor.codigoFinca, Validators.required],
      codigoSica: [this.productor.codigoSica, Validators.required],
      municipio: [this.productor.municipio, Validators.required],
      vereda: [this.productor.vereda, Validators.required],
      numeroTelefono: [this.productor.numeroTelefono, Validators.required],
      afiliacionSalud: [this.productor.afiliacionSalud, Validators.required]
    });
  }
  validar() {
    if (!this.formGroup.invalid) {
      this.registrar();
    }
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.productor = this.formGroup.value;
    this.ProductorService.post(this.productor).subscribe(l => {
      if (l != null) {
        alert('Productor registrado exitosamente');
        this.productor = l;
      }
    });
  }
}
