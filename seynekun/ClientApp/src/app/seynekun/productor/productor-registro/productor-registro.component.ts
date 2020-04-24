import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
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
  botonPresionado: Boolean = false;
  constructor(private ProductorService: ProductorService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.productor = new Productor();
    this.crearFormulario();
  }
  validarMensaje() {
    this.botonPresionado = true;
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
      cedulaProductor: [this.productor.cedulaProductor, [Validators.required, Validators.minLength(6), Validators.maxLength(11), this.validarNumeroCedula]],
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

  private validarNumeroCedula(control: AbstractControl) {
    const numero = control.value;
    var esNumero = false;
    var number;
    try {
      number = parseInt(numero);
      esNumero = true;
    } catch (error) {
      esNumero = false;
    }
    if (esNumero) {
      return null;
    } else return {
      validaNumeroCedula: true, mensajeNumero: 'Número cédula no válido'
    }
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
    this.registrar();    
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.productor = this.formGroup.value;
    this.ProductorService.post(this.productor).subscribe(p => {
      if (p != null) {
        this.productor = p;
      }
    });
  }
}
