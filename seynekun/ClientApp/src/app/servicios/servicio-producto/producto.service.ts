import { Injectable, Inject } from "@angular/core";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { tap, catchError } from "rxjs/operators";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
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
export class ProductoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  gets(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.baseUrl + "api/Producto").pipe(
      tap((_) => console.log("Datos traídos")),
      catchError(
        this.handleErrorService.handleError<Producto[]>(
          "Consulta de productos",
          null
        )
      )
    );
  }
  delete(producto: Producto | string): Observable<string> {
    const id = typeof producto === "string" ? producto : producto.codigo;
    return this.http.delete<string>(this.baseUrl + "api/Producto/" + id).pipe(
      tap((_) => this.handleErrorService.logOk("datos enviados")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar Producto", null)
      )
    );
  }
  post(producto: Producto): Observable<Producto> {
    return this.http
      .post<Producto>(this.baseUrl + "api/Producto", producto)
      .pipe(
        tap((_) => this.handleErrorService.logOk("Producto registrado con éxito")),
        catchError(
          this.handleErrorService.handleError<Producto>(
            "Registro del producto",
            null
          )
        )
      );
  }
  get(codigo: string): Observable<Producto> {
    const url = `${this.baseUrl + "api/Producto"}/${codigo}`;
    return this.http.get<Producto>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<Producto>("Consulta por código", null)
      )
    );
  }

  put(codigo: string, producto: Producto): Observable<Producto> {
    const url = `${this.baseUrl}api/Producto/${codigo}`;
    return this.http.put<Producto>(url, producto, httpOptions).pipe(
      tap((_) => this.handleErrorService.logOk("Datos enviados")),
      catchError(
        this.handleErrorService.handleError<Producto>("Actualizar", null)
      )
    );
  }

  getCodigo(): Observable<string>{
    const url = `${this.baseUrl + "api/ProductoCodigo"}`;
    return this.http.get<string>(url, httpOptions).pipe(
      //tap((_) => console.log("Codigo de venta generado")),
      catchError(
        this.handleErrorService.handleError<string>("Codigo de venta", null)
      )
    );
  }
}
