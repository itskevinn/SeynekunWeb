import { Component, OnInit } from "@angular/core";
import { AlertaModalErrorComponent } from "src/app/@base/alerta-modal-error/alerta-modal-error.component";
import { AlertaModalOkComponent } from "src/app/@base/alerta-modal/alerta-modal.component";
import { Validators, FormGroup, FormBuilder } from "@angular/forms";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "app-bodega-registro",
  templateUrl: "./bodega-registro.component.html",
  styleUrls: ["./bodega-registro.component.css"],
})
export class BodegaRegistroComponent implements OnInit {
  bodega: Bodega;
  formGroup: FormGroup;
  constructor(
    private bodegaService: BodegaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.bodega = new Bodega();
    this.crearFormulario();
  }
  crearFormulario() {
    this.bodega.nombre = "";
    this.bodega.detalle = "";
    this.bodega.direccion = "";
    this.bodega.estado = "Activo";
    this.formGroup = this.formBuilder.group({
      detalle: [this.bodega.detalle],
      nombre: [this.bodega.nombre, Validators.required],
      estado: [this.bodega.estado],
      direccion: [this.bodega.direccion],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
    } else {
      this.registrar();
    }
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.bodega = this.formGroup.value;
    this.bodega.estado = "Activo"
    this.bodegaService.post(this.bodega).subscribe((e) => {
      if (e != null) {
        this.bodega = e;
        this.formGroup.reset();
      }
    });
  }
}
