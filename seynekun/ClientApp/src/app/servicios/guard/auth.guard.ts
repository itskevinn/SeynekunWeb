import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AutenticacionService } from '../servicio-autenticacion/autenticacion.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (localStorage.getItem('currentUser')) {
      return true;
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/Login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
