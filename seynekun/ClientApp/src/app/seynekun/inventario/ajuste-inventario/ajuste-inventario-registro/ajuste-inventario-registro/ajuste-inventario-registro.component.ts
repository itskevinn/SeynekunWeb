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
  tipoAjuste: string[] = ["Incremento", "Disminucion"];
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
    private localeService: BsLocaleService )
  {
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
    this.ajusteInventario.codigoAjuste = '';
    this.ajusteInventario.tipoElemento = '';
    this.ajusteInventario.nombreElemento = '';
    this.ajusteInventario.codigoElemento = '';
    this.ajusteInventario.fecha = new Date();
    this.ajusteInventario.tipoAjuste = '';
    this.ajusteInventario.descripcion = '';
    this.ajusteInventario.cantidad = 0;
    this.ajusteInventario.nombreBodega = '';

    this.formGroup = this.formBuilder.group({
      codigoAjuste: [this.ajusteInventario.codigoAjuste, Validators.required],
      tipoElemento: [this.ajusteInventario.tipoElemento, Validators.required],
      nombreElemento: [this.ajusteInventario.nombreElemento, Validators.required],
      codigoElemento: [this.ajusteInventario.codigoElemento, Validators.required],
      fecha: [this.ajusteInventario.fecha, Validators.required],
      tipoAjuste: [this.ajusteInventario.tipoAjuste, Validators.required],
      descripcion: [this.ajusteInventario.descripcion],
      cantidad: [this.ajusteInventario.cantidad, Validators.required],
      nombreBodega: [this.ajusteInventario.nombreBodega, Validators.required]
    });
  }
  /* @ViewChild(BsDatepickerDirective, { static: false })
  datepicker: BsDatepickerDirective;

  @HostListener("window:scroll")
  onScrollEvent() {
    this.datepicker.hide();
  }*/

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
    this.control.tipoAjuste.setValue(e.target.value, {
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
        this.ajusteInventario = e;
        this.formGroup.reset();
      }
    });
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      console.log(this.control.codigoAjuste);
    } else {
      this.registrar();
    }
  }
}
