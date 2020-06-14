import { Component, OnInit } from '@angular/core';
import { Transportador } from 'src/app/seynekun/models/modelo-transportador/transportador';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { TransportadorService } from 'src/app/servicios/servicio-transportador/transportador.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-transportador-registro',
  templateUrl: './transportador-registro.component.html',
  styleUrls: ['./transportador-registro.component.css']
})
export class TransportadorRegistroComponent implements OnInit {

  transportador: Transportador;
  formGroup: FormGroup;
  
  constructor(
    private transportadorService: TransportadorService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
  ) { }

  ngOnInit(): void {
    this.crearFormulario();
  }

  private crearFormulario(){
    this.transportador = new Transportador;
    this.transportador.identificacion = '';
    this.transportador.nombre = '';
    this.transportador.apellido = '';
    this.transportador.numeroTelefono = '';
    this.transportador.numeroLicencia = '';
    this.transportador.email = '';
    this.formGroup = this.formBuilder.group({
      identificacion: [this.transportador.identificacion, Validators.required],
      nombre: [this.transportador.nombre, Validators.required],
      apellido: [this.transportador.apellido, Validators.required],
      numeroTelefono: [this.transportador.numeroTelefono, [
        Validators.minLength(10),
        Validators.maxLength(12),
        this.validarNumeroTelefono
      ]],
      numeroLicencia: [this.transportador.numeroLicencia, Validators.required],
      email: [this.transportador.email, [Validators.required, Validators.email]],
    });
  }

  get control() {
    return this.formGroup.controls
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
  registrar() {
    this.transportador = this.formGroup.value
    this.transportadorService.post(this.transportador).subscribe((t) => {
      if (t != null) {
        this.transportador = t;
        this.formGroup.reset();
      }
    })
  }
}
