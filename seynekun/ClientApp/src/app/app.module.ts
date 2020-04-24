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
import { FiltroProductorPipe } from './filtro/filtro-productor.pipe';


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
    ProductorRegistroComponent,
    ProductorConsultaComponent,
    LoginComponent,
    FiltroProductorPipe
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
      { path: 'RegistrarProductor', component: ProductorRegistroComponent },
      { path: 'ConsultarProductor', component: ProductorConsultaComponent },
    ]),
    AppRoutingModule
  ],
  providers: [LoteService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
