import { Injectable, Inject } from "@angular/core";
import { AjusteDeInventario } from "src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario";
import { Observable } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
const httpOptionsPut = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
  responseType: "text",
};

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable({
  providedIn: "root",
})
export class AjusteInventarioService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  gets(): Observable<AjusteDeInventario[]> {
    return this.http.get<AjusteDeInventario[]>(this.baseUrl + "api/AjusteInventario").pipe(
      tap((_) => this.handleErrorService.log("Datos traídos")),
      catchError(
        this.handleErrorService.handleError<AjusteDeInventario[]>(
          "Consulta de AjusteDeInventarios",
          null
        )
      )
    );
  }
  getCantidad(bodega: string, producto: string): Observable<number> {
    return this.http.get<number>(this.baseUrl + "api/AjusteInventario/"+bodega+"/"+producto).pipe(
      tap((_) => this.handleErrorService.log("Datos traídos")),
      catchError(
        this.handleErrorService.handleError<number>(
          "Consulta de Cantidad Producto",
          null
        )
      )
    );
  }
  delete(ajusteInventario: AjusteDeInventario | string): Observable<string> {
    const id = typeof ajusteInventario === "string" ? ajusteInventario : ajusteInventario.codigo;
    return this.http.delete<string>(this.baseUrl + "api/AjusteDeInventario/" + id).pipe(
      tap((_) => this.handleErrorService.log("datos enviados")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar AjusteInventario", null)
      )
    );
  }
  post(ajusteInventario: AjusteDeInventario): Observable<AjusteDeInventario> {
    return this.http.post<AjusteDeInventario>(this.baseUrl + "api/AjusteInventario", ajusteInventario).pipe(
      tap((_) => this.handleErrorService.log("Datos enviados")),
      catchError(
        this.handleErrorService.handleError<AjusteDeInventario>("Registro del AjusteInventario", null)
      )
    );
  }
  get(codigo: string): Observable<AjusteDeInventario> {
    const url = `${this.baseUrl + "api/AjusteInventario"}/${codigo}`;
    return this.http.get<AjusteDeInventario>(url, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<AjusteDeInventario>("Consulta por código", null)
      )
    );
  }

  put(codigo: string, ajusteInventario: AjusteDeInventario): Observable<AjusteDeInventario> {
    const url = `${this.baseUrl}api/AjusteDeInventario/${codigo}`;
    return this.http.put<AjusteDeInventario>(url, ajusteInventario, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("Datos enviados")),
      catchError(
        this.handleErrorService.handleError<AjusteDeInventario>("Actualizar", null)
      )
    );
  }
}
