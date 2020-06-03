import { Component, OnInit } from "@angular/core";
import { AlertaModalOkComponent } from "src/app/@base/alerta-modal/alerta-modal.component";
import { AlertaModalErrorComponent } from "src/app/@base/alerta-modal-error/alerta-modal-error.component";
import { Validators, FormBuilder, FormGroup } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Categoria } from "src/app/seynekun/models/modelo-categoria/categoria";
import { CategoriaService } from "src/app/servicios/servicio-categoria/categoria.service";

@Component({
  selector: "app-categoria-registro",
  templateUrl: "./categoria-registro.component.html",
  styleUrls: ["./categoria-registro.component.css"],
})
export class CategoriaRegistroComponent implements OnInit {
  categoria: Categoria;
  formGroup: FormGroup;
  constructor(
    private categoriaService: CategoriaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.categoria = new Categoria();
    this.crearFormulario();
  }
  crearFormulario() {
    this.categoria.nombre = "";
    this.categoria.detalle = "";
    this.categoria.estado = "Activa";
    this.formGroup = this.formBuilder.group({
      detalle: [this.categoria.detalle],
      nombre: [this.categoria.nombre, Validators.required],
      estado: this.categoria.estado,
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      const messageBox = this.modalService.open(AlertaModalErrorComponent);
      messageBox.componentInstance.titulo = "Ha ocurrido un error";
      messageBox.componentInstance.mensaje = "Aún faltan datos por llenar";
    } else {
      this.registrar();
    }
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.categoria = this.formGroup.value;
    this.categoriaService.post(this.categoria).subscribe((e) => {
      if (e != null) {
        this.categoria = e;
        this.formGroup.reset();
      }
    });
  }
}
