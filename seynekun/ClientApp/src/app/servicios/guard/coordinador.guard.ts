import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/seynekun/models/modelo-usuario/usuario';
import { AutenticacionService } from '../servicio-autenticacion/autenticacion.service';

@Injectable({
  providedIn: 'root'
})
export class CoordinadorGuard implements CanActivate {
  usuario: Usuario
  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.usuario = (JSON.parse(localStorage.getItem('currentUser')));
    if (this.usuario) {
      if (this.usuario.tipo == "Coordinador") {
        return true;
      }
      else {
        this.router.navigate(['']), { queryParams: { returnUrl: state.url } }
        return false;
      }
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/Login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
