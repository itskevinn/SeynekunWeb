import { Component, OnInit } from '@angular/core'
import { Productor } from '../../models/modelo-productor/productor'
import {
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from '@angular/forms'
import { ProductorService } from 'src/app/servicios/servicio-de-productor/productor.service'
import { ActivatedRoute } from '@angular/router'
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component'
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { AlertaModalPreguntaComponent } from 'src/app/@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component'

@Component({
  selector: 'app-productor-edicion',
  templateUrl: './productor-edicion.component.html',
  styleUrls: ['./productor-edicion.component.css'],
})
export class ProductorEdicionComponent implements OnInit {
  identificacion = this.rutaActiva.snapshot.params.id
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
  seEncontro: boolean
  constructor(
    private productorService: ProductorService,
    private formBuilder: FormBuilder,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal,
  ) { }

  ngOnInit(): void {
    this.productor = new Productor()
    this.crearFormulario()
    this.buscar()
    this.asignarValores()
  }

  buscar() {
    this.productorService.get(this.identificacion).subscribe((result) => {
      this.productor = result
      if (this.productor != null) {
        this.seEncontro = true;
        this.actualizarForm();
      }
      else {
        this.seEncontro = false;
      }
    })
    return this.productor
  }
  actualizarForm() {
    this.control.nombre.setValue(this.productor.nombre);
    this.control.apellido.setValue(this.productor.apellido);
    this.control.identificacion.setValue(this.productor.identificacion);
    this.control.cedulaCafetera.setValue(this.productor.cedulaCafetera);
    this.control.codigoFinca.setValue(this.productor.codigoFinca);
    this.control.codigoSica.setValue(this.productor.codigoSica);
    this.control.numeroTelefono.setValue(this.productor.numeroTelefono);
    this.control.municipio.setValue(this.productor.municipio);
    this.control.vereda.setValue(this.productor.vereda);
    this.control.afilicacionSadul.setValue(this.productor.afiliacionSalud);
    this.control.nombrePredio.setValue(this.productor.nombrePredio);
  }
  crearFormulario() {
    var productor = new Productor()
    productor.nombre = this.productor.nombre
    productor.apellido = this.productor.apellido
    productor.identificacion = this.productor.identificacion
    productor.cedulaCafetera = this.productor.cedulaCafetera
    productor.codigoFinca = this.productor.codigoFinca
    productor.codigoSica = this.productor.codigoSica
    productor.numeroTelefono = this.productor.numeroTelefono
    productor.municipio = this.productor.municipio
    productor.vereda = this.productor.vereda
    productor.afiliacionSalud = this.productor.afiliacionSalud
    productor.nombrePredio = this.productor.nombrePredio
    this.formGroup = this.formBuilder.group({
      nombre: [productor.nombre, Validators.required],
      apellido: [productor.apellido, Validators.required],
      identificacion: [
        productor.identificacion,
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(11),
        ],
      ],
      cedulaCafetera: [productor.cedulaCafetera, Validators.required],
      nombrePredio: [productor.nombrePredio, Validators.required],
      codigoFinca: [productor.codigoFinca, Validators.required],
      codigoSica: [productor.codigoSica, Validators.required],
      municipio: [productor.municipio, Validators.required],
      vereda: [productor.vereda, Validators.required],
      numeroTelefono: [
        productor.numeroTelefono,
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
          this.validarNumeroTelefono,
        ],
      ],
      afiliacionSalud: [productor.afiliacionSalud, Validators.required],
    });
  }

  asignarValores() {
    this.formGroup.setValue(this.buscar())
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
      this.actualizar()
    }
  }
  get control() {
    return this.formGroup.controls
  }
  actualizar() {
    this.productor = this.formGroup.value
    this.productorService
      .put(this.identificacion, this.productor)
      .subscribe((p) => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertaModalOkComponent)
          messageBox.componentInstance.titulo = 'Productor editado'
          this.productor = p
          this.formGroup.reset()
        } else {
          const messageBox = this.modalService.open(AlertaModalErrorComponent)
          messageBox.componentInstance.titulo = 'Ha ocurrido un error'
          messageBox.componentInstance.mensaje =
            'No se ha podido editar al productor'
        }
      })
  }

  eliminar() {
    this.productor = this.formGroup.value
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent)
    messageBox.componentInstance.titulo =
      '¿Desea eliminar este productor?'
    messageBox.componentInstance.mensaje = 'Esta acción no es reversible'
    messageBox.result.then((result) => {
      if (result) {
        this.productorService
          .delete(this.identificacion)
          .subscribe((p) => {
            if (p != null) {
              this.productor = null
              this.formGroup.reset()
            }
          })
      }
    })
  }
}
