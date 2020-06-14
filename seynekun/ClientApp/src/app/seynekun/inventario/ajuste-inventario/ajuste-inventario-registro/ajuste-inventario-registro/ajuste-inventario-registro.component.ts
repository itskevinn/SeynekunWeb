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
import { Produccion } from "src/app/seynekun/models/modelo-produccion/produccion";
import { ProduccionService } from "src/app/servicios/servicio-produccion/produccion.service";
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
  materias: MateriaPrima[];
  bodegas: Bodega[];
  tipos: string[] = ["Incremento", "Disminucion"];
  tipoElementos: string[] = ["Producto", "Insumo"];
  insumos: Insumo[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  estadoMateriaPrima: string;
  tipoAjuste: string;
  tipoProducto: boolean;
  codigoElemento: string;
  codigoMateriaPrima: string;
  materiaDisponibles: MateriaPrima[];

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
    this.obtenerProductos();
    this.obtenerBodegas();
    this.obtenerMaterias();
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
  cambiarIdMateria() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirIdMateria();
      this.control.codigoMateriaPrima.setValue(this.codigoMateriaPrima);
    }
  }
  cambiarIdProducto() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirIdProducto();
      this.control.codigoElemento.setValue(this.codigoElemento);
    }
  }
  recibirIdMateria() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoMateriaPrima = estado)
    );
    this.control.codigoMateriaPrima.setValue(this.codigoMateriaPrima);
    this.colocarValorMateria();
  }
  recibirIdProducto() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoElemento = estado)
    );
    this.control.codigoElemento.setValue(this.codigoElemento);
    this.colocarValorProducrto();
  }
  colocarValorMateria() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoMateriaPrima = estado)
    );
    this.control.codigoMateriaPrima.setValue(this.codigoMateriaPrima);
  }
  colocarValorProducrto() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoElemento = estado)
    );
    this.control.codigoElemento.setValue(this.codigoElemento);
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

  //Hecho por moi
  cambiarTipoAjuste(e) {
    this.control.tipoAjuste.setValue(e.target.value, {
      onlySelf: true,
    });
  }

  agregarAjuste() {
    if (this.validarCantidad(this.control.cantidad.value)) {
      const ajuste = new AjusteDeInventario;
      ajuste.codigo = String(this.ajustes.length + 1) + this.controlProduccion.codigoProduccion.value;
      ajuste.tipoElemento = "Producto";
      ajuste.codigoElemento = "111111";
      ajuste.nombreElemento = "yuca";
      ajuste.fecha = this.control.fecha.value;
      ajuste.tipoAjuste = this.control.tipoAjuste.value;
      ajuste.descipcion = this.control.descipcion.value;
      ajuste.cantidad = this.control.cantidad.value;
      ajuste.nombreBodega = "Bodega sis";
      ajuste.codigoMateriaPrima = "129";
      this.updateAjustes(this.ajustes, ajuste);
    }
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
  //Aca finaliza lo que hizo moi


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
  get controlProduccion() {
    return this.formGroupProduccion.controls;
  }

  onSubmit() {
    if (this.formGroupProduccion.invalid) {
    } else {
      this.registrar();
    }
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

  cambiarId(){
    return
  }
}
