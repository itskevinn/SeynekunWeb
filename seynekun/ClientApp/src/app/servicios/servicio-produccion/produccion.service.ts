import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Produccion } from 'src/app/seynekun/models/modelo-produccion/produccion';

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
export class ProduccionService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl }

  post(produccion: Produccion): Observable<Produccion> {
    return this.http.post<Produccion>(this.baseUrl + "api/Produccion", produccion).pipe(
      tap((_) => this.handleErrorService.logOk("Produccion registrada")),
      catchError(
        this.handleErrorService.handleError<Produccion>("Registro de produccion", null)
      )
    );
  }

  gets(): Observable<Produccion[]> {
    return this.http.get<Produccion[]>(this.baseUrl + "api/Produccion").pipe(
      //tap((_) => console.log("Producciones consultadas")),
      catchError(
        this.handleErrorService.handleError<Produccion[]>("Consulta de produccion", null)
      )
    );
  }

  get(codigo: string): Observable<Produccion> {
    const url = `${this.baseUrl + "api/Produccion"}/${codigo}`;
    return this.http.get<Produccion>(url, httpOptions).pipe(
      tap((_) => console.log("Produccion consultada")),
      catchError(
        this.handleErrorService.handleError<Produccion>("Consulta por codigo de venta", null)
      )
    );
  }

  put(produccion: Produccion): Observable<Produccion> {
    const url = `${this.baseUrl + 'api/Produccion'}/${produccion.codigoProduccion}`;
    return this.http.put<Produccion>(url, produccion, httpOptions)
      .pipe(
        //tap(_ => this.handleErrorService.logOk('Produccion actualizada')),
        catchError(this.handleErrorService.handleError<Produccion>('Editar produccion'))
      );
  }

  delete(produccion: Produccion | string): Observable<string> {
    const id = typeof produccion === "string" ? produccion : produccion.codigoProduccion;
    return this.http.delete<string>(this.baseUrl + "api/Produccion/" + id).pipe(
      //tap((_) => this.handleErrorService.logOk("Produccion eliminada")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar produccion", null)
      )
    );
  }

  getCodigoProduccion(): Observable<string>{
    const url = `${this.baseUrl + "api/ProduccionCodigo"}`;
    return this.http.get<string>(url, httpOptions).pipe(
      //tap((_) => console.log("Codigo de produccion generado")),
      catchError(
        this.handleErrorService.handleError<string>("Codigo de produccion", null)
      )
    );
  }
}
