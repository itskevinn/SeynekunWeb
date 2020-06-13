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

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  bodegas: Bodega[];
  materiaPrimaProductor: MateriaPrima[];
  cantidadProcesada: number = 20;
  materiaPrimaProductorTraida: boolean;
  sumaMateriaMensualGeneral: number;
  sumaMateriaDiariaGeneral: number;
  sumaMateriaDiariaProductor: number;
  sumaMateriaMensualProductor: number;
  sumaVentaDiaria: number;
  sumaVentaDiariaConsultada: boolean;
  sumaMateriaDiariaConsultada: boolean;
  productosAdmin: Producto[];
  usuario: Usuario;
  bodegasTraidas: boolean;
  productosTraidos: boolean;
  constructor(
    private productoService: ProductoService,
    private bodegaService: BodegaService,
    private materiaPrimaService: MateriaPrimaService,
    private ventaService: VentaService,
    private router: Router,
    private autenticacionServicio: AutenticacionService
  ) {
    this.autenticacionServicio.currentUser.subscribe((x) => (this.usuario = x));
  }
  ngOnInit(): void {
    this.obtenerBodegas();
    this.obtenerProductos();
    this.obtenerMateriaPrima();
    this.obtenerSumaMateriaPrimaProductorMensual();
    this.obtenerSumaMateriaPrimaGeneralDiaria();
    this.obtenerSumaMateriaPrimaGeneralMensual();
    this.obtenerSumaVentaDiaria();
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
  obtenerSumaMateriaPrimaProductorMensual() {
    this.materiaPrimaService
      .getCantidadMensualProductor(this.usuario.id)
      .subscribe((result) => {
        this.sumaMateriaMensualProductor = result;
        this.sumaMateriaDiariaConsultada = true;
      });
  }
  obtenerSumaMateriaPrimaProductorDiaria() {
    this.materiaPrimaService
      .getCantidadDiariaProductor(this.usuario.id)
      .subscribe((result) => {
        this.sumaMateriaDiariaProductor = result;
      });
  }
  obtenerProductos() {
    this.productoService.gets().subscribe((result) => {
      this.productosAdmin = result;
      this.productosTraidos = true;
    });
  }
}
