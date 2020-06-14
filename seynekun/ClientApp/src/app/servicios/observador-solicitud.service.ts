import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ObservadorSolicitudService {
  private mensaje = new BehaviorSubject<boolean>(true);
  public mensajePersonalizado = this.mensaje.asObservable();
  constructor() {
  }
  public cambiarEstado(msg: boolean) {
    this.mensaje.next(msg);
  }
}
