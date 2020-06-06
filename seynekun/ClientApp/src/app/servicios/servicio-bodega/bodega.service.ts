import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Bodega } from 'src/app/seynekun/models/modelo-bodega/bodega';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptionsPut = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
  responseType: "text",
};

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: "root",
})
export class BodegaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  gets(): Observable<Bodega[]> {
    return this.http.get<Bodega[]>(this.baseUrl + "api/Bodega").pipe(
      tap((_) => console.log("Datos traídos")),
      catchError(
        this.handleErrorService.handleError<Bodega[]>(
          "Consulta de Bodegas",
          null
        )
      )
    );
  }
  delete(bodega: Bodega | string): Observable<string> {
    const id = typeof bodega === "string" ? bodega : bodega.nombre;
    return this.http.delete<string>(this.baseUrl + "api/Bodega/" + id).pipe(
      tap((_) => this.handleErrorService.logOk("Bodega Eliminada")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar Bodega", null)
      )
    );
  }
  post(bodega: Bodega): Observable<Bodega> {
    return this.http.post<Bodega>(this.baseUrl + "api/Bodega", bodega).pipe(
      tap((_) => this.handleErrorService.logOk("Bodega Registrada")),
      catchError(
        this.handleErrorService.handleError<Bodega>("Registro del Bodega", null)
      )
    );
  }
  get(codigo: string): Observable<Bodega> {
    const url = `${this.baseUrl + "api/Bodega"}/${codigo}`;
    return this.http.get<Bodega>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<Bodega>(
          "Consulta por código",
          null
        )
      )
    );
  }
  put(bodega: Bodega): Observable<Bodega> {
    const url = `${this.baseUrl + 'api/Bodega'}/${bodega.nombre}`;
    return this.http.put<Bodega>(url, bodega, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.logOk('Bodega Actualizada')),
        catchError(this.handleErrorService.handleError<Bodega>('Editar Bodega'))
      );
  }
}
