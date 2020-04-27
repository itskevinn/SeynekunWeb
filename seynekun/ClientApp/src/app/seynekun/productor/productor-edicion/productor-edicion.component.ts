import { Component, OnInit } from '@angular/core';
import { Productor } from '../../models/modelo-productor/productor';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productor-edicion',
  templateUrl: './productor-edicion.component.html',
  styleUrls: ['./productor-edicion.component.css']
})
export class ProductorEdicionComponent implements OnInit {
  identificacion = this.rutaActiva.snapshot.params.id;
  productor: Productor;
  municipios: string[] = ["Pueblo Bello", "Codazzi"];
  veredas: string[] = ["Jewrwa", "Jwidedy", "Morotrwa", "Seyumake", "Kankanachama", "Kurinha", "Zikuta", "Guacamayal", "Casco Urbano", "Cuesta Plata", "Los Antiguos", "La Florida", "Nabusimake", "Mañakan", "Kochokwa", "Windiwa", "Morotrwa", "Businchama", "Sombrero Cava", "Alto Cicarare", "La Libertad", "Wabini", "Berlin 1", "Gamake", "El Hondo", "Simonorwa", "Marquetalia", "Rincon", "Tranquilidad"];
  formGroup: FormGroup;
  botonPresionado: boolean = false;
  seEncontro: boolean;
  constructor(private productorService: ProductorService, private formBuilder: FormBuilder, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    this.productor = new Productor();
    this.crearFormulario();
    this.buscar();
    this.formGroup.setValue(this.productor);
  }
  buscar() {
    this.productorService.get(this.identificacion).subscribe(result => {
      this.productor = result;
      this.productor != null ? this.seEncontro = true : this.seEncontro = false;      
    }); 
  }
  validarMensaje() {
    this.botonPresionado = true;
  }
  crearFormulario() {
    this.formGroup = this.formBuilder.group({
      nombre: [this.productor.nombre, Validators.required],
      apellido: [this.productor.apellido, Validators.required],
      cedula: [this.productor.cedula, [Validators.required, Validators.minLength(6), Validators.maxLength(11)]],
      cedulaCafetera: [this.productor.cedulaCafetera, Validators.required],
      nombrePredio: [this.productor.nombrePredio, Validators.required],
      codigoFinca: [this.productor.codigoFinca, Validators.required],
      codigoSica: [this.productor.codigoSica, Validators.required],
      municipio: [this.productor.municipio, Validators.required],
      vereda: [this.productor.vereda, Validators.required],
      numeroTelefono: [this.productor.numeroTelefono, [Validators.required, Validators.minLength(10), Validators.maxLength(10), this.validarNumeroTelefono]],
      afiliacionSalud: [this.productor.afiliacionSalud, Validators.required],
    });
  }


  private resetearBoton() {
    let seReseteó;
    this.botonPresionado = false;
    return seReseteó = true;
  }


  private validarNumeroTelefono(control: AbstractControl) {
    const numero = control.value;
    var numeroString;
    var numeroChar = [];
    var esNumero = false;
    numeroString = String(numero);
    var esNumero = false;
    var number;
    try {
      number = Number(numero);
      esNumero = true;
    } catch (error) {
      esNumero = false;
    }
    numeroChar = numeroString.split('');
    console.log(numeroChar[0]);
    try {
      Number(numero);
      esNumero = true;
    } catch (error) {
      esNumero = false;
    }
    if (numeroChar.length != 0) {
      if (esNumero) {
        if (numeroChar[0] != '3') {
          return {
            validaNumeroTelefono: true, mensajeNumero: 'Número teléfono no válido'
          };
        }
        return null;
      }
      return {
        validaNumeroTelefono: true, mensajeNumero: 'Número teléfono no válido'
      };
    }
  }
  cambiarMunicipio(e) {
    this.control.municipio.setValue(e.target.value, {
      onlySelf: true
    })
    console.log(this.control.municipio.value);
  }
  cambiarVereda(e) {
    this.control.vereda.setValue(e.target.value, {
      onlySelf: true
    })
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return null;
    }
    this.actualizar();
  }
  get control() {
    return this.formGroup.controls;
  }
  actualizar() {
    this.productor = this.formGroup.value;
    //this.productorService.put(this.identificacion, this.productor).subscribe(p => {
    // if (p != null) {
    // this.productor = p;
    //}
    //});
  }
}
