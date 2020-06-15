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

  public codigoMateria: Observable<string>;
  private codigoMateriaBehavior: BehaviorSubject<string>;

  public nombreBodega: Observable<string>;
  private nombreBodegaBehavior: BehaviorSubject<string>;

  public codigoProductor: Observable<string>;
  private codigoProductorBehavior: BehaviorSubject<string>;

  public codigoCliente: Observable<string>;
  private codigoClienteBehavior: BehaviorSubject<string>;
  constructor() {
    this.id = new BehaviorSubject<string>("");
    this.codigo = this.id.asObservable();

    this.codigoProductorBehavior = new BehaviorSubject<string>("");
    this.codigoProductor = this.codigoProductorBehavior.asObservable();

    this.codigoMateriaBehavior = new BehaviorSubject<string>("");
    this.codigoMateria = this.codigoMateriaBehavior.asObservable();

    this.codigoClienteBehavior = new BehaviorSubject<string>("");
    this.codigoCliente = this.codigoClienteBehavior.asObservable();

    this.nombreBodegaBehavior = new BehaviorSubject<string>("");
    this.nombreBodega = this.nombreBodegaBehavior.asObservable();
  }
  public cambiarMensaje(msg: boolean) {
    this.mensaje.next(msg);
  }
  public cambiarId(id: string) {
    this.id.next(id);
    this.codigo = this.id.asObservable();
  }
  public cambiarCodigoMateria(id: string) {
    this.codigoMateriaBehavior.next(id);
    this.codigoMateria = this.codigoMateriaBehavior.asObservable();
  }

  public cambiarCodigoProductor(nombre: string) {
    this.codigoProductorBehavior.next(nombre);
    this.codigoProductor = this.codigoProductorBehavior.asObservable();
  }
  public cambiarCodigoCliente(nombre: string) {
    this.codigoClienteBehavior.next(nombre);
    this.codigoCliente = this.codigoClienteBehavior.asObservable();
  }
}
