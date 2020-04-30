import { Component, OnInit } from '@angular/core'
import {
  AbstractControl,
  Validators,
  FormBuilder,
  FormGroup,
} from '@angular/forms'
import { EmpleadoService } from 'src/app/servicios/servicio-de-empleado/empleado.service'
import { Empleado } from '../../models/modelo-empleado/empleado'
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-empleado-edicion',
  templateUrl: './empleado-edicion.component.html',
  styleUrls: ['./empleado-edicion.component.css'],
})
export class EmpleadoEdicionComponent implements OnInit {
  identificacion = this.rutaActiva.snapshot.params.id
  empleado: Empleado
  formGroup: FormGroup
  seEncontro: Boolean
  botonPresionado: Boolean = false
  cargos: string[] = [
    'Secretaria/o',
    'Jefe de Producción',
    'Coordinador de Producción',
    'Recepcionista',
    'Auxiliar de Planta',
  ]
  constructor(
    private empleadoService: EmpleadoService,
    private formBuilder: FormBuilder,
    private rutaActiva: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    this.empleado = new Empleado()
    this.buscar()
    this.crearFormulario()
    this.formGroup.setValue(this.empleado)
  }

  buscar() {
    this.empleadoService.get(this.identificacion).subscribe((result) => {
      this.empleado = result
      this.empleado != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false)
    })
  }

  get valor() {
    return this.formGroup.value
  }

  validarMensaje() {
    this.botonPresionado = true
  }

  crearFormulario() {
    this.formGroup = this.formBuilder.group({
      nombre: [this.empleado.nombre, Validators.required],
      apellido: [this.empleado.apellido, Validators.required],
      cedula: [
        this.empleado.cedula,
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(11),
          this.validarNumeroCedula,
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
      estado: [this.empleado.estado, Validators.required],
    })
  }

  private validarNumeroCedula(control: AbstractControl) {
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
        validaNumeroCedula: true,
        mensajeNumero: 'Número cédula no válido',
      }
  }

  cambiarCargo(e) {
    this.control.cargo.setValue(e.target.value, {
      onlySelf: true,
    })
  }

  private resetearBoton() {
    let seReseteó
    this.botonPresionado = false
    return (seReseteó = true)
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
      return null
    }
    this.actualizar()
  }

  get control() {
    return this.formGroup.controls
  }

  actualizar() {
    this.empleado = this.formGroup.value
    this.empleadoService
      .put(this.identificacion, this.empleado)
      .subscribe((e) => {
        if (e != null) {
          this.empleado = e
          this.formGroup.reset()
        }
      })
  }
}
