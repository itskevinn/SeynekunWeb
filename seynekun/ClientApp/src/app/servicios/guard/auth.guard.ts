import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AutenticacionService } from '../servicio-autenticacion/autenticacion.service';
import { Usuario } from 'src/app/seynekun/models/modelo-usuario/usuario';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService
  ) { }
  usuario: Usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.usuario.tipo == "Invitado") {
      sessionStorage.removeItem('currentUser');
      alert("Acceso denegado")
      window.location.reload();
      return false;
    }
    if (sessionStorage.getItem('currentUser')) {
      return true;
    }
    else {
      this.router.navigate(['/Login']);
    }
    // not logged in so redirect to login page with the return url
  }
}
