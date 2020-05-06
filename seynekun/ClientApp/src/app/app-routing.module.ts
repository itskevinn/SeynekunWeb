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
import { AjusteInventarioRegistroComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-registro/ajuste-inventario-registro/ajuste-inventario-registro.component'
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

const routes: Routes = [
  {
    path: 'RegistrarLote',
    component: LoteRegistroComponent,
  },
  {
    path: 'ConsultarLote',
    component: LoteConsultaComponent,
  },
  { path: 'RegistrarProductor', component: ProductorRegistroComponent },
  { path: 'Productores', component: ProductorConsultaComponent },
  { path: 'EditarProductor/:id', component: ProductorEdicionComponent },
  { path: 'Productor/:id', component: ProductorVistaComponent },
  { path: 'Empleados', component: EmpleadoConsultaComponent },
  { path: 'RegistrarEmpleado', component: EmpleadoRegistroComponent },
  { path: 'EditarEmpleado/:id', component: EmpleadoEdicionComponent },
  { path: 'Empleado/:id', component: EmpleadoVistaComponent },
  { path: 'Clientes', component: ClienteConsultaComponent },
  { path: 'RegistrarCliente', component: ClienteRegistroComponent },
  { path: 'EditarCliente/:id', component: ClienteEdicionComponent },
  { path: 'Cliente/:id', component: ClienteVistaComponent },
  { path: 'Productos', component: ProductoConsultaComponent },
  { path: 'Producto/:id', component: ProductoVistaComponent },
  { path: 'EditarProducto/:id', component: ProductoEdicionComponent },
  { path: 'RegistrarProducto', component: ProductoRegistroComponent },
  { path: 'Reporte-De-Inventario', component: ReporteInventarioComponent },  
  { path: 'Ajustes-De-Inventario', component: AjusteInventarioConsultaComponent },  
  { path: 'Ajuste-De-Inventario/:id', component: AjusteInventarioVistaComponent },  
  { path: 'Editar-Ajuste-De-Inventario/:id', component: AjusteInventarioEdicionComponent },  
  { path: 'Añadir-Ajuste-De-Inventario', component: AjusteInventarioRegistroComponent },  
  { path: 'Fabricantes', component: FabricanteConsultaComponent },  
  { path: 'EditarFabricante/:id', component: FabricanteEdicionComponent },  
  { path: 'RegistrarFabricante', component: FabricanteRegistroComponent },  
  { path: 'Insumos', component: InsumoConsultaComponent },  
  { path: 'Insumo/:id', component: InsumoVistaComponent },  
  { path: 'EditarInsumo/:id', component: InsumoEdicionComponent },  
  { path: 'RegistrarInsumo/:id', component: FabricanteVistaComponent },  
  { path: 'FichaTecnica', component: FichaTecnicaVistaComponent },  
  { path: 'EditarFichaTecnica', component: FichaTecnicaVistaComponent },  
  { path: 'RegistrarFichaTecnica', component: FichaTecnicaRegistroComponent },  
  { path: 'Bodegas', component: BodegaConsultaComponent },  
  { path: 'Bodega/:id', component: BodegaVistaComponent },  
  { path: 'EditarBodega/:id', component: BodegaEdicionComponent },  
  { path: 'RegistrarBodega', component: BodegaRegistroComponent },  
  { path: 'RegistrarCategoria', component: CategoriaRegistroComponent },  
  { path: 'Categorias', component: CategoriaConsultaComponent },  
  { path: 'Categoria/:id', component: CategoriaVistaComponent },  
  { path: 'EditarCategoria/:id', component: CategoriaEdicionComponent },  
  { path: 'ProductosEnBodega/:id', component: ProductosBodegaComponent },  
  { path: 'ProductosEnCategoria/:id', component: ProductosCategoriaComponent},  
  


]

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
