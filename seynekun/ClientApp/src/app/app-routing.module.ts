import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LoteRegistroComponent } from './seynekun/lote/lote-registro/lote-registro.component';
import { LoteConsultaComponent } from './seynekun/lote/lote-consulta/lote-consulta.component';

const routes: Routes = [
  {
    path: 'RegistrarLote',
    component: LoteRegistroComponent
  },
  {
    path: 'ConsultarLote',
    component: LoteConsultaComponent
  },
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
