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
import { MateriaPrima } from "src/app/seynekun/models/modelo-materia-prima/materia-prima";
import { MateriaPrimaService } from "src/app/servicios/servicio-materia/materia-prima.service";
import { ThrowStmt } from "@angular/compiler";
import { EventoService } from "src/app/servicios/servicio-evento/evento.service";
import { ConsultaMateriaComponent } from "src/app/modal/consulta-materia-modal/consulta-materia/consulta-materia.component";
import { ConsultaProductoComponent } from "src/app/modal/consulta-producto-modal/consulta-producto/consulta-producto.component";
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
  materias: MateriaPrima[];
  bodegas: Bodega[];
  tipos: string[] = ["Incremento", "Disminucion"];
  tipoElementos: string[] = ["Producto", "Insumo"];
  insumos: Insumo[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  tipoAjuste: string;
  tipoProducto: boolean;
  codigoElemento: string;
  codigoMateriaPrima: string;
  materiaDisponibles: MateriaPrima[];

  constructor(
    private ajusteInventarioService: AjusteInventarioService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private productoService: ProductoService,
    private bodegaService: BodegaService,
    private materiaService: MateriaPrimaService,
    private eventoService: EventoService,
    private localeService: BsLocaleService) {
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.ajusteInventario = new AjusteDeInventario();
    this.crearFormulario();
    this.obtenerProductos();
    this.obtenerBodegas();
    this.obtenerMaterias();
    //  this.filtrarMaterias();
    this.localeService.use("es");
  }

  crearFormulario() {
    this.ajusteInventario.codigo = '';
    this.ajusteInventario.codigoElemento = '';
    this.ajusteInventario.fecha = new Date();
    this.ajusteInventario.codigo = '';
    this.ajusteInventario.descipcion = '';
    this.ajusteInventario.cantidad = null;
    this.ajusteInventario.tipoAjuste = 'Incremento';
    this.ajusteInventario.codigoMateriaPrima = null;
    this.ajusteInventario.nombreBodega = '';
    this.formGroup = this.formBuilder.group({
      codigo: [this.ajusteInventario.codigo, Validators.required],
      tipoElemento: ['Producto'],
      codigoElemento: [this.ajusteInventario.codigoElemento, Validators.required],
      fecha: [this.ajusteInventario.fecha, Validators.required],
      descipcion: [this.ajusteInventario.descipcion],
      tipoAjuste: ["Incremento", Validators.required],
      cantidad: [this.ajusteInventario.cantidad, Validators.required],
      nombreBodega: [this.ajusteInventario.nombreBodega, Validators.required],
      codigoMateriaPrima: [this.ajusteInventario.codigoMateriaPrima, Validators.required]
    });
  }
  /* @ViewChild(BsDatepickerDirective, { static: false })
  datepicker: BsDatepickerDirective;

  @HostListener("window:scroll")
  onScrollEvent() {
    this.datepicker.hide();
  }*/
  cambiarId() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirId();
      this.control.codigoProductor.setValue(this.codigoMateriaPrima);
    }
  }
  recibirId() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoMateriaPrima = estado)
    );
    this.control.codigoMateriaPrima.setValue(this.codigoMateriaPrima);
    this.colocarValor();
  }
  colocarValor() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoMateriaPrima = estado)
    );
    this.control.codigoMateriaPrima.setValue(this.codigoMateriaPrima);
  }
  mostrarMaterias() {
    this.modalService.open(ConsultaMateriaComponent, { size: 'lg' });
  }
  mostrarProductos() {
    this.modalService.open(ConsultaProductoComponent, { size: 'lg' });
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
  obtenerMaterias() {
    this.materiaService.getDisponibles().subscribe((result) => {
      this.materias = result;
    })
  }

  /* filtrarMaterias() {
     for (let i = 0; i < this.materias.length; i++) {
       if (this.materias[i].estadoMateria == "Pendiente") {
         this.materiaDisponibles.push(this.materias[i]);
       }
     }
   }*/
  /*  obtenerInsumos() {
    this.insumoService.gets().subscribe((result) => {
      this.insumos = result;
    });
  }*/
  cambiarTipoElemento(e) {
    this.control.tipoElemento.setValue(e.target.value, {
      onlySelf: true,
    });
    if (this.control.tipoElemento.value == "Producto") {
      this.tipoProducto = true;
    }
    else {
      this.tipoProducto = false;
    }
  }
  cambiarBodega(e) {
    this.control.nombreBodega.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  cambiarTipoAjuste(e) {
    this.control.tipoAjuste.setValue(e.target.value, {
      onlySelf: true,
    });
    this.tipoAjuste = e.target.value;
    console.log(this.control.tipoAjuste.value);
  }
  cambiarCodigo(e) {
    this.control.codigoElemento.setValue(this.cortarCodigo(e.target.value).replace(/ /g, ""), {
      onlySelf: true,
    });
  }
  cortarCodigo(codigo: string) {
    var nombre = codigo.split(" - ");
    for (let i = 0; i < nombre.length; i++) {
      console.log(nombre[0]);
      return nombre[0];
    }
  }
  cambiarCodigoMateria(e) {
    this.control.codigoMateriaPrima.setValue(this.cortarCodigoMateria(e.target.value).replace(/ /g, ""), {
      onlySelf: true,
    });
  }
  cortarCodigoMateria(texto: string) {
    var nombre = texto.split(" - ");
    for (let i = 0; i < nombre.length; i++) {
      console.log(nombre[1]);
      return nombre[1];
    }
  }
  get control() {
    return this.formGroup.controls;
  }

  registrar() {
    console.log(this.control.tipoAjuste.value);
    this.ajusteInventario = this.formGroup.value;
    this.ajusteInventario.tipoAjuste = this.tipoAjuste;
    this.ajusteInventario.nombreBodega=this.control.nombreBodega.value;
    console.log(this.ajusteInventario.tipoAjuste);
    this.ajusteInventarioService.post(this.ajusteInventario).subscribe((e) => {
      if (e != null) {
        this.ajusteInventario = e;
        this.formGroup.reset();
      }
    });
  }
  onSubmit() {
    this.registrar();
  }
}
