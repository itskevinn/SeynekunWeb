import { Component, OnInit } from '@angular/core';
import { BodegaService } from 'src/app/servicios/servicio-bodega/bodega.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Bodega } from 'src/app/seynekun/models/modelo-bodega/bodega';
import { AlertaModalPreguntaComponent } from 'src/app/@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component';
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component';
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component';

@Component({
  selector: "app-bodega-edicion",
  templateUrl: "./bodega-edicion.component.html",
  styleUrls: ["./bodega-edicion.component.css"],
})
export class BodegaEdicionComponent implements OnInit {
  nombre = this.rutaActiva.snapshot.params.id;
  bodega: Bodega;
  formGroup: FormGroup;
  seEncontro: boolean;
  constructor(
    private bodegaService: BodegaService,
    private formBuilder: FormBuilder,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.bodega = new Bodega();
    this.buscar();
    this.crearFormulario();
    this.formGroup.setValue(this.bodega);
  }

  buscar() {
    this.bodegaService.get(this.nombre).subscribe((result) => {
      this.bodega = result;
      if (this.bodega != null) {
        this.actualizarForm();
        this.seEncontro = true;
      }
      else {
        this.seEncontro = false;
      }
    });
  }
  actualizarForm() {
    this.control.nombre.setValue(this.bodega.nombre);
    this.control.detalle.setValue(this.bodega.detalle);
    this.control.direccion.setValue(this.bodega.direccion);
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
      return null;
    }
    this.actualizar();
  }

  get control() {
    return this.formGroup.controls;
  }

  eliminar() {
    this.bodega = this.formGroup.value;
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent);
    messageBox.componentInstance.titulo = "¿Desea eliminar esta bodega?";
    messageBox.componentInstance.mensaje = "Esta acción no es reversible";
    messageBox.result.then((result) => {
      if (result) {
        this.bodegaService.delete(this.nombre).subscribe((p) => {
          if (p != null) {
            this.bodega = null;
            this.formGroup.reset();
          }
        });
      }
    });
  }

  actualizar() {
    this.bodega = this.formGroup.value;
    this.bodegaService.put(this.bodega).subscribe((e) => {
      if (e != null) {
        this.bodega = e;
        this.formGroup.reset();
      }
    });
  }
}
