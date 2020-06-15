import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Control } from 'src/app/seynekun/models/modelo-control/control';

const httpOptionsPut = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
  responseType: "text",
};

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ControlService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(control: Control): Observable<Control> {
    return this.http.post<Control>(this.baseUrl + "api/Control", control).pipe(
      tap((_) => this.handleErrorService.logOk("Control registrado")),
      catchError(
        this.handleErrorService.handleError<Control>("Registro de control", null)
      )
    );
  }

  gets(): Observable<Control[]> {
    return this.http.get<Control[]>(this.baseUrl + "api/Control").pipe(
      //tap((_) => console.log("Controles consultados")),
      catchError(
        this.handleErrorService.handleError<Control[]>(
          "Consulta de controles",
          null
        )
      )
    );
  }

  get(codigo: string): Observable<Control> {
    const url = `${this.baseUrl + "api/Control"}/${codigo}`;
    return this.http.get<Control>(url, httpOptions).pipe(
      //tap((_) => console.log("Control consultado")),
      catchError(
        this.handleErrorService.handleError<Control>(
          "Consulta por codigo de control",
          null
        )
      )
    );
  }

  put(control: Control): Observable<Control> {
    const url = `${this.baseUrl + 'api/Control'}/${control.codigoControl}`;
    return this.http.put<Control>(url, control, httpOptions)
      .pipe(
        //tap(_ => this.handleErrorService.logOk('Control actualizado')),
        catchError(this.handleErrorService.handleError<Control>('Editar control'))
      );
  }

  delete(control: Control | string): Observable<string> {
    const id = typeof control === "string" ? control : control.codigoControl;
    return this.http.delete<string>(this.baseUrl + "api/Control/" + id).pipe(
      tap((_) => this.handleErrorService.logOk("Control eliminado")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar control", null)
      )
    );
  }
}
