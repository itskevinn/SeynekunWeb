import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbDate, NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoteRegistroComponent } from './seynekun/lote/lote-registro/lote-registro.component';
import { LoteConsultaComponent } from './seynekun/lote/lote-consulta/lote-consulta.component';
import { AppRoutingModule } from './app-routing.module';
import { LoteService } from './servicios/servicio-de-lote/lote.service';
import { ProductorRegistroComponent } from './seynekun/productor/productor-registro/productor-registro.component';
import { ProductorConsultaComponent } from './seynekun/productor/productor-consulta/productor-consulta.component';
import { LoginComponent } from './login/login/login.component';
import { ClienteRegistroComponent } from './seynekun/cliente/cliente-registro/cliente-registro.component';
import { ClienteConsultaComponent } from './seynekun/cliente/cliente-consulta/cliente-consulta.component';
import { EmpleadoConsultaComponent } from './seynekun/empleado/empleado-consulta/empleado-consulta.component';
import { EmpleadoRegistroComponent } from './seynekun/empleado/empleado-registro/empleado-registro.component';

import { EmpleadoEdicionComponent } from './seynekun/empleado/empleado-edicion/empleado-edicion.component';
import { ClienteEdicionComponent } from './seynekun/cliente/cliente-edicion/cliente-edicion.component';
import { ProductorEdicionComponent } from './seynekun/productor/productor-edicion/productor-edicion.component';
import { FiltroEmpleadoPipe } from './filtro/filtro-empleado/filtro-empleado.pipe';
import { FiltroClientePipe } from './filtro/filtro-cliente/filtro-cliente.pipe';
import { FiltroProductorPipe } from './filtro/filtro-productor/filtro-productor.pipe';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoteRegistroComponent,
    LoteConsultaComponent,
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
    FiltroClientePipe
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
    AppRoutingModule
  ],
  providers: [LoteService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
