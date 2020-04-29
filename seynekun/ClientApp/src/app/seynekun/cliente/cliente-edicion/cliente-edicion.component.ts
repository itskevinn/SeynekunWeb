import { Component, OnInit } from '@angular/core'
import {
  Validators,
  FormGroup,
  FormBuilder,
  AbstractControl,
} from '@angular/forms'
import { Cliente } from '../../models/modelo-cliente/cliente'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { ClienteService } from 'src/app/servicios/servicio-de-cliente/cliente.service'
import { ActivatedRoute } from '@angular/router'
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component'
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component'

@Component({
  selector: 'app-cliente-edicion',
  templateUrl: './cliente-edicion.component.html',
  styleUrls: ['./cliente-edicion.component.css'],
})
export class ClienteEdicionComponent implements OnInit {
  cliente: Cliente
  formGroup: FormGroup
  idTipos: string[]
  seEncontro: Boolean
  departamentos: string[]
  municipios: string[]
  identificacion = this.rutaActiva.snapshot.params.id
  constructor(
    private clienteService: ClienteService,
    private rutaActiva: ActivatedRoute,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
  ) {}

  ngOnInit(): void {
    this.cliente = new Cliente()
    this.crearFormulario()
  }
  crearFormulario() {
    this.cliente.nombre = ''
    this.cliente.apellido = ''
    this.cliente.tipoIdentificacion = ''
    this.cliente.identificacion = ''
    this.cliente.numeroTelefono = ''
    this.cliente.numeroTelefono2 = ''
    this.cliente.email = ''
    this.cliente.direccion = ''
    this.cliente.municipio = ''
    this.cliente.departamento = ''
    this.cliente.barrio = ''
    this.formGroup = this.formBuilder.group({
      nombre: [this.cliente.nombre, Validators.required],
      apellido: [this.cliente.apellido, Validators.required],
      tipoIdentificacion: [
        this.cliente.tipoIdentificacion,
        Validators.required,
      ],
      identificacion: [this.cliente.identificacion, Validators.required],
      numeroTelefono: [
        this.cliente.numeroTelefono,
        [
          Validators.minLength(10),
          Validators.maxLength(12),
          this.validarNumeroTelefono,
        ],
      ],
      numeroTelefono2: [
        this.cliente.numeroTelefono,
        [
          Validators.minLength(10),
          Validators.maxLength(12),
          this.validarNumeroTelefono,
        ],
      ],
      email: [this.cliente.email, Validators.email],
      direccion: [this.cliente.direccion],
      municipio: [this.cliente.municipio],
      departamento: [this.cliente.departamento],
      barrio: [this.cliente.barrio],
    })
  }
  buscar() {
    const identificacion = this.rutaActiva.snapshot.params.id
    this.clienteService.get(identificacion).subscribe((result) => {
      this.cliente = result
      this.cliente != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false)
    })
  }
  cambiarTipoId(e) {
    this.control.tipoIdentificacion.setValue(e.target.value, {
      onlySelf: true,
    })
  }
  cambiarMunicipio(e) {
    this.control.municipio.setValue(e.target.value, {
      onlySelf: true,
    })
  }
  cambiarDepartamento(e) {
    this.control.departamento.setValue(e.target.value, {
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
    this.cliente = this.formGroup.value
    this.clienteService
      .put(this.identificacion, this.cliente)
      .subscribe((c) => {
        if (c != null) {
          const messageBox = this.modalService.open(AlertaModalOkComponent)
          messageBox.componentInstance.titulo = 'Cliente Editado'
          this.cliente = c
        } else {
          const messageBox = this.modalService.open(AlertaModalErrorComponent)
          messageBox.componentInstance.titulo = 'Ha ocurrido un error'
          messageBox.componentInstance.mensaje =
            'No se ha podido editar al cliente'
        }
      })
  }
}
