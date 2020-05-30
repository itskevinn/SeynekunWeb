import { Component, OnInit } from "@angular/core";
import { MateriaPrima } from "src/app/seynekun/models/modelo-materia-prima/materia-prima";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AlertaModalErrorComponent } from "src/app/@base/alerta-modal-error/alerta-modal-error.component";
import { AlertaModalOkComponent } from "src/app/@base/alerta-modal/alerta-modal.component";
import { MateriaPrimaService } from "src/app/servicios/servicio-materia/materia-prima.service";
import { HttpHeaders } from "@angular/common/http";
const httpOptionsPut = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
  responseType: "text",
};

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Component({
  selector: "app-materia-registro",
  templateUrl: "./materia-registro.component.html",
  styleUrls: ["./materia-registro.component.css"],
})
export class MateriaRegistroComponent implements OnInit {
  materia: MateriaPrima;
  formGroup: FormGroup;
  unidadMedidas: string[] = ["Gramo", "Kg", "Tonelada"];
  productos: Producto[];
  constructor(
    private materiaService: MateriaPrimaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private productoService: ProductoService
  ) {}

  ngOnInit(): void {
    this.obtenerProductos();
    this.materia = new MateriaPrima();
    this.crearFormulario();
  }
  obtenerProductos() {
    this.productoService.gets().subscribe((result) => {
      this.productos = result;
    });
  }

  crearFormulario() {
    this.materia.fecha = new Date();
    this.materia.codigo = null;
    this.materia.unidadMedida = "";
    this.materia.codigoProductor = "";
    this.materia.cantidad = null;
    this.formGroup = this.formBuilder.group({
      fecha: [this.materia.fecha, Validators.required],
      codigo: [this.materia.codigo, Validators.required],
      unidadMedida: [this.materia.unidadMedida, Validators.required],
      codigoProductor: [this.materia.codigoProductor, Validators.required],
      cantidad: [this.materia.cantidad, Validators.required],
    });
  }
  cambiarUnidadMedida(e) {
    if (this.control.unidadMedida.value == null) {
      this.control.unidadMedida.setValue("No especificada");
    } else {
      this.control.unidadMedida.setValue(e.target.value, {
        onlySelf: true,
      });
    }
  }
  cambiarProducto(e) {
    if (this.control.codigoProducto.value == null) {
      this.control.codigoProducto.setValue("No especificada");
    } else {
      this.control.codigoProducto.setValue(e.target.value, {
        onlySelf: true,
      });
    }
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
    this.materia = this.formGroup.value;
    this.materiaService.post(this.materia).subscribe((e) => {
      if (e != null) {
        const messageBox = this.modalService.open(AlertaModalOkComponent);
        messageBox.componentInstance.titulo = "Registro de materia exitoso";
        this.materia = e;
        this.formGroup.reset();
      } else {
        const messageBox = this.modalService.open(AlertaModalErrorComponent);
        messageBox.componentInstance.titulo = "Ha ocurrido un error";
        messageBox.componentInstance.mensaje =
          "No se ha podido registrar la materia";
      }
    });
  }
}
