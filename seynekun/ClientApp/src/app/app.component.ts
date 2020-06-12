import { Component } from '@angular/core';
import { Usuario } from './seynekun/models/modelo-usuario/usuario';
import { AutenticacionService } from './servicios/servicio-autenticacion/autenticacion.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  usuarioActual: Usuario;
  ingreso = false;
  primerIngreso: number;
  isExpanded: boolean;
  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService
    ) {
      this.autenticacionServicio.currentUser.subscribe(x => this.usuarioActual = x);
      this.ingreso = true;
      this.isExpanded = JSON.parse(localStorage.getItem('estadoNav'));
  }
  reload() {
    window.location.reload();
  }
  toggle(){
    this.isExpanded = !this.isExpanded;
    localStorage.setItem("estadoNav", JSON.stringify(this.isExpanded));
  }
  logout() {
    this.autenticacionServicio.logout();
    this.router.navigate(['/Login']);
    this.ingreso = false;
  }
}
