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
  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService
  ) {
    this.autenticacionServicio.currentUser.subscribe(x => this.usuarioActual = x);
    if (this.autenticacionServicio.currentUserValue != null) {
      this.ingreso = true;

      this.primerIngreso = this.primerIngreso + 1;
    }
    else if (localStorage.getItem('currentUser') == null && this.primerIngreso > 2) {
      this.reload();
    }
  }
  reload() {
    window.location.reload();
  }
  logout() {
    this.autenticacionServicio.logout();
    this.router.navigate(['/Login']);
    this.ingreso = false;
  }
}
