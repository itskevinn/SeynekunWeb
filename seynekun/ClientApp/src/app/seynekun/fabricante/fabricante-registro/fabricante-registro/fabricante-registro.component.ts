import { Component, OnInit } from '@angular/core';
import { FabricanteService } from 'src/app/servicios/servicio-fabricante/fabricante.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Fabricante } from 'src/app/seynekun/models/modelo-fabricante/fabricante';

@Component({
  selector: 'app-fabricante-registro',
  templateUrl: './fabricante-registro.component.html',
  styleUrls: ['./fabricante-registro.component.css']
})
export class FabricanteRegistroComponent implements OnInit {
  fabricante: Fabricante
  formGroup: FormGroup
  idTipos: string[] = ['NIT', 'CC']

  constructor(
    private fabricanteService: FabricanteService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
  ) { }

  ngOnInit(): void {
    this.fabricante = new Fabricante()
    this.crearFormulario()
  }

  crearFormulario() {
    this.fabricante.tipoIdentificacion = ''
    this.fabricante.identificacion = ''
    this.fabricante.nombre = ''
    this.fabricante.direccion = ''
    this.fabricante.numeroTelefono = ''
    this.fabricante.email = ''
    this.fabricante.fax = ''
    this.fabricante.estado = "Activo"
    this.fabricante.sitioWeb = '';

    this.formGroup = this.formBuilder.group({
      tipoIdentificacion: [this.fabricante.tipoIdentificacion, Validators.required],
      identificacion: [this.fabricante.identificacion, Validators.required],
      nombre: [this.fabricante.nombre, Validators.required],
      direccion: [this.fabricante.direccion, Validators.required],
      numeroTelefono: [
        this.fabricante.numeroTelefono,
        [
          Validators.minLength(10),
          Validators.maxLength(10),
          this.validarNumeroTelefono,
        ],
      ],
      email: [this.fabricante.email, Validators.email],
      fax: [this.fabricante.fax],
      estado: [this.fabricante.estado],
      sitioWeb: [this.fabricante.sitioWeb]
    })
  }

  cambiarTipoId(e) {
    this.control.tipoIdentificacion.setValue(e.target.value)
  }


  private validarNumeroTelefono(control: AbstractControl) {
    const numero = control.value
    var esNumero = false
    var number
    try {
      number = Number(numero)
      esNumero = true
    } catch (error) {
      esNumero = false
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
    this.fabricante = this.formGroup.value
    this.fabricanteService.post(this.fabricante).subscribe((e) => {
      if (e != null) {
        this.fabricante = e
        this.formGroup.reset();
      }
    })
  }

}
