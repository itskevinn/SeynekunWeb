import { Component, OnInit } from '@angular/core';
import { Control } from 'src/app/seynekun/models/modelo-control/control';
import { ControlService } from 'src/app/servicios/servicio-control/control.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-control-registro',
  templateUrl: './control-registro.component.html',
  styleUrls: ['./control-registro.component.css']
})
export class ControlRegistroComponent implements OnInit {

  tipos: string[] =[
    'Equipo','Tanque de agua','Insumos'
  ];
  control: Control;
  formGroup: FormGroup;
  fechaInicial: Date;
  fechaFinal: Date;
  bsValue = new Date();
  fechaMinimaA: Date;
  fechaMaximaA: Date;
  fechaMinimaD: Date;
  fechaMaximaD: Date;
  constructor(
    private controlService: ControlService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private localeService: BsLocaleService
  ) {
    this.fechaMinimaA= new Date();
    this.fechaMaximaA = new Date();
    this.fechaMinimaA.setDate(this.fechaMinimaA.getDate() - 7);
    this.fechaMaximaA.setDate(this.fechaMaximaA.getDate());
    this.fechaMinimaD= new Date();
    this.fechaMaximaD = new Date();
    this.fechaMinimaD.setDate(this.fechaMaximaA.getDate());
    this.fechaMaximaD.setDate(this.fechaMaximaA.getDate()+60);
  }

  ngOnInit(): void {
    this.crearFormulario();
    this.localeService.use("es");
  }

  private crearFormulario() {
    this.control = new Control();
    this.control.tipoControl = '';
    this.control.descripcion = '';
    this.control.fechaInicio = new Date();
    this.control.fechaFinal = new Date();
    this.control.observacion = '';

    this.formGroup = this.formBuilder.group({
      tipoControl: [this.control.tipoControl, Validators.required],
      descripcion: [this.control.descripcion, Validators.required],
      fechaInicio: [this.control.fechaInicio, Validators.required],
      fechaFinal: [this.control.fechaFinal, Validators.required],
      observacion: [this.control.observacion, Validators.required]
    });
  }

  get controlForm() {
    return this.formGroup.controls;
  }

  onSubmit() {
    if (this.formGroup.invalid) {
    } else {
      this.registrar();
    }
  }
  private registrar() {
    const control = this.formGroup.value;
    this.controlService.post(control).subscribe((c) => {
      if (c != null) {
        this.control = c;
        this.formGroup.reset();
      }
    });
  }

  cambiarTipo(e) {
    this.controlForm.tipoControl.setValue(e.target.value);
  }
}
