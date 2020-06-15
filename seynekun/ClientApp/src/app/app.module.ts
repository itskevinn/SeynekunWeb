import { BrowserModule } from "@angular/platform-browser";
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbDate, NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { AppRoutingModule } from "./app-routing.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";


import { ProductorConsultaComponent } from "./seynekun/productor/productor-consulta/productor-consulta.component";
import { LoginComponent } from "./login/login/login.component";
import { ClienteRegistroComponent } from "./seynekun/cliente/cliente-registro/cliente-registro.component";
import { ClienteConsultaComponent } from "./seynekun/cliente/cliente-consulta/cliente-consulta.component";
import { EmpleadoConsultaComponent } from "./seynekun/empleado/empleado-consulta/empleado-consulta.component";
import { EmpleadoRegistroComponent } from "./seynekun/empleado/empleado-registro/empleado-registro.component";
import { ProductorRegistroComponent } from "./seynekun/productor/productor-registro/productor-registro.component";
import { EmpleadoEdicionComponent } from "./seynekun/empleado/empleado-edicion/empleado-edicion.component";
import { ClienteEdicionComponent } from "./seynekun/cliente/cliente-edicion/cliente-edicion.component";
import { ProductorEdicionComponent } from "./seynekun/productor/productor-edicion/productor-edicion.component";
import { FiltroEmpleadoPipe } from "./filtro/filtro-empleado/filtro-empleado.pipe";
import { FiltroClientePipe } from "./filtro/filtro-cliente/filtro-cliente.pipe";
import { FiltroProductorPipe } from "./filtro/filtro-productor/filtro-productor.pipe";
import { EmpleadoVistaComponent } from "./seynekun/empleado/empleado-vista/empleado-vista.component";
import { ClienteVistaComponent } from "./seynekun/cliente/cliente-vista/cliente-vista.component";
import { ProductorVistaComponent } from "./seynekun/productor/productor-vista/productor-vista.component";
import { AlertaModalOkComponent } from "./@base/alerta-modal/alerta-modal.component";
import { AlertaModalErrorComponent } from "./@base/alerta-modal-error/alerta-modal-error.component";
import { EmpleadoService } from "./servicios/servicio-de-empleado/empleado.service";
import { ClienteService } from "./servicios/servicio-de-cliente/cliente.service";
import { ProductorService } from "./servicios/servicio-de-productor/productor.service";
import { ProductoEdicionComponent } from "./seynekun/inventario/producto/producto-edicion/producto-edicion.component";
import { ProductoRegistroComponent } from "./seynekun/inventario/producto/producto-registro/producto-registro.component";
import { ProductoConsultaComponent } from "./seynekun/inventario/producto/producto-consulta/producto-consulta.component";
import { ReporteInventarioComponent } from "./seynekun/reporte/reporte-inventario/reporte-inventario.component";
import { ProductoVistaComponent } from "./seynekun/inventario/producto/producto-vista/producto-vista.component";
import { ReporteInventarioService } from "./servicios/servicio-de-reporte-inventario/reporte-inventario.service";
import { ControlesService } from "./servicios/servicio-de-controles/controles.service";

import { AjusteInventarioRegistroComponent } from "./seynekun/inventario/ajuste-inventario/ajuste-inventario-registro/ajuste-inventario-registro/ajuste-inventario-registro.component";
import { AjusteInventarioVistaComponent } from "./seynekun/inventario/ajuste-inventario/ajuste-inventario-vista/ajuste-inventario-vista/ajuste-inventario-vista.component";
import { AjusteInventarioEdicionComponent } from "./seynekun/inventario/ajuste-inventario/ajuste-inventario-Edicion/ajuste-inventario-edicion/ajuste-inventario-edicion.component";
import { AjusteInventarioConsultaComponent } from "./seynekun/inventario/ajuste-inventario/ajuste-inventario-consulta/ajuste-inventario-consulta/ajuste-inventario-consulta.component";
import { AlertaModalPreguntaComponent } from "./@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component";

