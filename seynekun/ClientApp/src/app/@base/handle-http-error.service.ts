import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertaModalErrorComponent } from './alerta-modal-error/alerta-modal-error.component';
import { AlertaModalOkComponent } from './alerta-modal/alerta-modal.component';

@Injectable({
  providedIn: 'root'
})
export class HandleHttpErrorService {

  constructor(private modalService: NgbModal) { }

  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error('status', error.status);
      if (error.status == "500") {
        this.mostrarEstado500(error);
      } else if (error.status == "400") {
        this.mostrarEstado400(error);
      } else if (error.status == "401") {
        this.mostrarEstado401(error);
      } else if (error.status == "200") {
        this.mostrarEstado200(error);
      }
      return of(result as T);
    }
  }
  public mostrarEstado200(error: any): void {
    console.log(error);
    let contadorValidaciones: number = 0;
    let mensajeValidaciones: string = "";
    for (const prop in error.error.errors) {
      contadorValidaciones++;
      mensajeValidaciones += `<strong>${contadorValidaciones}. ${prop}:</strong>`;
      error.error.errors[prop].forEach(element => {
        mensajeValidaciones += `<br/> - ${element}`;
      });

      mensajeValidaciones += `<br/>`;
    }
    const modalRef = this.modalService.open(AlertaModalOkComponent);
    modalRef.componentInstance.titulo = mensajeValidaciones;
  }
  public mostrarEstado500(error: any): void {
    console.error(error);
    const modalRef = this.modalService.open(AlertaModalErrorComponent);
    modalRef.componentInstance.titulo = 'Ha ocurrido un error inesperado';
    modalRef.componentInstance.mensaje = "Error de la aplicación, vuela a intentarlo más tarde.";
  }

  public logOk(mensaje: string) {
    console.log(mensaje);
    const mensajeBox = this.modalService.open(AlertaModalOkComponent)
    mensajeBox.componentInstance.titulo = mensaje;
  }
  public logError(mensaje: string) {
    const mensajeBox = this.modalService.open(AlertaModalErrorComponent)
    mensajeBox.componentInstance.titulo = 'Ha ocurrido un error'
    mensajeBox.componentInstance.mensaje = mensaje;
  }
  private mostrarEstado401(error: any): void {
    const modalRef = this.modalService.open(AlertaModalErrorComponent);
    modalRef.componentInstance.titulo = 'Acceso denegado';
    modalRef.componentInstance.mensaje = "Usuario y/o contraseña incorrectos";
  }

  private mostrarEstado400(error: any): void {
    console.error(error);
    let contadorValidaciones: number = 0;
    let mensajeValidaciones: string =
      `Señor(a) usuario(a), se han presentado algunos errores de validación, por favor revíselos y vuelva a realizar la operación.<br/><br/>`;
    for (const prop in error.error.errors) {
      contadorValidaciones++;
      mensajeValidaciones += `<strong>${contadorValidaciones}. ${prop}:</strong>`;

      error.error.errors[prop].forEach(element => {
        mensajeValidaciones += `<br/> - ${element}`;
      });

      mensajeValidaciones += `<br/>`;
    }
    const modalRef = this.modalService.open(AlertaModalErrorComponent);
    modalRef.componentInstance.titulo = 'Ha ocurrido un error';
    modalRef.componentInstance.mensaje = mensajeValidaciones;
  }
}
