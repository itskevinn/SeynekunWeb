import { Component, OnInit, HostListener, ViewChild } from "@angular/core";
import { AjusteDeInventario } from "src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario";
import { AjusteInventarioService } from "src/app/servicios/servicio-ajuste/ajuste-inventario.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AlertaModalErrorComponent } from "src/app/@base/alerta-modal-error/alerta-modal-error.component";
import { AlertaModalOkComponent } from "src/app/@base/alerta-modal/alerta-modal.component";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";
import { Insumo } from "src/app/seynekun/models/modelo-insumo/insumo";
import { BodegaService } from "src/app/servicios/servicio-bodega/bodega.service";
import { ProductoService } from "src/app/servicios/servicio-producto/producto.service";
import {
  BsDatepickerDirective,
  BsLocaleService,
} from "ngx-bootstrap/datepicker";
import { defineLocale, esLocale } from "ngx-bootstrap/chronos";
defineLocale("es", esLocale);

@Component({
  selector: "app-ajuste-inventario-registro",
  templateUrl: "./ajuste-inventario-registro.component.html",
  styleUrls: ["./ajuste-inventario-registro.component.css"],
})
export class AjusteInventarioRegistroComponent implements OnInit {
  ajusteInventario: AjusteDeInventario;
  formGroup: FormGroup;
  fechaHoy: Date;
  productos: Producto[];
  bodegas: Bodega[];
  tipos: string[] = ["Incremento", "Disminucion"];
  insumos: Insumo[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  codigoElemento: string;
  constructor(
    private ajusteInventarioService: AjusteInventarioService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private productoService: ProductoService,
    private bodegaService: BodegaService,
    private localeService: BsLocaleService
  ) {
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.ajusteInventario = new AjusteDeInventario();
    this.obtenerBodegas();
    this.obtenerProductos();
    this.crearFormulario();
    this.localeService.use("es");
  }

  crearFormulario() {
    this.ajusteInventario.fecha = new Date();
    this.ajusteInventario.descipcion = "";
    this.ajusteInventario.cantidad = null;
    this.ajusteInventario.codigoElemento = "";
    this.ajusteInventario.codigo = null;
    this.ajusteInventario.tipo = "";
    this.ajusteInventario.nombreBodega = "";
    this.formGroup = this.formBuilder.group({      
      codigoElemento: [this.ajusteInventario.codigoElemento],
      cantidad: [this.ajusteInventario.cantidad, Validators.required],
      fecha: [this.ajusteInventario.fecha, Validators.required],
      nombreBodega: [this.ajusteInventario.nombreBodega, Validators.required],
      tipo: [this.ajusteInventario.tipo, Validators.required],
      codigo: [this.ajusteInventario.codigo, Validators.required],
    });
  }
  /* @ViewChild(BsDatepickerDirective, { static: false })
  datepicker: BsDatepickerDirective;

  @HostListener("window:scroll")
  onScrollEvent() {
    this.datepicker.hide();
  }*/

  onSubmit() {
    if (this.formGroup.invalid) {
      const messageBox = this.modalService.open(AlertaModalErrorComponent);
      messageBox.componentInstance.titulo = "Ha ocurrido un error";
      messageBox.componentInstance.mensaje = "Aún faltan datos por llenar";
      console.log(this.control.codigo);
    } else {
      this.registrar();
    }
  }
  obtenerBodegas() {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
    });
  }
  obtenerProductos() {
    this.productoService.gets().subscribe((result) => {
      this.productos = result;
    });
  }
  /*  obtenerInsumos() {
    this.insumoService.gets().subscribe((result) => {
      this.insumos = result;
    });
  }*/

  cambiarBodega(e) {
    this.control.nombreBodega.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  cambiarTipo(e) {
    this.control.tipo.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  cambiarCodigo(e) {
    this.control.codigoElemento.setValue(this.cortarCodigo(e.target.value), {
      onlySelf: true,
    });
  }
  cortarCodigo(codigo: string[]) {
    for (let i = 0; i < codigo.length; i++) {
      return codigo[0];      
    }
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.ajusteInventario = this.formGroup.value;
    this.ajusteInventarioService.post(this.ajusteInventario).subscribe((e) => {
      if (e != null) {
        const messageBox = this.modalService.open(AlertaModalOkComponent);
        messageBox.componentInstance.titulo = "Ajuste de Inventario Registrado";
        this.ajusteInventario = e;
        this.formGroup.reset();
      } else {
        const messageBox = this.modalService.open(AlertaModalErrorComponent);
        messageBox.componentInstance.titulo = "Ha ocurrido un error";
        messageBox.componentInstance.mensaje =
          "No se ha podido registrar el Ajuste de Inventario";
      }
    });
  }
}