import { BodegaConsultaComponent } from "./seynekun/inventario/bodega/bodega-consulta/bodega-consulta/bodega-consulta.component";
import { BodegaVistaComponent } from "./seynekun/inventario/bodega/bodega-vista/bodega-vista/bodega-vista.component";
import { BodegaEdicionComponent } from "./seynekun/inventario/bodega/bodega-edicion/bodega-edicion/bodega-edicion.component";
import { InsumoRegistroComponent } from "./seynekun/inventario/insumo/insumo-registro/insumo-registro/insumo-registro.component";
import { InsumoConsultaComponent } from "./seynekun/inventario/insumo/insumo-consulta/insumo-consulta/insumo-consulta.component";
import { InsumoVistaComponent } from "./seynekun/inventario/insumo/insumo-vista/insumo-vista/insumo-vista.component";
import { FichaTecnicaVistaComponent } from "./seynekun/inventario/insumo/ficha-tecnica/fecha-tecnica-vista/ficha-tecnica-vista/ficha-tecnica-vista.component";
import { FichaTecnicaRegistroComponent } from "./seynekun/inventario/insumo/ficha-tecnica/fecha-tecnica-registro/ficha-tecnica-registro/ficha-tecnica-registro.component";
import { FichaTecnicaEdicionComponent } from "./seynekun/inventario/insumo/ficha-tecnica/fecha-tecnica-edicion/ficha-tecnica-edicion/ficha-tecnica-edicion.component";
import { InsumoEdicionComponent } from "./seynekun/inventario/insumo/insumo-edicion/insumo-edicion/insumo-edicion.component";
import { FabricanteVistaComponent } from "./seynekun/fabricante/fabricante-vista/fabricante-vista/fabricante-vista.component";
import { FabricanteConsultaComponent } from "./seynekun/fabricante/fabricante-consulta/fabricante-consulta/fabricante-consulta.component";
import { FabricanteRegistroComponent } from "./seynekun/fabricante/fabricante-registro/fabricante-registro/fabricante-registro.component";
import { FabricanteEdicionComponent } from "./seynekun/fabricante/fabricante-edicion/fabricante-edicion/fabricante-edicion.component";
import { BodegaRegistroComponent } from "./seynekun/inventario/bodega/bodega-registro/bodega-registro/bodega-registro.component";
import { ProductoService } from "./servicios/servicio-producto/producto.service";
import { CategoriaRegistroComponent } from "./seynekun/inventario/categoria/categoria-registro/categoria-registro/categoria-registro.component";
import { CategoriaConsultaComponent } from "./seynekun/inventario/categoria/categoria-consulta/categoria-consulta/categoria-consulta.component";
import { CategoriaVistaComponent } from "./seynekun/inventario/categoria/categoria-vista/categoria-vista/categoria-vista.component";
import { CategoriaEdicionComponent } from "./seynekun/inventario/categoria/categoria-edicion/categoria-edicion/categoria-edicion.component";
import { FiltroBodegaPipe } from "./filtro/filtro-bodega/filtro-bodega.pipe";
import { FiltroCategoriaPipe } from "./filtro/filtro-categoria/filtro-categoria.pipe";
import { FiltroProductoPipe } from "./filtro/filtro-producto/filtro-producto.pipe";
import { ProductosBodegaComponent } from "./seynekun/inventario/bodega/bodega-productos-vista/productos-bodega/productos-bodega.component";
import { ProductosCategoriaComponent } from "./seynekun/inventario/categoria/categoria-productos-vista/productos-categoria/productos-categoria.component";
import { FiltroAjusteInventarioPipe } from "./filtro/filtro-ajusteInventario/filtro-ajuste-inventario.pipe";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { MateriaRegistroComponent } from './seynekun/inventario/materia-prima/materia-registro/materia-registro/materia-registro.component';
import { MateriaConsultaComponent } from './seynekun/inventario/materia-prima/materia-consulta/materia-consulta/materia-consulta.component';
import { MateriaVistaComponent } from './seynekun/inventario/materia-prima/materia-vista/materia-vista/materia-vista.component';
import { MateriaEdicionComponent } from './seynekun/inventario/materia-prima/materia-edicion/materia-edicion/materia-edicion.component';
import { Error404Component } from './Errores/error404/error404.component';
import { CounterComponent } from "./counter/counter.component";
import { JwtInterceptor } from "./servicios/interceptor/jwt.interceptor";
import { AuthGuard } from "./servicios/guard/auth.guard";
import { TrasladosConsultaComponent } from './seynekun/transportes/traslados/traslados-consulta/traslados-consulta.component';
import { TrasladosRegistroComponent } from './seynekun/transportes/traslados/traslados-registro/traslados-registro.component';
import { TrasladosVistaComponent } from './seynekun/transportes/traslados/traslados-vista/traslados-vista.component';
import { TrasladosEdicionComponent } from './seynekun/transportes/traslados/traslados-edicion/traslados-edicion.component';
import { TransportadorConsultaComponent } from './seynekun/transportes/transportador/transportador-consulta/transportador-consulta.component';
import { TransportadorRegistroComponent } from './seynekun/transportes/transportador/transportador-registro/transportador-registro.component';
import { TransportadorVistaComponent } from './seynekun/transportes/transportador/transportador-vista/transportador-vista.component';
import { TransportadorEdicionComponent } from './seynekun/transportes/transportador/transportador-edicion/transportador-edicion.component';
import { VentaConsultaComponent } from './seynekun/ventas/venta/venta-consulta/venta-consulta.component';
import { VentaRegistroComponent } from './seynekun/ventas/venta/venta-registro/venta-registro.component';
import { VentaEdicionComponent } from './seynekun/ventas/venta/venta-edicion/venta-edicion.component';
import { VentaVistaComponent } from './seynekun/ventas/venta/venta-vista/venta-vista.component';
import { MateriaPrimaProductorComponent } from './seynekun/inventario/materia-prima/materia-prima-productor/materia-prima-productor.component';
import { ProductosMateriaProductorComponent } from './seynekun/inventario/materia-prima/productos-materia-productor/productos-materia-productor.component';
import { MateriaPrimaProductorVistaComponent } from './seynekun/inventario/materia-prima/materia-prima-productor/materia-prima-productor-vista/materia-prima-productor-vista.component';
import { AvisoModalComponent } from './@base/alerta-aviso-modal/aviso-modal/aviso-modal.component';
import { ConsultaClienteComponent } from './modal/consulta-cliente-modal/consulta-cliente/consulta-cliente.component';
import { ConsultaEmpleadoComponent } from './modal/consulta-empleado-modal/consulta-empleado/consulta-empleado.component';
import { ConsultaProductorComponent } from './modal/consulta-productor-modal/consulta-productor/consulta-productor.component';
import { ConsultaProductoComponent } from './modal/consulta-producto-modal/consulta-producto/consulta-producto.component';
import { ConsultaMateriaComponent } from './modal/consulta-materia-modal/consulta-materia/consulta-materia.component';
import { FiltroMateriaPipe } from './filtro/filtro-materia-prima/filtro-materia.pipe';
import { SolicitudRegistroComponent } from "./seynekun/solicitud/solicitud-registro/solicitud-registro/solicitud-registro.component";
import { SolicitudConsultaComponent } from "./seynekun/solicitud/solicitud-consulta/solicitud-consulta.component";
import { EventoService } from "./servicios/servicio-evento/evento.service";
import { ControlRegistroComponent } from './seynekun/controles/control/control-registro/control-registro.component';
import { ControlConsultaComponent } from './seynekun/controles/control/control-consulta/control-consulta.component';
import { ControlEdicionComponent } from './seynekun/controles/control/control-edicion/control-edicion.component';
import { ControlVistaComponent } from './seynekun/controles/control/control-vista/control-vista.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
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
    BodegaConsultaComponent,
    BodegaVistaComponent,
    BodegaRegistroComponent,
    BodegaEdicionComponent,
    InsumoRegistroComponent,
    InsumoConsultaComponent,
    InsumoVistaComponent,
    FichaTecnicaVistaComponent,
    FichaTecnicaRegistroComponent,
    FichaTecnicaEdicionComponent,
    InsumoEdicionComponent,
    FabricanteVistaComponent,
    FabricanteConsultaComponent,
    FabricanteRegistroComponent,
    FabricanteEdicionComponent,
    CategoriaRegistroComponent,
    CategoriaConsultaComponent,
    CategoriaVistaComponent,
    CategoriaEdicionComponent,
    FiltroBodegaPipe,
    FiltroCategoriaPipe,
    FiltroProductoPipe,
    ProductosBodegaComponent,
    ProductosCategoriaComponent,
    FiltroAjusteInventarioPipe,
    MateriaRegistroComponent,
    MateriaConsultaComponent,
    MateriaVistaComponent,
    MateriaEdicionComponent,
    Error404Component,
    TrasladosConsultaComponent,
    TrasladosRegistroComponent,
    TrasladosVistaComponent,
    TrasladosEdicionComponent,
    TransportadorConsultaComponent,
    TransportadorRegistroComponent,
    TransportadorVistaComponent,
    TransportadorEdicionComponent,
    VentaConsultaComponent,
    VentaRegistroComponent,
    VentaEdicionComponent,
    VentaVistaComponent,
    MateriaPrimaProductorComponent,
    ProductosMateriaProductorComponent,
    MateriaPrimaProductorVistaComponent,
    AvisoModalComponent,
    ConsultaClienteComponent,
    ConsultaEmpleadoComponent,
    ConsultaProductorComponent,
    ConsultaProductoComponent,
    ConsultaMateriaComponent,
    FiltroMateriaPipe,
    SolicitudRegistroComponent,
    SolicitudConsultaComponent,
    ControlRegistroComponent,
    ControlConsultaComponent,
    ControlEdicionComponent,
    ControlVistaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot([
      { path: "Login", component: LoginComponent },
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: '404', component: Error404Component },
      { path: '**', redirectTo: '/404' }
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
    EventoService,
    ReporteInventarioService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
