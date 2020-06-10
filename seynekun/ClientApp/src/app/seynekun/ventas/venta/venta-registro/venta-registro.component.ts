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

@Component({
  selector: 'app-venta-registro',
  templateUrl: './venta-registro.component.html',
  styleUrls: ['./venta-registro.component.css']
})
export class VentaRegistroComponent implements OnInit {
  venta: Venta;
  ajusteInventario: AjusteDeInventario;
  formGroup: FormGroup;
  fechaHoy: Date;
  productos: Producto[];
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
    private bodegaService: BodegaService,
    private localeService: BsLocaleService) {
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
      codigoElemento: [this.ajusteInventario.codigoElemento, Validators.required],
      fecha: [this.ajusteInventario.fecha, Validators.required],
      tipo: [this.ajusteInventario.tipo, Validators.required],
      descipcion: [this.ajusteInventario.descipcion],
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
