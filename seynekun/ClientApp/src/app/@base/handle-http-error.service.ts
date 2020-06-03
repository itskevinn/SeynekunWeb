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
      //console.error(error);
      console.error('status', error.status);
      if (error.status == "500") {
        //this.mostrarError500(error);
        this.mostrarError500(error);
      } else if (error.status == "400") {
        this.mostrarError400(error);
      } else if (error.status == "401") {
        this.mostrarError401(error);
      }
      return of(result as T);
    }
  }

  public mostrarError500(error: any): void {
    console.error(error);
    const modalRef = this.modalService.open(AlertaModalErrorComponent);
    modalRef.componentInstance.title = 'Ha ocurrido un error inesperado';
    modalRef.componentInstance.message = "Error de la aplicación, vuela a intentarlo más tarde.";
  }

  public logOk(message: string) {
    console.log(message);
    const messageBox = this.modalService.open(AlertaModalOkComponent)
    messageBox.componentInstance.titulo = message;
  }
  public logError(message: string) {
    const messageBox = this.modalService.open(AlertaModalErrorComponent)
    messageBox.componentInstance.titulo = 'Ha ocurrido un error'
    messageBox.componentInstance.mensaje = message;
  }
  private mostrarError401(error: any): void {
    const modalRef = this.modalService.open(AlertaModalErrorComponent);
    modalRef.componentInstance.titulo = 'Acceso denegado';
    modalRef.componentInstance.mensaje = "No encontramos registros de su usuario en nuestro sistema";
  }

  private mostrarError400(error: any): void {
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