import { Component } from "@angular/core";
import { BodegaService } from "../servicios/servicio-bodega/bodega.service";
import { ProductoService } from "../servicios/servicio-producto/producto.service";
import { Bodega } from "../seynekun/models/modelo-bodega/bodega";
import { Producto } from "../seynekun/models/modelo-producto/producto";
import { Usuario } from "../seynekun/models/modelo-usuario/usuario";
import { AutenticacionService } from "../servicios/servicio-autenticacion/autenticacion.service";
import { Router } from "@angular/router";
import { MateriaPrima } from "../seynekun/models/modelo-materia-prima/materia-prima";
import { MateriaPrimaService } from "../servicios/servicio-materia/materia-prima.service";
import { VentaService } from "../servicios/servicio-venta/venta.service";
import { SolicitudService } from "../servicios/servicio-solicitud/solicitud.service";

import * as Chart from 'chart.js';
import { ProductStockService } from "../servicios/servicio-producto-stock/producto-stock.service";
import { ProductoEnBodega } from "../seynekun/models/modelo-producto-bodega/producto-en-bodega";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  canvas: any
  ctx: any
  bodegas: Bodega[];
  materiaPrimaProductor: MateriaPrima[];
  cantidadProcesada: number = 20;
  materiaPrimaProductorTraida: boolean;
  sumaMateriaMensualGeneral: number;
  sumaMateriaDiariaGeneral: number;
  sumaMateriaDiariaProductor: number;
  sumaCantidadSolicitud: number;
  sumaMateriaMensualProductor: number;
  sumaVentaDiaria: number;
  productosEnBodega: ProductoEnBodega[];
  nombreBodegaSeleccionada: string
  sumaCafeProductor: number;
  sumaCanaProductor: number;
  sumaCacaoProductor: number
  sumaMateriaDiariaCafe: number;
  sumaMateriaDiariaCanaAzucar: number
  sumaVentaDiariaConsultada: boolean;
  sumaMateriaDiariaConsultada: boolean;
  productosAdmin: Producto[];
  usuario: Usuario;
  bodegasTraidas: boolean;
  sumaCantidadCacao: number
  productosTraidos: boolean;
  sumaSolicitudConsultada: boolean
  constructor(
    private productoStockService: ProductStockService,
    private bodegaService: BodegaService,
    private materiaPrimaService: MateriaPrimaService,
    private ventaService: VentaService,
    private router: Router,
    private autenticacionServicio: AutenticacionService,
    private solicitudService: SolicitudService
  ) {
    this.autenticacionServicio.currentUser.subscribe((x) => (this.usuario = x));
  }
  ngOnInit(): void {
    this.obtenerBodegas();
    this.obtenerProductosEnBodega();
    this.obtenerMateriaPrima();
    this.obtenerSumaMateriaPrimaProductorMensual();
    this.obtenerSumaMateriaCafe();
    this.obtenerSumaMateriaCana();
    this.obtenerSumaVentaDiaria();
    this.obtenerSumaSolicitud();
    this.obtenerCantidadCacao();
  }

  obtenerSumaSolicitud() {
    this.solicitudService.getCantidadSolicitud().subscribe((suma) => {
      this.sumaCantidadSolicitud = suma
      this.sumaSolicitudConsultada = true
    })
  }
  obtenerBodegas() {
    this.bodegaService.gets().subscribe((result) => {
      this.bodegas = result;
      this.bodegasTraidas = true;
    });
  }
  obtenerMateriaPrima() {
    this.materiaPrimaService.get(this.usuario.id).subscribe((result) => {
      this.materiaPrimaProductor = result;
      this.materiaPrimaProductorTraida = true;
    });
  }
  obtenerSumaMateriaPrimaGeneralMensual() {
    this.materiaPrimaService.getCantidadMensual().subscribe((result) => {
      this.sumaMateriaMensualGeneral = result;
    });
  }
  obtenerSumaVentaDiaria() {
    this.ventaService.getCantidadDiaria().subscribe((result) => {
      this.sumaVentaDiaria = result;
      this.sumaVentaDiariaConsultada = true;
    });
  }
  obtenerSumaMateriaPrimaGeneralDiaria() {
    this.materiaPrimaService.getCantidadDiaria().subscribe((result) => {
      this.sumaMateriaDiariaGeneral = result;
      this.sumaMateriaDiariaConsultada = true;
    });
  }
  obtenerCantidadCacao() {
    this.materiaPrimaService.getCantidadCacao().subscribe((result) => {
      this.sumaCantidadCacao = result;
    });
    this.materiaPrimaService.getCantidadCacaoxProductor(this.usuario.id).subscribe((result) => (this.sumaCacaoProductor = result))
  }
  obtenerSumaMateriaPrimaProductorMensual() {
    this.materiaPrimaService
      .getCantidadMensualProductor(this.usuario.id)
      .subscribe((result) => {
        this.sumaMateriaMensualProductor = result;
        this.sumaMateriaDiariaConsultada = true;
      });
  }
  obtenerSumaMateriaCafe() {
    this.materiaPrimaService.getCantidadDiariaCafe().subscribe((result) => (this.sumaMateriaDiariaCafe = result));
    this.materiaPrimaService.getCantidadDiariaCafexProductor(this.usuario.id).subscribe((result) => (this.sumaCafeProductor = result
    ))
  }

  obtenerSumaMateriaCana() {
    this.materiaPrimaService.getCantidadDiariaCana().subscribe((result) => (this.sumaMateriaDiariaCanaAzucar = result));
    this.materiaPrimaService.getCantidadDiariaCanaxProductor(this.usuario.id).subscribe((result) => (this.sumaCanaProductor = result));
  }
  cambiarBodega(e) {
    this.nombreBodegaSeleccionada = e.target.value;
    this.obtenerProductosEnBodega();
  }
  private obtenerProductosEnBodega() {
    this.productoStockService.get(this.nombreBodegaSeleccionada).subscribe((result) => {
      this.productosEnBodega = result;
      this.graficar(result);
    });
  }
  randomColor(lista: String[]) {
    return lista[Math.floor(Math.random() * lista.length)]
  }
  graficar(productos: ProductoEnBodega[]) {
    var colorProductos = [];
    var nameProduct = []
    var cantidad = []
    var colores = [];
    var r = new Array("2C", "44", "33");
    var g = new Array("CF", "FF", "DF");
    var b = new Array("87", "55", "50");
    for (var i = 0; i < r.length; i++) {
      for (var j = 0; j < g.length; j++) {
        for (var k = 0; k < b.length; k++) {
          var nuevoc = "#" + r[i] + g[j] + b[k];
          colores.push(nuevoc);
        }
      }
    }
    productos.forEach(element => {
      colorProductos.push(this.randomColor(colores));
      nameProduct.push(element.producto.nombre)
      cantidad.push(element.cantidad)
    });
    console.log(colores)
    console.log("-----------")
    console.log(colorProductos)
    nameProduct.push('');
    cantidad.push(0);
    var ctx = document.getElementById("myChart");
    var myPieChart = new Chart(ctx, {
      type: 'bar',
      data: {
        labels: nameProduct,
        datasets: [{
          data: cantidad,
          backgroundColor: colorProductos,
          hoverBackgroundColor: ['#169e6e', '#1dc789', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f', '#1cb87f'],
          hoverBorderColor: "rgba(234, 236, 244, 1)",
        }],
      },
      options: {
        maintainAspectRatio: false,
        tooltips: {
          backgroundColor: "#000",
          bodyFontColor: "#858796",
          borderColor: '#dddfeb',
          borderWidth: 0,
          xPadding: 15,
          yPadding: 15,
          displayColors: false,
          caretPadding: 10,
        },
        barThickness: "flex",
        legend: {
          display: false
        },
        cutoutPercentage: 80,
      },
    });
  }
}
