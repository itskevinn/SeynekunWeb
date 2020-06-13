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
import { EmpleadoService } from 'src/app/servicios/servicio-de-empleado/empleado.service';
import { Empleado } from 'src/app/seynekun/models/modelo-empleado/empleado';
import { AlertaModalErrorComponent } from 'src/app/@base/alerta-modal-error/alerta-modal-error.component';

@Component({
  selector: 'app-venta-registro',
  templateUrl: './venta-registro.component.html',
  styleUrls: ['./venta-registro.component.css']
})
export class VentaRegistroComponent implements OnInit {
  venta: Venta;
  cliente: Cliente;
  bodegas: Bodega[];
  empleados: Empleado[];
  productoEnBodegas: ProductoEnBodega[] = [];
  detalles: DetalleVenta[] = [];
  nombreBodegaSeleccionada: string;
  textoABuscar: string;
  numberCantidad: number = 1;
  producto: Producto;

  ajusteInventario: AjusteDeInventario;
  formGroup: FormGroup;
  formGroupVenta: FormGroup;
  fechaHoy: Date;
  productos: Producto[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  codigoElemento: string;

  constructor(
    private ventaService: VentaService,
    private productoStockService: ProductStockService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private clienteService: ClienteService,
    private empleadoService: EmpleadoService,
    private bodegaService: BodegaService,
    private localeService: BsLocaleService) {
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.venta = new Venta;
    this.obtenerBodegas();
    this.obtenerEmpleados();
    this.formularioVenta();
    this.getCodigo();
    this.localeService.use("es");
  }

  formularioVenta() {
    this.venta.codigoVenta = ''
    this.venta.clienteId = ''
    this.venta.empleadoId = ''
    this.venta.fecha = new Date()
    this.venta.observacion = ''
    this.venta.totalVenta = null
    this.venta.detallesVentas = null
    this.formGroupVenta = this.formBuilder.group({
      codigoVenta: [this.venta.codigoVenta, Validators.required],
      clienteId: [this.venta.clienteId, Validators.required],
      fecha: [this.venta.fecha, Validators.required],
      observacion: [this.venta.observacion, Validators.required],
      totalVenta: [this.venta.totalVenta, Validators.required],
      detallesVentas: [this.venta.detallesVentas, Validators.required],
      empleadoId: [this.venta.empleadoId, Validators.required]
    });
  }

  buscarCliente() {
    const id = this.controlVenta.clienteId.value;
    this.clienteService.get(id).subscribe((result) => {
      if (result != null) {
        this.cliente = result;
        const fullName = result.nombre + " " + result.apellido;
        this.controlVenta.clienteId.setValue(fullName);
      }
    });
  }
  obtenerEmpleados() {
    this.empleadoService.gets().subscribe((result) => {
      this.empleados = result;
    });
  }
  cambiarEmpleado(e) {
    this.controlVenta.empleadoId.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  obtenerBodegas() {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
    });
  }
  cambiarBodega(e) {
    this.nombreBodegaSeleccionada = e.target.value;
    this.obtenerProductosEnBodega();
  }
  private obtenerProductosEnBodega() {
    this.productoStockService.get(this.nombreBodegaSeleccionada).subscribe((result) => {
      this.productoEnBodegas = result;
    });
  }

  agregarDetalle(productoSelect: ProductoEnBodega){
    if (this.validarCantidad(this.numberCantidad, productoSelect.cantidad)){
      var detalle = new DetalleVenta;
      detalle.codigoDetalle = String(this.detalles.length) + this.controlVenta.codigoVenta.value;
      detalle.codigoVenta = this.controlVenta.codigoVenta.value;
      detalle.codigoProducto = productoSelect.producto.codigo;
      detalle.nombreProducto = productoSelect.producto.nombre;
      detalle.valorProducto = productoSelect.producto.precio;
      detalle.cantidadProducto = this.numberCantidad;
      detalle.totalDetalle = detalle.cantidadProducto * productoSelect.producto.precio;
      detalle.nombreBodega = this.nombreBodegaSeleccionada;
      productoSelect.cantidad -= this.numberCantidad;
      this.updateDetails(this.detalles,detalle);
    }
  }
  validarCantidad(cantidad, limite){
    if(cantidad <1){
      const modalRef = this.modalService.open(AlertaModalErrorComponent);
      modalRef.componentInstance.titulo = 'Error en la cantidad del producto agregado';
      modalRef.componentInstance.mensaje = 'Digite una cantidad mayor 1';
      return false;
    }else if(cantidad > limite){
      const modalRef = this.modalService.open(AlertaModalErrorComponent);
      modalRef.componentInstance.titulo = 'Error en la cantidad del producto agregado';
      modalRef.componentInstance.mensaje = 'La cantidad digita no puede superar a la del producto';
      return false;
    }
    return true;
  }
  updateDetails(details, detail){
    var encontrado = true;
    const codigo = detail.codigoProducto;
    let pos = 0;
    
    for(let dett of details){
      if(dett.codigoProducto === codigo){
        encontrado = false;
        pos = details.indexOf(dett);
      }
    }

    if(encontrado){
      details.push(detail);
    }else{
      details[pos].cantidadProducto += detail.cantidadProducto;
      details[pos].totalDetalle = details[pos].cantidadProducto * detail.valorProducto;
    }
    this.calcularTotal();
    this.controlVenta.detallesVentas.setValue(details);
  }
  calcularTotal(){
    let total = 0;
    for (let dett of this.detalles){
      total += dett.totalDetalle;
    }
    this.controlVenta.totalVenta.setValue(total);
  }
  eliminarDetalle(detalleEliminar: DetalleVenta){
    var posicion = this.detalles.indexOf(detalleEliminar);
    this.detalles.splice(posicion,1);
    this.calcularTotal();
  }

  get controlVenta() {
    return this.formGroupVenta.controls;
  }

  onSubmit() {
    if (this.formGroupVenta.invalid) {
    } else {
      this.registrar();
    }
  }
  registrar() {
    this.venta = this.formGroupVenta.value;
    this.venta.clienteId = this.cliente.identificacion;
    this.ventaService.post(this.venta).subscribe((v) => {
      if (v != null) {
        this.venta = v;
        this.formGroupVenta.reset();
      }
    });
  }

  getCodigo()
  {
    this.ventaService.getCodigo().subscribe( c => {
      if(c != "")
      this.controlVenta.codigoVenta.setValue(c);
    });
  }
}
