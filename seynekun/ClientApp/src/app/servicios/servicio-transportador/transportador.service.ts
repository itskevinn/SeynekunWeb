import { Injectable, Inject } from '@angular/core';
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { tap, catchError } from "rxjs/operators";
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Transportador } from 'src/app/seynekun/models/modelo-transportador/transportador';

const httpOptionsPut = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
  responseType: "text",
};

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};

@Injectable({
  providedIn: 'root'
})
export class TransportadorService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }
  
  post(transportador: Transportador): Observable<Transportador> {
    return this.http.post<Transportador>(this.baseUrl + "api/Transportador", transportador).pipe(
      tap((_) => this.handleErrorService.logOk("Transportador registrado con éxito")),
      catchError(
        this.handleErrorService.handleError<Transportador>("Registro del transportador", null)
      )
    );
  }

  gets(): Observable<Transportador[]> {
    return this.http.get<Transportador[]>(this.baseUrl + "api/Transportador").pipe(
      //tap((_) => console.log("Datos traídos")),
      catchError(
        this.handleErrorService.handleError<Transportador[]>("Consulta de transportador", null)
      )
    );
  }

  get(codigo: string): Observable<Transportador> {
    const url = `${this.baseUrl + "api/Transportador"}/${codigo}`;
    return this.http.get<Transportador>(url, httpOptions).pipe(
      //tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<Transportador>("Buscar transportador", null)
      )
    );
  }

  put(codigo: string, transportador: Transportador): Observable<Transportador> {
    const url = `${this.baseUrl}api/Transportador/${codigo}`;
    return this.http.put<Transportador>(url, transportador, httpOptions).pipe(
      tap((_) => this.handleErrorService.logOk("Datos enviados")),
      catchError(
        this.handleErrorService.handleError<Transportador>("Actualizar transportador", null)
      )
    );
  }

  delete(transportador: Transportador | string): Observable<string> {
    const id = typeof transportador === "string" ? transportador : transportador.identificacion;
    return this.http.delete<string>(this.baseUrl + "api/Transportador/" + id).pipe(
      tap((_) => this.handleErrorService.logOk("Transportador eliminado")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar transportador", null)
      )
    );
  }
}
