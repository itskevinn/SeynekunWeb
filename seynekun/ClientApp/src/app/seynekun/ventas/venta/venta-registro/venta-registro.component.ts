import { Component, OnInit } from '@angular/core';
import { Venta } from 'src/app/seynekun/models/modelo-venta/venta';
import { Producto } from 'src/app/seynekun/models/modelo-producto/producto';
import { Bodega } from 'src/app/seynekun/models/modelo-bodega/bodega';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BodegaService } from 'src/app/servicios/servicio-bodega/bodega.service';
import { VentaService } from 'src/app/servicios/servicio-venta/venta.service';
import { ProductoService } from 'src/app/servicios/servicio-producto/producto.service';
import { AjusteDeInventario } from 'src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario';
import { AjusteInventarioService } from 'src/app/servicios/servicio-ajuste/ajuste-inventario.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { Cliente } from 'src/app/seynekun/models/modelo-cliente/cliente';
import { ClienteService } from 'src/app/servicios/servicio-de-cliente/cliente.service';
import { DetalleVenta } from 'src/app/seynekun/models/modelo-detalle-venta/detalle-venta';

@Component({
  selector: 'app-venta-registro',
  templateUrl: './venta-registro.component.html',
  styleUrls: ['./venta-registro.component.css']
})
export class VentaRegistroComponent implements OnInit {
  venta: Venta;
  cliente: Cliente;
  encontrado: Boolean
  detalles: DetalleVenta[] = [];
  detalle: DetalleVenta;
  ajusteInventario: AjusteDeInventario;
  formGroup: FormGroup;
  formGroupVenta: FormGroup;
  fechaHoy: Date;
  productos: Producto[];
  producto: Producto;
  bodegas: Bodega[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  codigoElemento: string;

  constructor(
    private ajusteInventarioService: AjusteInventarioService,
    private ventaService: VentaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private productoService: ProductoService,
    private clienteService: ClienteService,
    private bodegaService: BodegaService,
    private localeService: BsLocaleService) {
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.venta = new Venta;
    this.ajusteInventario = new AjusteDeInventario();
    this.obtenerBodegas();
    this.obtenerProductos();
    this.crearFormulario();
    this.formularioVenta();
    this.localeService.use("es");
  }

  crearFormulario() {
    this.ajusteInventario.codigo = '';
    //this.ajusteInventario.tipoElemento = '';
    this.ajusteInventario.codigoElemento = '';
    this.ajusteInventario.fecha = new Date();
    this.ajusteInventario.codigo = '';
    this.ajusteInventario.descipcion = '';
    this.ajusteInventario.cantidad = 0;
    this.ajusteInventario.nombreBodega = '';

    this.formGroup = this.formBuilder.group({
      codigo: [this.ajusteInventario.codigo, Validators.required],
      //tipoElemento: [this.ajusteInventario.tipoElemento, Validators.required],
      clienteId: [this.ajusteInventario.codigoElemento, Validators.required],
      fecha: [this.ajusteInventario.fecha, Validators.required],
      tipo: [this.ajusteInventario.tipo, Validators.required],
      descipcion: [this.ajusteInventario.descipcion],
      cantidad: [this.ajusteInventario.cantidad, Validators.required],
      codigoVenta: [this.ajusteInventario.nombreBodega, Validators.required]
    });
  }

  formularioVenta(){
    this.venta.codigoVenta = ''
    this.venta.clienteId = ''
    this.venta.fecha = new Date()
    this.venta.observacion = ''
    this.venta.totalVenta = 0

    this.formGroupVenta = this.formBuilder.group({
      codigoVenta: [this.venta.codigoVenta,Validators.required],
      clienteId: [this.venta.clienteId,Validators.required],
      fecha: [this.venta.fecha,Validators.required],
      observacion: [this.venta.observacion,Validators.required],
      totalVenta: [this.venta.totalVenta,Validators.required]
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

  get controlVenta() {
    return this.formGroupVenta.controls;
  }


  onSubmit() {
    if (this.formGroup.invalid) {
      console.log(this.control.codigoAjuste);
    } else {
      this.registrar();
    }
  }

  buscarCliente(){
    const id = this.controlVenta.clienteId.value;
    this.clienteService.get(id).subscribe((result) => {
      if(result != null){
        this.cliente = result;
        const fullName = result.nombre+" "+result.apellido;
        this.controlVenta.clienteId.setValue(fullName);
      }
    });
  }

  generarDetalle(){
    this.detalle = new DetalleVenta;
    this.detalle.codigoDetalle = "123";
    this.detalle.codigoVenta = this.venta.codigoVenta;
    this.detalle.codigoProducto = this.producto.codigo;
    this.detalle.total = 10999;
    this.detalle.cantidadProducto = 9;
    this.detalles.push(this.detalle);
  }

  registrarVenta(){
    this.venta = new Venta();
    this.venta.codigoVenta = "11111";
    this.venta.clienteId = this.cliente.identificacion;
    this.venta.fecha = new Date();
    this.venta.observacion = "Probando";
    this.venta.totalVenta = 10999;
    this.generarDetalle();
    console.log(this.cliente);
    console.log(this.producto);
    
    this.venta.detallesVentas = this.detalles;
    this.ventaService.post(this.venta).subscribe((e) => {
      this.venta = e;
    });
    console.log(this.venta);
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
}
