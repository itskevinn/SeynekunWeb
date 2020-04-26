import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LoteRegistroComponent } from './seynekun/lote/lote-registro/lote-registro.component';
import { LoteConsultaComponent } from './seynekun/lote/lote-consulta/lote-consulta.component';
import { ProductorRegistroComponent } from './seynekun/productor/productor-registro/productor-registro.component';
import { ProductorConsultaComponent } from './seynekun/productor/productor-consulta/productor-consulta.component';
import { ProductorEdicionComponent } from './seynekun/productor/productor-edicion/productor-edicion.component';
import { EmpleadoConsultaComponent } from './seynekun/empleado/empleado-consulta/empleado-consulta.component';
import { EmpleadoRegistroComponent } from './seynekun/empleado/empleado-registro/empleado-registro.component';
import { EmpleadoEdicionComponent } from './seynekun/empleado/empleado-edicion/empleado-edicion.component';
import { ClienteConsultaComponent } from './seynekun/cliente/cliente-consulta/cliente-consulta.component';
import { ClienteEdicionComponent } from './seynekun/cliente/cliente-edicion/cliente-edicion.component';
import { ClienteRegistroComponent } from './seynekun/cliente/cliente-registro/cliente-registro.component';

const routes: Routes = [
  {
    path: 'RegistrarLote',
    component: LoteRegistroComponent
  },
  {
    path: 'ConsultarLote',
    component: LoteConsultaComponent
  },
  { path: 'RegistrarProductor', component: ProductorRegistroComponent },
  { path: 'Productores', component: ProductorConsultaComponent },
  { path: 'EditarProductor', component: ProductorEdicionComponent },
  { path: 'Empleados', component: EmpleadoConsultaComponent },
  { path: 'RegistrarEmpleado', component: EmpleadoRegistroComponent },
  { path: 'EditarEmpleado', component: EmpleadoEdicionComponent },
  { path: 'Clientes', component: ClienteConsultaComponent },
  { path: 'RegistrarCliente', component: ClienteRegistroComponent },
  { path: 'EditarCliente', component: ClienteEdicionComponent },
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
