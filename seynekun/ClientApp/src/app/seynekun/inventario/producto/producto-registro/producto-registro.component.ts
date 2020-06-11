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
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import { CategoriaService } from "src/app/servicios/servicio-categoria/categoria.service";

@Component({
  selector: "app-producto-registro",
  templateUrl: "./producto-registro.component.html",
  styleUrls: ["./producto-registro.component.css"],
})
export class ProductoRegistroComponent implements OnInit {
  producto: Producto;
  formGroup: FormGroup;
  unidadMedidas: string[] = ["Gramo", "Kg", "Tonelada"];
  categorias: Categoria[];
  constructor(
    private productoService: ProductoService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private categoriaService: CategoriaService
  ) { }

  ngOnInit(): void {
    this.obtenerCategorias();
    this.producto = new Producto();
    this.crearFormulario();
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
    this.producto.estado = "Activo";
    this.producto.ContenidoNeto = null;
    this.producto.unidadMedida = "";
    this.formGroup = this.formBuilder.group({
      nombre: [this.producto.nombre],
      codigo: [this.producto.codigo, Validators.required],
      descripcion: [this.producto.descripcion],
      precio: [this.producto.precio, Validators.required],
      nombreCategoria: [this.producto.nombreCategoria],
      estado: [this.producto.estado],
      ContenidoNeto: [this.producto.ContenidoNeto],
      unidadMedida: [this.producto.unidadMedida],
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

  cambiarCategoria(e) {
    console.log(e.target.value);
    if (this.control.nombreCategoria.value == null) {
      this.control.nombreCategoria.setValue("No especificada");
    } else {
      this.control.nombreCategoria.setValue(e.target.value, {
        onlySelf: true,
      });
    }
  }
  onSubmit() {
    this.registrar();
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.producto = this.formGroup.value;
    this.productoService.post(this.producto).subscribe((e) => {
      if (e != null) {
        this.producto = e;
        this.formGroup.reset();
      }
    });
  }
}
