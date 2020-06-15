import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { Routes, RouterModule } from '@angular/router'
import { LoteRegistroComponent } from './seynekun/lote/lote-registro/lote-registro.component'
import { LoteConsultaComponent } from './seynekun/lote/lote-consulta/lote-consulta.component'
import { ProductorRegistroComponent } from './seynekun/productor/productor-registro/productor-registro.component'
import { ProductorConsultaComponent } from './seynekun/productor/productor-consulta/productor-consulta.component'
import { ProductorEdicionComponent } from './seynekun/productor/productor-edicion/productor-edicion.component'
import { EmpleadoConsultaComponent } from './seynekun/empleado/empleado-consulta/empleado-consulta.component'
import { EmpleadoRegistroComponent } from './seynekun/empleado/empleado-registro/empleado-registro.component'
import { EmpleadoEdicionComponent } from './seynekun/empleado/empleado-edicion/empleado-edicion.component'
import { ClienteConsultaComponent } from './seynekun/cliente/cliente-consulta/cliente-consulta.component'
import { ClienteEdicionComponent } from './seynekun/cliente/cliente-edicion/cliente-edicion.component'
import { ClienteRegistroComponent } from './seynekun/cliente/cliente-registro/cliente-registro.component'
import { EmpleadoVistaComponent } from './seynekun/empleado/empleado-vista/empleado-vista.component'
import { ClienteVistaComponent } from './seynekun/cliente/cliente-vista/cliente-vista.component'
import { ProductorVistaComponent } from './seynekun/productor/productor-vista/productor-vista.component'
import { ProductoConsultaComponent } from './seynekun/inventario/producto/producto-consulta/producto-consulta.component'
import { ProductoEdicionComponent } from './seynekun/inventario/producto/producto-edicion/producto-edicion.component'
import { ProductoRegistroComponent } from './seynekun/inventario/producto/producto-registro/producto-registro.component'
import { ProductoVistaComponent } from './seynekun/inventario/producto/producto-vista/producto-vista.component'

import { AjusteInventarioConsultaComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-consulta/ajuste-inventario-consulta/ajuste-inventario-consulta.component'
import { AjusteInventarioVistaComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-vista/ajuste-inventario-vista/ajuste-inventario-vista.component'

import { AjusteInventarioEdicionComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-Edicion/ajuste-inventario-edicion/ajuste-inventario-edicion.component'
import { ReporteInventarioComponent } from './seynekun/inventario/reporte-inventario/reporte-inventario.component'
import { FabricanteRegistroComponent } from './seynekun/fabricante/fabricante-registro/fabricante-registro/fabricante-registro.component'
import { FabricanteEdicionComponent } from './seynekun/fabricante/fabricante-edicion/fabricante-edicion/fabricante-edicion.component'
import { FabricanteConsultaComponent } from './seynekun/fabricante/fabricante-consulta/fabricante-consulta/fabricante-consulta.component'
import { FabricanteVistaComponent } from './seynekun/fabricante/fabricante-vista/fabricante-vista/fabricante-vista.component'
import { InsumoConsultaComponent } from './seynekun/inventario/insumo/insumo-consulta/insumo-consulta/insumo-consulta.component'
import { InsumoVistaComponent } from './seynekun/inventario/insumo/insumo-vista/insumo-vista/insumo-vista.component'
import { InsumoEdicionComponent } from './seynekun/inventario/insumo/insumo-edicion/insumo-edicion/insumo-edicion.component'
import { FichaTecnicaVistaComponent } from './seynekun/inventario/insumo/ficha-tecnica/fecha-tecnica-vista/ficha-tecnica-vista/ficha-tecnica-vista.component'
import { FichaTecnicaRegistroComponent } from './seynekun/inventario/insumo/ficha-tecnica/fecha-tecnica-registro/ficha-tecnica-registro/ficha-tecnica-registro.component'
import { BodegaConsultaComponent } from './seynekun/inventario/bodega/bodega-consulta/bodega-consulta/bodega-consulta.component'
import { BodegaVistaComponent } from './seynekun/inventario/bodega/bodega-vista/bodega-vista/bodega-vista.component'
import { BodegaEdicionComponent } from './seynekun/inventario/bodega/bodega-edicion/bodega-edicion/bodega-edicion.component'
import { BodegaRegistroComponent } from './seynekun/inventario/bodega/bodega-registro/bodega-registro/bodega-registro.component'
import { CategoriaRegistroComponent } from './seynekun/inventario/categoria/categoria-registro/categoria-registro/categoria-registro.component'
import { CategoriaConsultaComponent } from './seynekun/inventario/categoria/categoria-consulta/categoria-consulta/categoria-consulta.component'
import { CategoriaVistaComponent } from './seynekun/inventario/categoria/categoria-vista/categoria-vista/categoria-vista.component'
import { CategoriaEdicionComponent } from './seynekun/inventario/categoria/categoria-edicion/categoria-edicion/categoria-edicion.component'
import { ProductosBodegaComponent } from './seynekun/inventario/bodega/bodega-productos-vista/productos-bodega/productos-bodega.component'
import { ProductosCategoriaComponent } from './seynekun/inventario/categoria/categoria-productos-vista/productos-categoria/productos-categoria.component'
import { AjusteInventarioRegistroComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-registro/ajuste-inventario-registro/ajuste-inventario-registro.component'
import { LoginComponent } from './login/login/login.component'
import { TransportadorRegistroComponent } from './seynekun/transportes/transportador/transportador-registro/transportador-registro.component'
import { TransportadorConsultaComponent } from './seynekun/transportes/transportador/transportador-consulta/transportador-consulta.component'
import { TransportadorVistaComponent } from './seynekun/transportes/transportador/transportador-vista/transportador-vista.component'
import { TransportadorEdicionComponent } from './seynekun/transportes/transportador/transportador-edicion/transportador-edicion.component'
import { TrasladosRegistroComponent } from './seynekun/transportes/traslados/traslados-registro/traslados-registro.component'
import { TrasladosConsultaComponent } from './seynekun/transportes/traslados/traslados-consulta/traslados-consulta.component'
import { TrasladosVistaComponent } from './seynekun/transportes/traslados/traslados-vista/traslados-vista.component'
import { TrasladosEdicionComponent } from './seynekun/transportes/traslados/traslados-edicion/traslados-edicion.component'
import { VentaRegistroComponent } from './seynekun/ventas/venta/venta-registro/venta-registro.component'
import { VentaConsultaComponent } from './seynekun/ventas/venta/venta-consulta/venta-consulta.component'
import { VentaVistaComponent } from './seynekun/ventas/venta/venta-vista/venta-vista.component'
import { VentaEdicionComponent } from './seynekun/ventas/venta/venta-edicion/venta-edicion.component'
import { MateriaRegistroComponent } from './seynekun/inventario/materia-prima/materia-registro/materia-registro/materia-registro.component'
import { MateriaConsultaComponent } from './seynekun/inventario/materia-prima/materia-consulta/materia-consulta/materia-consulta.component'
import { MateriaEdicionComponent } from './seynekun/inventario/materia-prima/materia-edicion/materia-edicion/materia-edicion.component'
import { MateriaVistaComponent } from './seynekun/inventario/materia-prima/materia-vista/materia-vista/materia-vista.component'
import { MateriaPrimaProductorComponent } from './seynekun/inventario/materia-prima/materia-prima-productor/materia-prima-productor.component'
import { MateriaPrimaProductorVistaComponent } from './seynekun/inventario/materia-prima/materia-prima-productor/materia-prima-productor-vista/materia-prima-productor-vista.component'
import { ProductosMateriaProductorComponent } from './seynekun/inventario/materia-prima/productos-materia-productor/productos-materia-productor.component'
import { AuthGuard } from './servicios/guard/auth.guard'
import { SolicitudRegistroComponent } from './seynekun/solicitud/solicitud-registro/solicitud-registro/solicitud-registro.component'
import { SolicitudConsultaComponent } from './seynekun/solicitud/solicitud-consulta/solicitud-consulta.component'
import { ControlRegistroComponent } from './seynekun/controles/control/control-registro/control-registro.component'
import { ControlConsultaComponent } from './seynekun/controles/control/control-consulta/control-consulta.component'
import { ControlVistaComponent } from './seynekun/controles/control/control-vista/control-vista.component'
import { ControlEdicionComponent } from './seynekun/controles/control/control-edicion/control-edicion.component'

const routes: Routes = [
  { path: 'RegistrarProductor', component: ProductorRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Productores', component: ProductorConsultaComponent, canActivate: [AuthGuard] },
  { path: 'EditarProductor/:id', component: ProductorEdicionComponent, canActivate: [AuthGuard] },
  { path: 'Productor/:id', component: ProductorVistaComponent, canActivate: [AuthGuard] },
  { path: 'Empleados', component: EmpleadoConsultaComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarEmpleado', component: EmpleadoRegistroComponent, canActivate: [AuthGuard] },
  { path: 'EditarEmpleado/:id', component: EmpleadoEdicionComponent, canActivate: [AuthGuard] },
  { path: 'Empleado/:id', component: EmpleadoVistaComponent, canActivate: [AuthGuard] },
  { path: 'Clientes', component: ClienteConsultaComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarCliente', component: ClienteRegistroComponent, canActivate: [AuthGuard] },
  { path: 'EditarCliente/:id', component: ClienteEdicionComponent, canActivate: [AuthGuard] },
  { path: 'Cliente/:id', component: ClienteVistaComponent, canActivate: [AuthGuard] },
  { path: 'Productos', component: ProductoConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Producto/:id', component: ProductoVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarProducto/:id', component: ProductoEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarProducto', component: ProductoRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Reporte-De-Inventario', component: ReporteInventarioComponent, canActivate: [AuthGuard] },
  { path: 'AjustesDeInventario', component: AjusteInventarioConsultaComponent, canActivate: [AuthGuard] },
  { path: 'AjusteDeInventario/:id', component: AjusteInventarioVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarAjusteDeInventario/:id', component: AjusteInventarioEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarAjusteInventario', component: AjusteInventarioRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Fabricantes', component: FabricanteConsultaComponent, canActivate: [AuthGuard] },
  { path: 'EditarFabricante/:id', component: FabricanteEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarFabricante', component: FabricanteRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Insumos', component: InsumoConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Insumo/:id', component: InsumoVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarInsumo/:id', component: InsumoEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarInsumo/:id', component: FabricanteVistaComponent, canActivate: [AuthGuard] },
  { path: 'FichaTecnica', component: FichaTecnicaVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarFichaTecnica', component: FichaTecnicaVistaComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarFichaTecnica', component: FichaTecnicaRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Bodegas', component: BodegaConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Bodega/:id', component: BodegaVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarBodega/:id', component: BodegaEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarBodega', component: BodegaRegistroComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarCategoria', component: CategoriaRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Categorias', component: CategoriaConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Categoria/:id', component: CategoriaVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarCategoria/:id', component: CategoriaEdicionComponent, canActivate: [AuthGuard] },
  { path: 'ProductosEnBodega/:id', component: ProductosBodegaComponent, canActivate: [AuthGuard] },
  { path: 'ProductosEnCategoria/:id', component: ProductosCategoriaComponent, canActivate: [AuthGuard] },
  { path: 'Login', component: LoginComponent },
  { path: 'RegistrarTransportador', component: TransportadorRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Transportadores', component: TransportadorConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Transportador/:id', component: TransportadorVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarTransportador/:id', component: TransportadorEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarTraslado', component: TrasladosRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Traslados', component: TrasladosConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Traslado/:id', component: TrasladosVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarTraslado/:id', component: TrasladosEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarVenta', component: VentaRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Ventas', component: VentaConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Venta/:id', component: VentaVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarVenta/:id', component: VentaEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarTransportador', component: TransportadorRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Transportadores', component: TransportadorConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Transportador/:id', component: TransportadorVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarTransportador/:id', component: TransportadorEdicionComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarTraslado', component: TrasladosRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Traslados', component: TrasladosConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Traslado/:id', component: TrasladosVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarTraslado/:id', component: TrasladosEdicionComponent, canActivate: [AuthGuard] },
  { path: 'MateriasPrima', component: MateriaConsultaComponent, canActivate: [AuthGuard] },
  { path: 'RegistroMateriaPrima', component: MateriaRegistroComponent, canActivate: [AuthGuard] },
  { path: 'EditarMateriaPrima/:id', component: MateriaEdicionComponent, canActivate: [AuthGuard] },
  { path: 'MateriaPrima/:id', component: MateriaVistaComponent, canActivate: [AuthGuard] },
  { path: 'ConsultarMateria/:id', component: MateriaPrimaProductorComponent, canActivate: [AuthGuard] },
  { path: 'ProductorMateriaPrima/:id', component: MateriaPrimaProductorVistaComponent, canActivate: [AuthGuard] },
  { path: 'ProductosMateriaPrima/:id', component: ProductosMateriaProductorComponent, canActivate: [AuthGuard] },
  { path: 'SolicitarRegistro', component: SolicitudRegistroComponent },
  { path: 'SolicitudesPendientes', component: SolicitudConsultaComponent, canActivate: [AuthGuard] },
  { path: 'RegistrarControl', component: ControlRegistroComponent, canActivate: [AuthGuard] },
  { path: 'Controles', component: ControlConsultaComponent, canActivate: [AuthGuard] },
  { path: 'Control/:id', component: ControlVistaComponent, canActivate: [AuthGuard] },
  { path: 'EditarControl/:id', component: ControlEdicionComponent, canActivate: [AuthGuard] }
]

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
