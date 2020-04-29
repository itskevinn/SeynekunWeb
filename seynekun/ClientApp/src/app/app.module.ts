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
import { LoteRegistroComponent } from './seynekun/lote/lote-registro/lote-registro.component'
import { LoteConsultaComponent } from './seynekun/lote/lote-consulta/lote-consulta.component'
import { AppRoutingModule } from './app-routing.module'
import { ProductorRegistroComponent } from './seynekun/productor/productor-registro/productor-registro.component'
import { ProductorConsultaComponent } from './seynekun/productor/productor-consulta/productor-consulta.component'
import { LoginComponent } from './login/login/login.component'
import { ClienteRegistroComponent } from './seynekun/cliente/cliente-registro/cliente-registro.component'
import { ClienteConsultaComponent } from './seynekun/cliente/cliente-consulta/cliente-consulta.component'
import { EmpleadoConsultaComponent } from './seynekun/empleado/empleado-consulta/empleado-consulta.component'
import { EmpleadoRegistroComponent } from './seynekun/empleado/empleado-registro/empleado-registro.component'

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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductorRegistroComponent,
    ProductorConsultaComponent,
    ProductorEdicionComponent,
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
  providers: [ClienteService, EmpleadoService, ProductorService],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
