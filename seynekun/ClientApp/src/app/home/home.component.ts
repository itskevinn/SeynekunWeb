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
  sumaCantidadSolicitud: number;
  sumaMateriaMensualProductor: number;
  sumaVentaDiaria: number;
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
    private productoService: ProductoService,
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
    this.obtenerProductos();
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
    this.materiaPrimaService.getCantidadCacaoxProductor(this.usuario.id).subscribe((result)=>(this.sumaCacaoProductor = result))
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
  obtenerProductos() {
    this.productoService.gets().subscribe((result) => {
      this.productosAdmin = result;
      this.productosTraidos = true;
    });
  }
}
