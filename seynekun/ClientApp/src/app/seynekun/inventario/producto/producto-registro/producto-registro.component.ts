import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from "@angular/forms";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AlertaModalErrorComponent } from "src/app/@base/alerta-modal-error/alerta-modal-error.component";
import { AlertaModalOkComponent } from "src/app/@base/alerta-modal/alerta-modal.component";
import { Categoria } from "src/app/seynekun/models/modelo-categoria/categoria";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { CategoriaService } from "src/app/servicios/servicio-categoria/categoria.service";

@Component({
  selector: "app-producto-registro",
  templateUrl: "./producto-registro.component.html",
  styleUrls: ["./producto-registro.component.css"],
})
export class ProductoRegistroComponent implements OnInit {
  producto: Producto;
  formGroup: FormGroup;
  categorias: Categoria[];
  bodegas: Bodega[];
  constructor(
    private productoService: ProductoService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private bodegaService: BodegaService,
    private categoriaService: CategoriaService
  ) {}

  ngOnInit(): void {
    this.obtenerBodegas();
    this.obtenerCategorias();
    this.producto = new Producto();
    this.crearFormulario();
  }
  obtenerBodegas() {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
    });
  }
  obtenerCategorias() {
    this.categoriaService.gets().subscribe((result) => {
      this.categorias = result;
    });
  }

  crearFormulario() {
    this.producto.nombre = "";
    this.producto.codigo = "";
    this.producto.descripcion = "";
    this.producto.precio = null;
    this.producto.nombreCategoria = "No Especificada";
    this.producto.nombreBodega = "Principal";
    this.producto.estado = "Activo";
    this.formGroup = this.formBuilder.group({
      nombre: [this.producto.nombre],
      codigo: [this.producto.codigo, Validators.required],
      descripcion: [this.producto.descripcion],
      precio: [this.producto.precio, Validators.required],
      nombreCategoria: [this.producto.nombreCategoria],
      estado: [this.producto.estado],
      nombreBodega: [this.producto.nombreBodega],
    });
  }

  cambiarCategoria(e) {
    if (this.control.nombreCategoria.value == null) {
      this.control.nombreCategoria.setValue("No especificada");
    } else {
      this.control.nombreCategoria.setValue(e.target.value, {
        onlySelf: true,
      });
    }
  }
  cambiarBodega(e) {
    if (this.control.nombreBodega.value == null) {
      this.control.nombreBodega.setValue("Principal");
    } else {
      this.control.nombreBodega.setValue(e.target.value, {
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
    this.producto = this.formGroup.value;
    this.productoService.post(this.producto).subscribe((e) => {
      if (e != null) {
        const messageBox = this.modalService.open(AlertaModalOkComponent);
        messageBox.componentInstance.titulo = "Producto Registrado";
        this.producto = e;
        this.formGroup.reset();
      } else {
        const messageBox = this.modalService.open(AlertaModalErrorComponent);
        messageBox.componentInstance.titulo = "Ha ocurrido un error";
        messageBox.componentInstance.mensaje =
          "No se ha podido registrar el producto";
      }
    });
  }
}
