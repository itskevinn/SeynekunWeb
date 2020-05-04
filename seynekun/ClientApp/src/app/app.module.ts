import { BrowserModule } from '@angular/platform-browser'
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { RouterModule } from '@angular/router'
import { NgbDate, NgbModule } from '@ng-bootstrap/ng-bootstrap'

import { AppComponent } from './app.component'
import { NavMenuComponent } from './nav-menu/nav-menu.component'
import { HomeComponent } from './home/home.component'
import { CounterComponent } from './counter/counter.component'
import { FetchDataComponent } from './fetch-data/fetch-data.component'
import { AppRoutingModule } from './app-routing.module'

import { ProductorConsultaComponent } from './seynekun/productor/productor-consulta/productor-consulta.component'
import { LoginComponent } from './login/login/login.component'
import { ClienteRegistroComponent } from './seynekun/cliente/cliente-registro/cliente-registro.component'
import { ClienteConsultaComponent } from './seynekun/cliente/cliente-consulta/cliente-consulta.component'
import { EmpleadoConsultaComponent } from './seynekun/empleado/empleado-consulta/empleado-consulta.component'
import { EmpleadoRegistroComponent } from './seynekun/empleado/empleado-registro/empleado-registro.component'
import { ProductorRegistroComponent } from './seynekun/productor/productor-registro/productor-registro.component'
import { EmpleadoEdicionComponent } from './seynekun/empleado/empleado-edicion/empleado-edicion.component'
import { ClienteEdicionComponent } from './seynekun/cliente/cliente-edicion/cliente-edicion.component'
import { ProductorEdicionComponent } from './seynekun/productor/productor-edicion/productor-edicion.component'
import { FiltroEmpleadoPipe } from './filtro/filtro-empleado/filtro-empleado.pipe'
import { FiltroClientePipe } from './filtro/filtro-cliente/filtro-cliente.pipe'
import { FiltroProductorPipe } from './filtro/filtro-productor/filtro-productor.pipe'
import { EmpleadoVistaComponent } from './seynekun/empleado/empleado-vista/empleado-vista.component'
import { ClienteVistaComponent } from './seynekun/cliente/cliente-vista/cliente-vista.component'
import { ProductorVistaComponent } from './seynekun/productor/productor-vista/productor-vista.component'
import { AlertaModalOkComponent } from './@base/alerta-modal/alerta-modal.component'
import { AlertaModalErrorComponent } from './@base/alerta-modal-error/alerta-modal-error.component'
import { EmpleadoService } from './servicios/servicio-de-empleado/empleado.service'
import { ClienteService } from './servicios/servicio-de-cliente/cliente.service'
import { ProductorService } from './servicios/servicio-de-productor/productor.service'
import { ControlesComponent } from './seynekun/controles/controles/controles.component'
import { ProductoEdicionComponent } from './seynekun/inventario/producto/producto-edicion/producto-edicion.component'
import { ProductoRegistroComponent } from './seynekun/inventario/producto/producto-registro/producto-registro.component'
import { ProductoConsultaComponent } from './seynekun/inventario/producto/producto-consulta/producto-consulta.component'
import { ReporteInventarioComponent } from './seynekun/inventario/reporte-inventario/reporte-inventario.component'
import { ProductoVistaComponent } from './seynekun/inventario/producto/producto-vista/producto-vista.component'
import { ReporteInventarioService } from './servicios/servicio-de-reporte-inventario/reporte-inventario.service'
import { ProductoService } from './servicios/servicio-de-producto/producto.service'
import { ControlesService } from './servicios/servicio-de-controles/controles.service'

import { AjusteInventarioRegistroComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-registro/ajuste-inventario-registro/ajuste-inventario-registro.component'
import { AjusteInventarioVistaComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-vista/ajuste-inventario-vista/ajuste-inventario-vista.component'
import { AjusteInventarioEdicionComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-Edicion/ajuste-inventario-edicion/ajuste-inventario-edicion.component'
import { AjusteInventarioConsultaComponent } from './seynekun/inventario/ajuste-inventario/ajuste-inventario-consulta/ajuste-inventario-consulta/ajuste-inventario-consulta.component';
import { AlertaModalPreguntaComponent } from './@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductorConsultaComponent,
    ProductorEdicionComponent,
    ProductorRegistroComponent,
    LoginComponent,
    FiltroProductorPipe,
    ClienteRegistroComponent,
    ClienteConsultaComponent,
    ClienteEdicionComponent,
    EmpleadoConsultaComponent,
    EmpleadoRegistroComponent,
    EmpleadoEdicionComponent,
    FiltroEmpleadoPipe,
    FiltroClientePipe,
    EmpleadoVistaComponent,
    ClienteVistaComponent,
    ProductorVistaComponent,
    AlertaModalOkComponent,
    AlertaModalErrorComponent,
    ControlesComponent,
    ProductoEdicionComponent,
    ProductoRegistroComponent,
    ProductoVistaComponent,
    ProductoConsultaComponent,
    ReporteInventarioComponent,    
    AjusteInventarioConsultaComponent,    
    AjusteInventarioRegistroComponent,
    AjusteInventarioVistaComponent,
    AjusteInventarioEdicionComponent,
    AlertaModalPreguntaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule,
  ],
  entryComponents: [AlertaModalOkComponent, AlertaModalErrorComponent],
  bootstrap: [AppComponent],
  providers: [
    ClienteService,
    EmpleadoService,
    ProductorService,
    ProductoService,
    ControlesService,
    ReporteInventarioService,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
