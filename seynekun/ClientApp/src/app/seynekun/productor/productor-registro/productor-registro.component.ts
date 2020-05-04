import { Component, OnInit } from '@angular/core'
import {
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from '@angular/forms'
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service'
import { Productor } from '../../models/modelo-productor/productor'
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component'

@Component({
  selector: 'app-productor-registro',
  templateUrl: './productor-registro.component.html',
  styleUrls: ['./productor-registro.component.css'],
})
export class ProductorRegistroComponent implements OnInit {
  productor: Productor
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
    private productorService: ProductorService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
  ) {}

  ngOnInit(): void {
    this.productor = new Productor()
    this.crearFormulario()
  }
  crearFormulario() {
    this.productor.nombre = ''
    this.productor.apellido = ''
    this.productor.identificacion = ''
    this.productor.nombrePredio = ''
    this.productor.codigoFinca = ''
    this.productor.codigoSica = ''
    this.productor.municipio = ''
    this.productor.vereda = ''
    this.productor.numeroTelefono = null
    this.productor.afiliacionSalud = ''
    this.productor.cedulaCafetera = ''
    this.productor.estado= ''
    this.formGroup = this.formBuilder.group({
      nombre: [this.productor.nombre, Validators.required],
      apellido: [this.productor.apellido, Validators.required],
      identificacion: [
        this.productor.identificacion,
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(11),
        ],
      ],
      estado: ['Activo'],
      cedulaCafetera: [this.productor.cedulaCafetera, Validators.required],
      nombrePredio: [this.productor.nombrePredio, Validators.required],
      codigoFinca: [this.productor.codigoFinca, Validators.required],
      codigoSica: [this.productor.codigoSica, Validators.required],
      municipio: [this.productor.municipio, Validators.required],
      vereda: [this.productor.vereda, Validators.required],
      numeroTelefono: [
        this.productor.numeroTelefono,
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
          this.validarNumeroTelefono,
        ],
      ],
      afiliacionSalud: [this.productor.afiliacionSalud, Validators.required],
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
      const messageBox = this.modalService.open(AlertaModalErrorComponent)
      messageBox.componentInstance.titulo = 'Ha ocurrido un error'
      messageBox.componentInstance.mensaje = 'Aún faltan datos por llenar'
    } else {
      this.registrar()
    }
  }
  get control() {
    return this.formGroup.controls
  }
  registrar() {
    this.productor = this.formGroup.value
    this.productor.estado = "Activo"
    this.productorService.post(this.productor).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertaModalOkComponent)
        messageBox.componentInstance.titulo = 'Productor Registrado'
        this.productor = p        
        this.formGroup.reset()
      } else {
        const messageBox = this.modalService.open(AlertaModalErrorComponent)
        messageBox.componentInstance.titulo = 'Ha ocurrido un error'
        messageBox.componentInstance.mensaje =
          'No se ha podido registrar al productor'
      }
    })
  }
}
