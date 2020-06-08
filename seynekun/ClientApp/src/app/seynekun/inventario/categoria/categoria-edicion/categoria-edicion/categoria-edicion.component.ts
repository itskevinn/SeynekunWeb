import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/seynekun/models/modelo-categoria/categoria';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CategoriaService } from 'src/app/servicios/servicio-categoria/categoria.service';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertaModalPreguntaComponent } from 'src/app/@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component';
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component';
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component';

@Component({
  selector: "app-categoria-edicion",
  templateUrl: "./categoria-edicion.component.html",
  styleUrls: ["./categoria-edicion.component.css"],
})
export class CategoriaEdicionComponent implements OnInit {
  nombre = this.rutaActiva.snapshot.params.id;
  categoria: Categoria;
  formGroup: FormGroup;
  seEncontro: boolean;
  constructor(
    private categoriaService: CategoriaService,
    private formBuilder: FormBuilder,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.categoria = new Categoria();
    this.buscar();
    this.crearFormulario();
  }

  buscar() {
    this.categoriaService.get(this.nombre).subscribe((result) => {
      this.categoria = result;
      if (this.categoria != null) {
        this.actualizarForm();
        this.seEncontro = true;
      }
      else {
        this.seEncontro = false;
      }
    });
  }
  actualizarForm() {
    this.control.nombre.setValue(this.categoria.nombre);
    this.control.detalle.setValue(this.categoria.detalle);
    this.control.estado.setValue(this.categoria.estado);
  }
  crearFormulario() {
    this.categoria.nombre = "";
    this.categoria.detalle = "";
    this.categoria.estado = "Activo";
    this.formGroup = this.formBuilder.group({
      detalle: [this.categoria.detalle],
      nombre: [this.categoria.nombre, Validators.required],
      estado: this.categoria.estado,
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
    this.categoria = this.formGroup.value;
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent);
    messageBox.componentInstance.titulo = "¿Desea eliminar esta categoria?";
    messageBox.componentInstance.mensaje = "Esta acción no es reversible";
    messageBox.result.then((result) => {
      if (result) {
        this.categoriaService.delete(this.nombre).subscribe((p) => {
          if (p != null) {
            this.categoria = null;
            this.formGroup.reset();
          }
        });
      }
    });
  }

  actualizar() {
    this.categoria = this.formGroup.value;
    this.categoriaService.put(this.nombre, this.categoria).subscribe((e) => {
      if (e != null) {
        this.categoria = e;
        this.formGroup.reset();
      }
    });
  }
}
