import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Venta } from 'src/app/seynekun/models/modelo-venta/venta';

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
export class VentaService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  gets(): Observable<Venta[]> {
    return this.http.get<Venta[]>(this.baseUrl + "api/Venta").pipe(
      tap((_) => console.log("Ventas consultadas")),
      catchError(
        this.handleErrorService.handleError<Venta[]>(
          "Consulta de ventas",
          null
        )
      )
    );
  }

  delete(venta: Venta | string): Observable<string> {
    const id = typeof venta === "string" ? venta : venta.codigoVenta;
    return this.http.delete<string>(this.baseUrl + "api/Venta/" + id).pipe(
      tap((_) => this.handleErrorService.logOk("Venta eliminada")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar venta", null)
      )
    );
  }
  getCantidadDiaria(): Observable<number> {
    const url = `${this.baseUrl + "api/VentaDiaria"}`;
    return this.http.get<number>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<number>(
          "Suma cantidad diaria",
          null
        )
      )
    );
  }

  post(venta: Venta): Observable<Venta> {
    return this.http.post<Venta>(this.baseUrl + "api/Venta", venta).pipe(
      tap((_) => this.handleErrorService.logOk("Venta registrada")),
      catchError(
        this.handleErrorService.handleError<Venta>("Registro de venta", null)
      )
    );
  }

  get(codigo: string): Observable<Venta> {
    const url = `${this.baseUrl + "api/Venta"}/${codigo}`;
    return this.http.get<Venta>(url, httpOptions).pipe(
      tap((_) => console.log("Venta consultada")),
      catchError(
        this.handleErrorService.handleError<Venta>(
          "Consulta por codigo de venta",
          null
        )
      )
    );
  }

  getCodigo(): Observable<string>{
    const url = `${this.baseUrl + "api/VentaCodigo"}`;
    return this.http.get<string>(url, httpOptions).pipe(
      //tap((_) => console.log("Codigo de venta generado")),
      catchError(
        this.handleErrorService.handleError<string>(
          "Codigo de venta",
          null
        )
      )
    );
  }

  put(venta: Venta): Observable<Venta> {
    const url = `${this.baseUrl + 'api/Venta'}/${venta.codigoVenta}`;
    return this.http.put<Venta>(url, venta, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.logOk('Venta actualizada')),
        catchError(this.handleErrorService.handleError<Venta>('Editar venta'))
      );
  }
}
