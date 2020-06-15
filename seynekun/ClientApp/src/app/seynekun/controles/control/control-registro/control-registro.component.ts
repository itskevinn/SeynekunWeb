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
    'ARROZ','YUCA'
  ];
  control: Control;
  formGroup: FormGroup;
  fechaInicial: Date;
  fechaFinal: Date;
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;

  constructor(
    private controlService: ControlService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private localeService: BsLocaleService
  ) { 
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.crearFormulario();
    this.localeService.use("es");
  }

  private crearFormulario(){
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

  cambiarTipo(e){
    this.controlForm.tipoControl.setValue(e.target.value);
  }
}
