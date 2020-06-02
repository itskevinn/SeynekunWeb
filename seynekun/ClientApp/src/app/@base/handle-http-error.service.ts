import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertaModalErrorComponent } from './alerta-modal-error/alerta-modal-error.component';

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
        this.mostrarError400(error);
      } else if (error.status == "400") {
        this.mostrarError400(error);
      } else if (error.status == "401") {
        //this.mostrarError(error);
        this.mostrarError400(error);
      }
      return of(result as T);
    };
  }

  public log(message: string) {
    console.log(message);
    const messageBox = this.modalService.open(AlertaModalErrorComponent)
    messageBox.componentInstance.title = 'Resultado Operación';
    messageBox.componentInstance.message = message;
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
    modalRef.componentInstance.title = 'Ha ocurrido un error';
    modalRef.componentInstance.message = mensajeValidaciones;
  }


}