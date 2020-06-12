import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
private mensaje = new BehaviorSubject<boolean>(true);
public mensajePersonalizado = this.mensaje.asObservable();
  constructor() { }
  public cambiarMensaje(msg: boolean){
    this.mensaje.next(msg);
  }
}
