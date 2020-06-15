import { Component, OnInit, HostListener, ViewChild, OnDestroy } from "@angular/core";
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
import { Produccion } from "src/app/seynekun/models/modelo-produccion/produccion";
import { ProduccionService } from "src/app/servicios/servicio-produccion/produccion.service";
import { ConsultaBodegaComponent } from "src/app/modal/consulta-bodega/consulta-bodega/consulta-bodega.component";
import { Subscription } from "rxjs";
defineLocale("es", esLocale);

@Component({
  selector: "app-ajuste-inventario-registro",
  templateUrl: "./ajuste-inventario-registro.component.html",
  styleUrls: ["./ajuste-inventario-registro.component.css"],
})
export class AjusteInventarioRegistroComponent implements OnInit {

  textoABuscar: string;
  produccion: Produccion;
  ajustes: AjusteDeInventario[] = [];
  ajusteInventario: AjusteDeInventario;
  formGroupProduccion: FormGroup;
  formGroup: FormGroup;
  fechaHoy: Date;
  productos: Producto[];
  suscripcion: Subscription;
  materias: MateriaPrima[];
  bodegas: Bodega[];
  tipos: string[] = ["Incremento", "Disminucion"];
  tipoElementos: string[] = ["Producto", "Insumo"];
  insumos: Insumo[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  cantidadMateriaPrima: number;
  tipoAjuste: string;
  tipoProducto: boolean;
  nombreElemento: string
  materia: MateriaPrima;
  cantidadDisponible: number;
  codigoElemento: string;
  cantidadConsultada: boolean = false;
  codigoMateriaPrima: string;
  materiaDisponibles: MateriaPrima[];
  nombreBodega: string

  constructor(
    private produccionService: ProduccionService,
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
    this.getCodigo();
    this.formProduccion();
    this.crearFormulario();
    /*this.obtenerProductos();
    this.obtenerBodegas();
    this.obtenerMaterias();*/
    //  this.filtrarMaterias();
    this.localeService.use("es");
  }

  formProduccion() {
    this.produccion = new Produccion;
    this.produccion.codigoProduccion = '';
    this.produccion.fecha = new Date();
    this.produccion.descripcion = '';
    this.produccion.ajustes = [];

    this.formGroupProduccion = this.formBuilder.group({
      codigoProduccion: [this.produccion.codigoProduccion, Validators.required],
      fecha: [this.produccion.fecha, Validators.required],
      descripcion: [this.produccion.descripcion, Validators.required],
      ajustes: [this.produccion.ajustes, Validators.required],
    });
  }

  crearFormulario() {
    this.ajusteInventario = new AjusteDeInventario();
    this.ajusteInventario.codigo = '';
    this.ajusteInventario.codigoElemento = '';
    this.ajusteInventario.fecha = new Date();
    this.ajusteInventario.codigo = '';
    this.ajusteInventario.descipcion = '';
    this.ajusteInventario.cantidad = null;
    this.ajusteInventario.nombreElemento = ''
    this.ajusteInventario.tipoAjuste = 'Incremento';
    this.ajusteInventario.cantidadMateriaPrima = null;
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
      codigoMateriaPrima: [this.ajusteInventario.codigoMateriaPrima, Validators.required],
      cantidadMateriaPrima: [this.ajusteInventario.cantidadMateriaPrima, Validators.required],
      nombreElemento: [this.ajusteInventario.nombreElemento],
      cantidadDisponible: [this.cantidadDisponible]
    });
  }
  obtenerBodegas() {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
    });
  }
  cambiarIdProducto() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirIdProducto();
      this.control.codigoElemento.setValue(this.codigoElemento);
    }
  }
  cambiarIdBodega() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirIdBodega();
      this.control.nombreBodega.setValue(this.nombreBodega);
    }
  }
  recibirIdMateria() {
    var cantidadString: string;
    this.suscripcion = this.eventoService.codigoMateria.subscribe(
      (estado) => (this.control.codigoMateriaPrima.setValue(estado.split("-")[0]))
    );
    this.suscripcion = this.eventoService.codigoMateria.subscribe((cantidad) => (cantidadString = cantidad.split("-")[1]))
    this.control.cantidadDisponible.setValue(Number(cantidadString));
    this.cantidadConsultada = true;
    this.colocarValorMateria();
  }
  cambiarCantidad() {
    var cantidadString: string;
    if (this.cantidadConsultada) {
      this.suscripcion = this.eventoService.codigoMateria.subscribe((cantidad) => (cantidadString = cantidad.split("-")[1]))
      this.control.cantidadDisponible.setValue(Number(cantidadString));
    }
  }
  recibirIdProducto() {
    this.suscripcion = this.eventoService.codigo.subscribe(
      (estado) => (this.control.codigoElemento.setValue(estado))
    );
    this.control.codigoElemento.setValue(this.codigoElemento);
    this.colocarValorProducrto();
    this.colocarNombreProducto();
  }
  colocarNombreProducto() {
    this.productoService.get(this.codigoElemento).subscribe(
      (estado) => (this.nombreElemento = estado.nombre)
    );
    this.control.nombreElemento.setValue(this.nombreElemento);
  }
  colocarValorProducrto() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoElemento = estado)
    );
    this.control.codigoElemento.setValue(this.codigoElemento);
  }
  mostrarProductos() {
    this.modalService.open(ConsultaProductoComponent, { size: 'lg' });
  }
  colocarValorMateria() {
    this.eventoService.codigoMateria.subscribe(
      (estado) => (this.codigoMateriaPrima = estado)
    );
    this.control.codigoMateriaPrima.setValue(this.codigoMateriaPrima);
  }
  mostrarMaterias() {
    this.modalService.open(ConsultaMateriaComponent, { size: 'lg' });
  }
  recibirIdBodega() {
    this.suscripcion = this.bodegaService.nombreBodega.subscribe(
      (estado) => (this.control.nombreBodega.setValue(estado))
    );
    this.control.nombreBodega.setValue(this.nombreBodega);
    this.colocarValorBodega();
  }
  ngOnDestroy() {
    if (this.suscripcion != null) {
      this.suscripcion.unsubscribe();
    }
  }
  colocarValorBodega() {
    this.bodegaService.nombreBodega.subscribe(
      (estado) => (this.nombreBodega = estado)
    );
    this.control.nombreBodega.setValue(this.nombreBodega);
  }
  mostrarBodegas() {
    this.modalService.open(ConsultaBodegaComponent, { size: 'lg' });
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
  cambiarTipoAjuste(e) {
    this.control.tipoAjuste.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  agregarAjuste() {
    this.obtenerMateria();
    if (this.validarCantidad(this.control.cantidad.value) && this.validarCantidadMateria(this.control.cantidadMateriaPrima.value)) {
      const ajuste = new AjusteDeInventario;
      ajuste.codigo = String(this.ajustes.length + 1) + this.controlProduccion.codigoProduccion.value;
      ajuste.tipoElemento = "Producto";
      ajuste.codigoElemento = this.codigoElemento;
      ajuste.nombreElemento = this.nombreElemento;
      ajuste.fecha = this.control.fecha.value;
      ajuste.tipoAjuste = this.control.tipoAjuste.value;
      ajuste.descipcion = this.control.descipcion.value;
      ajuste.cantidad = this.control.cantidad.value;
      ajuste.nombreBodega = this.control.nombreBodega.value;
      ajuste.codigoMateriaPrima = this.control.codigoMateriaPrima.value;
      ajuste.cantidadMateriaPrima = this.control.cantidadMateriaPrima.value;
      this.updateAjustes(this.ajustes, ajuste);
    }
  }
  private obtenerMateria(): MateriaPrima {
    this.materiaService.getMateria(this.control.codigoMateriaPrima.value.split("-")[0]).subscribe((result) => {
      this.materia = result;
    })
    return this.materia;
  }
  private validarCantidadMateria(cantidad: number) {
    var _materia = this.obtenerMateria();
    if (cantidad > _materia.cantidad) {
      const modalRef = this.modalService.open(AlertaModalErrorComponent);
      modalRef.componentInstance.titulo = 'Error en la cantidad de la materia prima';
      modalRef.componentInstance.mensaje = 'La cantidad a procesar es mayor a la disponible';
      return false;
    }
    return true;
  }
  private validarCantidad(cantidad: number) {
    if (cantidad < 1) {
      const modalRef = this.modalService.open(AlertaModalErrorComponent);
      modalRef.componentInstance.titulo = 'Error en la cantidad del producto agregado';
      modalRef.componentInstance.mensaje = 'Digite una cantidad mayor 1';
      return false;
    }
    return true;
  }
  private updateAjustes(ajustes, ajuste) {
    var encontrado = true;
    const codigo = ajuste.codigoElemento;
    const bodega = ajuste.nombreBodega;
    let pos = 0;

    for (let item of ajustes) {
      if (item.codigoElemento === codigo && item.nombreBodega === bodega) {
        encontrado = false;
        pos = ajustes.indexOf(item);
      }
    }

    if (encontrado) {
      ajustes.push(ajuste);
    } else {
      ajustes[pos].cantidad += ajuste.cantidad;
    }
    this.controlProduccion.ajustes.setValue(this.ajustes);
  }
  eliminarAjuste(ajuste: AjusteDeInventario) {
    const posicion = this.ajustes.indexOf(ajuste);
    this.ajustes.splice(posicion, 1);
    this.controlProduccion.ajustes.setValue(this.ajustes);
  }
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
  get control() {
    return this.formGroup.controls;
  }
  get controlProduccion() {
    return this.formGroupProduccion.controls;
  }
  onSubmit() {
    this.registrar();
  }
  registrar() {
    const produccion = this.formGroupProduccion.value;
    this.produccionService.post(produccion).subscribe((e) => {
      if (e != null) {
        this.produccion = e;
        this.formGroupProduccion.reset();
      }
    });
  }
  getCodigo() {
    this.produccionService.getCodigoProduccion().subscribe((c) => {
      c != "" ? this.controlProduccion.codigoProduccion.setValue(String(c))
        : this.controlProduccion.codigoProduccion.setValue("Error");
    });
  }
  cambiarId() {
    return
  }
}
