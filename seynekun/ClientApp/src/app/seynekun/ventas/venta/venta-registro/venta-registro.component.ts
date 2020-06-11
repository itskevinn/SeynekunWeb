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
import { ProductoEnBodega } from 'src/app/seynekun/models/modelo-producto-bodega/producto-en-bodega';
import { ProductStockService } from 'src/app/servicios/servicio-producto-stock/producto-stock.service';

@Component({
  selector: 'app-venta-registro',
  templateUrl: './venta-registro.component.html',
  styleUrls: ['./venta-registro.component.css']
})
export class VentaRegistroComponent implements OnInit {
  venta: Venta;
  cliente: Cliente;
  productoEnBodegas: ProductoEnBodega[] = [];
  detalles: DetalleVenta[] = [];
  nombreBodegaSeleccionada: string;
  textoABuscar: string;
  textoCantidad: string;
  totalTemp: Number = 0;

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
    private productoStockService: ProductStockService,
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
    this.ajusteInventario.tipoAjuste = '';
    this.ajusteInventario.cantidad = 0;
    this.ajusteInventario.nombreBodega = '';

    this.formGroup = this.formBuilder.group({
      codigo: [this.ajusteInventario.codigo, Validators.required],
      //tipoElemento: [this.ajusteInventario.tipoElemento, Validators.required],
      clienteId: [this.ajusteInventario.codigoElemento, Validators.required],
      fecha: [this.ajusteInventario.fecha, Validators.required],
      tipoAjuste: [this.ajusteInventario.tipoAjuste, Validators.required],
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
    this.venta.totalVenta = null
    this.venta.detallesVentas = null
    this.formGroupVenta = this.formBuilder.group({
      codigoVenta: [this.venta.codigoVenta,Validators.required],
      clienteId: [this.venta.clienteId,Validators.required],
      fecha: [this.venta.fecha,Validators.required],
      observacion: [this.venta.observacion,Validators.required],
      totalVenta: [this.venta.totalVenta,Validators.required],
      detallesVentas: [this.venta.detallesVentas,Validators.required]
    });
  }

  obtenerBodegas(){
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
    });
  }
  cambiarBodega(e){
    this.nombreBodegaSeleccionada = e.target.value;
    this.obtenerProductosEnBodega();
  }
  private obtenerProductosEnBodega(){
    this.productoStockService.get(this.nombreBodegaSeleccionada).subscribe((result) => {
      this.productoEnBodegas = result;
    });
  }

  agregarDetalle(productoSeleccionado: ProductoEnBodega){
    if(this.textoCantidad != ""){
      this.detalle = new DetalleVenta;
      this.detalle.codigoDetalle = String(this.detalles.length);
      this.detalle.codigoVenta = this.controlVenta.codigoVenta.value;
      this.detalle.codigoProducto = productoSeleccionado.producto.codigo;
      this.detalle.cantidadProducto = Number(this.textoCantidad);
      this.detalle.totalDetalle = this.detalle.cantidadProducto * productoSeleccionado.producto.precio;
      console.log(this.detalle.totalDetalle);
      this.detalles.push(this.detalle);
      this.controlVenta.detallesVentas.setValue(this.detalles);
      this.calcularTotal();
    }
  }

  get control() {
    return this.formGroup.controls;
  }

  get controlVenta() {
    return this.formGroupVenta.controls;
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

  calcularTotal(){
    this.venta.totalVenta = 0;
    for(let dett of this.detalles){
      this.venta.totalVenta += dett.totalDetalle;
    }
    this.controlVenta.totalVenta.setValue(this.venta.totalVenta);
  }
  onSubmit() {
    if (this.formGroupVenta.invalid) {
    } else {
      this.registrar();
    }
  }
  registrar(){
    this.venta = this.formGroupVenta.value;
    this.venta.clienteId = this.cliente.identificacion;
    this.ventaService.post(this.venta).subscribe((v) => {
      if (v != null) {
        this.venta = v;
        this.formGroupVenta.reset();
      }
    });
  }
}
