import { Component, OnInit } from "@angular/core";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { ActivatedRoute } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AlertaModalPreguntaComponent } from "src/app/@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component";
import { AlertaModalOkComponent } from "src/app/@base/alerta-modal/alerta-modal.component";
import { AlertaModalErrorComponent } from "src/app/@base/alerta-modal-error/alerta-modal-error.component";
import { Categoria } from "src/app/seynekun/models/modelo-categoria/categoria";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";
import { CategoriaService } from "src/app/servicios/servicio-categoria/categoria.service";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";

@Component({
  selector: "app-producto-edicion",
  templateUrl: "./producto-edicion.component.html",
  styleUrls: ["./producto-edicion.component.css"],
})
export class ProductoEdicionComponent implements OnInit {
  nombre = this.rutaActiva.snapshot.params.id;
  producto: Producto;
  formGroup: FormGroup;
  categorias: Categoria[];
  bodegas: Bodega[];
  seEncontro: boolean;
  constructor(
    private bodegaService: BodegaService,
    private categoriaService: CategoriaService,
    private productoService: ProductoService,
    private formBuilder: FormBuilder,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.obtenerBodegas();
    this.obtenerCategorias();
    this.producto = new Producto();
    this.buscar();
    this.crearFormulario();
    this.formGroup.setValue(this.producto);
  }

  buscar() {
    this.productoService.get(this.nombre).subscribe((result) => {
      this.producto = result;
      this.producto != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
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
      return null;
    }
    this.actualizar();
  }

  get control() {
    return this.formGroup.controls;
  }

  eliminar() {
    this.producto = this.formGroup.value;
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent);
    messageBox.componentInstance.titulo = "¿Desea eliminar esta producto?";
    messageBox.componentInstance.mensaje = "Esta acción no es reversible";
    messageBox.result.then((result) => {
      if (result) {
        this.productoService.delete(this.nombre).subscribe((p) => {
          if (p != null) {
            const messageBox = this.modalService.open(AlertaModalOkComponent);
            messageBox.componentInstance.titulo = "producto eliminada";
            this.producto = null;
            this.formGroup.reset();
          } else {
            const messageBox = this.modalService.open(
              AlertaModalErrorComponent
            );
            messageBox.componentInstance.titulo = "Ha ocurrido un error";
            messageBox.componentInstance.mensaje =
              "No se ha podido eliminar la producto";
          }
        });
      }
    });
  }

  actualizar() {
    this.producto = this.formGroup.value;
    this.productoService.put(this.nombre, this.producto).subscribe((e) => {
      if (e != null) {
        this.producto = e;
        this.formGroup.reset();
      }
    });
  }
}
