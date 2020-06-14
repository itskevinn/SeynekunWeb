import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, AbstractControl } from '@angular/forms';
import { Categoria } from 'src/app/seynekun/models/modelo-categoria/categoria';
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component';
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component';
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service';
import { Usuario } from 'src/app/seynekun/models/modelo-usuario/usuario';
import { SolicitudService } from 'src/app/servicios/servicio-solicitud/solicitud.service';

@Component({
  selector: 'app-solicitud-registro',
  templateUrl: './solicitud-registro.component.html',
  styleUrls: ['./solicitud-registro.component.css']
})
export class SolicitudRegistroComponent implements OnInit {
  productor: Productor
  usuario: Usuario
  tipoIdentificaciones: string[] = ['CC', 'TI', 'RC']
  municipios: string[] = ['Pueblo Bello', 'Codazzi']
  veredas: string[] = [
    'Jewrwa',
    'Jwidedy',
    'Morotrwa',
    'Seyumake',
    'Kankanachama',
    'Kurinha',
    'Zikuta',
    'Guacamayal',
    'Casco Urbano',
    'Cuesta Plata',
    'Los Antiguos',
    'La Florida',
    'Nabusimake',
    'Mañakan',
    'Kochokwa',
    'Windiwa',
    'Morotrwa',
    'Businchama',
    'Sombrero Cava',
    'Alto Cicarare',
    'La Libertad',
    'Wabini',
    'Berlin 1',
    'Gamake',
    'El Hondo',
    'Simonorwa',
    'Marquetalia',
    'Rincon',
    'Tranquilidad',
  ]
  formGroup: FormGroup
  constructor(
    private solicitudService: SolicitudService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
  ) { }

  ngOnInit(): void {
    this.productor = new Productor()
    this.crearFormulario()
  }

  crearFormulario() {
    this.productor.tipoIdentificacion = ''
    this.productor.identificacion = ''
    this.productor.nombre = ''
    this.productor.apellido = ''
    this.productor.numeroTelefono = ''
    this.productor.email = ''
    this.productor.nombrePredio = ''
    this.productor.codigoFinca = ''
    this.productor.codigoSica = ''
    this.productor.municipio = ''
    this.productor.vereda = ''
    this.productor.afiliacionSalud = ''
    this.productor.cedulaCafetera = ''
    this.productor.contrasena = ''
    this.productor.nombreUsuario = ''
    this.productor.estado = 'Pendiente';
    this.formGroup = this.formBuilder.group({
      tipoIdentificacion: [this.productor.tipoIdentificacion, Validators.required],
      nombre: [this.productor.nombre, Validators.required],
      email: [this.productor.email, Validators.email],
      apellido: [this.productor.apellido, Validators.required],
      identificacion: [
        this.productor.identificacion,
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(11),
        ],
      ],
      cedulaCafetera: [this.productor.cedulaCafetera, Validators.required],
      nombrePredio: [this.productor.nombrePredio, Validators.required],
      codigoFinca: [this.productor.codigoFinca, Validators.required],
      codigoSica: [this.productor.codigoSica, Validators.required],
      municipio: [this.productor.municipio, Validators.required],
      vereda: [this.productor.vereda, Validators.required],
      numeroTelefono: [
        this.productor.numeroTelefono,
        [
          Validators.minLength(10),
          Validators.maxLength(10),
          this.validarNumeroTelefono,
        ],
      ],
      contrasena: [this.productor.contrasena, [Validators.required, Validators.minLength(4)]],
      nombreUsuario: [this.productor.nombreUsuario, [Validators.required, Validators.maxLength(35)]],
      afiliacionSalud: [this.productor.afiliacionSalud],
      estado:[this.productor.estado]
    })
  }

  private validarNumeroTelefono(control: AbstractControl) {
    const numero = control.value
    var numeroString
    var numeroChar = []
    var esNumero = false
    numeroString = String(numero)
    var esNumero = false
    var number
    try {
      number = Number(numero)
      esNumero = true
    } catch (error) {
      esNumero = false
    }
    numeroChar = numeroString.split('')
    console.log(numeroChar[0])
    try {
      Number(numero)
      esNumero = true
    } catch (error) {
      esNumero = false
    }
    if (numeroChar.length != 0) {
      if (esNumero) {
        if (numeroChar[0] != '3') {
          return {
            validaNumeroTelefono: true,
            mensajeNumero: 'Número teléfono no válido',
          }
        }
        return null
      }
      return {
        validaNumeroTelefono: true,
        mensajeNumero: 'Número teléfono no válido',
      }
    }
  }

  cambiarTipoIdentificaciones(e) {
    this.control.tipoIdentificacion.setValue(e.target.value, {
      onlySelf: true,
    })
    console.log(this.control.tipoIdentificacion.value)
  }

  cambiarMunicipio(e) {
    this.control.municipio.setValue(e.target.value, {
      onlySelf: true,
    })
    console.log(this.control.municipio.value)
  }

  cambiarVereda(e) {
    this.control.vereda.setValue(e.target.value, {
      onlySelf: true,
    })
  }

  onSubmit() {
    if (this.formGroup.invalid) {
    } else {
      sessionStorage.clear()
      this.registrar()
    }
  }

  get control() {
    return this.formGroup.controls
  }

  registrar() {
    this.productor = this.formGroup.value
    this.solicitudService.post(this.productor).subscribe((p) => {
      if (p != null) {
        this.productor = p
        this.formGroup.reset()
      }
    })
  }
}
