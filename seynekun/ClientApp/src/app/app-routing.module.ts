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
import { ReporteInventarioComponent } from './seynekun/inventario/reporte-inventario/reporte-inventario.component'
import { AjusteInventarioConsultaComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-consulta/ajuste-inventario-consulta/ajuste-inventario-consulta.component'
import { AjusteInventarioVistaComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-vista/ajuste-inventario-vista/ajuste-inventario-vista.component'
import { AjusteInventarioRegistroComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-registro/ajuste-inventario-registro/ajuste-inventario-registro.component'
import { AjusteInventarioEdicionComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-Edicion/ajuste-inventario-edicion/ajuste-inventario-edicion.component'

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

]

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
