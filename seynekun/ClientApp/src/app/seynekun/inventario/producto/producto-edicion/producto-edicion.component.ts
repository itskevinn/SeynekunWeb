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
import { CategoriaService } from "src/app/servicios/servicio-categoria/categoria.service";

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
  respuesta: boolean;
  seEncontro: boolean;
  unidadMedidas: string[] = ["Gramo", "Kg", "Tonelada"];
  constructor(
    private categoriaService: CategoriaService,
    private productoService: ProductoService,
    private formBuilder: FormBuilder,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.obtenerCategorias();
    this.producto = new Producto();
    this.buscar();
    this.crearFormulario();
  }

  buscar() {
    this.productoService.get(this.nombre).subscribe((result) => {
      this.producto = result;
      if (this.producto != null) {
        this.actualizarForm();
        this.seEncontro = true;
      }
      else {
        this.seEncontro = false;
      }
    });
  }
  actualizarForm() {
    this.control.nombre.setValue(this.producto.nombre);
    this.control.codigo.setValue(this.producto.codigo);
    this.control.descripcion.setValue(this.producto.descripcion);
    this.control.precio.setValue(this.producto.precio);
    this.control.nombreCategoria.setValue(this.producto.nombreCategoria);
    this.control.estado.setValue(this.producto.estado);
    this.control.cantidad.setValue(this.producto.cantidad);
    this.control.unidadMedida.setValue(this.producto.unidadMedida);
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
  crearFormulario() {
    this.producto.nombre = "";
    this.producto.codigo = "";
    this.producto.descripcion = "";
    this.producto.precio = null;
    this.producto.nombreCategoria = "No Especificada";
    this.producto.estado = "Activo";
    this.producto.cantidad = null;
    this.producto.unidadMedida = "";
    this.formGroup = this.formBuilder.group({
      nombre: [this.producto.nombre],
      codigo: [this.producto.codigo, Validators.required],
      descripcion: [this.producto.descripcion],
      precio: [this.producto.precio, Validators.required],
      nombreCategoria: [this.producto.nombreCategoria],
      estado: [this.producto.estado],
      cantidad: [this.producto.cantidad],
      unidadMedida: [this.producto.unidadMedida],
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
      this.respuesta = result;
      if (this.respuesta === true) {
        this.productoService.delete(this.producto.codigo).subscribe((p) => {
          if (p != null) {
            const messageBox = this.modalService.open(AlertaModalOkComponent);
            messageBox.componentInstance.titulo = "Producto eliminado";
            this.producto = null;
            this.formGroup.reset();
          }
        });
      }
      else {
        this.modalService.dismissAll();
      }
    });
    messageBox.result.then((result) => {
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
