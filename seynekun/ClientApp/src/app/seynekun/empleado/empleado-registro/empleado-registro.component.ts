import { Component, OnInit } from '@angular/core'
import { EmpleadoService } from 'src/app/servicios/servicio-de-empleado/empleado.service'
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms'
import { Empleado } from '../../models/modelo-empleado/empleado'
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component'

@Component({
  selector: 'app-empleado-registro',
  templateUrl: './empleado-registro.component.html',
  styleUrls: ['./empleado-registro.component.css'],
})
export class EmpleadoRegistroComponent implements OnInit {
  empleado: Empleado
  formGroup: FormGroup
  idTipos: string[] = ['CC', 'TI', 'RI']
  cargos: string[] = [
    'Secretaria/o',
    'Jefe de Producción',
    'Coordinador de Producción',
    'Recepcionista',
    'Auxiliar de Planta'
  ]

  constructor(
    private empleadoService: EmpleadoService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
  ) { }

  ngOnInit(): void {
    this.empleado = new Empleado()
    this.crearFormulario()
  }

  crearFormulario() {
    this.empleado.tipoIdentificacion = ''
    this.empleado.nombre = ''
    this.empleado.apellido = ''
    this.empleado.identificacion = ''
    this.empleado.numeroTelefono = ''
    this.empleado.email = ''
    this.empleado.cargo = ''
    this.empleado.estado = "Activo"

    this.formGroup = this.formBuilder.group({
      tipoIdentificacion: [this.empleado.tipoIdentificacion, Validators.required],
      nombre: [this.empleado.nombre, Validators.required],
      apellido: [this.empleado.apellido, Validators.required],
      identificacion: [
        this.empleado.identificacion,
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(11),
          this.validarNumeroidentificacion,
        ],
      ],
      numeroTelefono: [
        this.empleado.numeroTelefono,
        [
          Validators.minLength(10),
          Validators.maxLength(10),
          this.validarNumeroTelefono,
        ],
      ],
      email: [this.empleado.email, Validators.email],
      cargo: [this.empleado.cargo, Validators.required],
      estado: [this.empleado.estado]
    })
  }

  private validarNumeroidentificacion(control: AbstractControl) {
    const numero = control.value
    var esNumero = false
    var number
    try {
      number = parseInt(numero)
      esNumero = true
    } catch (error) {
      esNumero = false
    }
    if (esNumero) {
      return null
    } else
      return {
        validaNumeroidentificacion: true,
        mensajeNumero: 'Número cédula no válido',
      }
  }

  cambiarTipoId(e) {
    this.control.tipoIdentificacion.setValue(e.target.value)
  }

  cambiarCargo(e) {
    this.control.cargo.setValue(e.target.value, {
      onlySelf: true,
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

  onSubmit() {
    if (this.formGroup.invalid) {
    } else {
      this.registrar()
    }
  }

  get control() {
    return this.formGroup.controls
  }

  registrar() {
    this.empleado = this.formGroup.value
    this.empleadoService.post(this.empleado).subscribe((e) => {
      if (e != null) {
        this.empleado = e
        this.formGroup.reset();
      }
    })
  }
}
