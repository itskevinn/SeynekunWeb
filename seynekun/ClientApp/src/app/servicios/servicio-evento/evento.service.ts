import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  private mensaje = new BehaviorSubject<boolean>(true);
  public mensajePersonalizado = this.mensaje.asObservable();
  private id: BehaviorSubject<string>;
  public codigo: Observable<string>;
  constructor() {
    this.id = new BehaviorSubject<string>("");
    this.codigo = this.id.asObservable();
  }
  public cambiarMensaje(msg: boolean) {
    this.mensaje.next(msg);
  }
  public cambiarId(id: string) {
    this.id.next(id);
    this.codigo = this.id.asObservable();
  }
}
