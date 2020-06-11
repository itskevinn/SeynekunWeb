import { Component } from '@angular/core';
import { BodegaService } from '../servicios/servicio-bodega/bodega.service';
import { ProductoService } from '../servicios/servicio-producto/producto.service';
import { Bodega } from '../seynekun/models/modelo-bodega/bodega';
import { Producto } from '../seynekun/models/modelo-producto/producto';
import { Usuario } from '../seynekun/models/modelo-usuario/usuario';
import { AutenticacionService } from '../servicios/servicio-autenticacion/autenticacion.service';
import { Router } from '@angular/router';
import { MateriaPrima } from '../seynekun/models/modelo-materia-prima/materia-prima';
import { MateriaPrimaService } from '../servicios/servicio-materia/materia-prima.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  bodegas: Bodega[];
  materiaPrimaProductor: MateriaPrima[];
  cantidadProcesada: number = 20;
  materiaPrimaProductorTraida: boolean;
  sumaMateriaPrima: number;
  productosAdmin: Producto[];
  usuario: Usuario;
  bodegasTraidas: boolean;
  productosTraidos: boolean;
  constructor(
    private productoService: ProductoService,
    private bodegaService: BodegaService,
    private materiaPrimaService: MateriaPrimaService,
    private router: Router,
    private autenticacionServicio: AutenticacionService) {
    this.autenticacionServicio.currentUser.subscribe(x => this.usuario = x);
  }
  ngOnInit(): void {
    this.obtenerBodegas();
    this.obtenerProductos();
    this.obtenerMateriaPrima();
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
    })
  }

  obtenerProductos() {
    this.productoService.gets().subscribe((result) => {
      this.productosAdmin = result;
      this.productosTraidos = true;
    });
  }
}
