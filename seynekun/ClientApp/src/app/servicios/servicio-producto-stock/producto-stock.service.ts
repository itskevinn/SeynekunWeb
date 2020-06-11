import { Injectable, Inject } from "@angular/core";
import { Producto } from "src/app/seynekun/models/modelo-producto/producto";
import { tap, catchError } from "rxjs/operators";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { ProductoEnBodega } from "src/app/seynekun/models/modelo-producto-bodega/producto-en-bodega";
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
export class ProductStockService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  get(nombre: string): Observable<ProductoEnBodega[]> {
    const url = `${this.baseUrl + "api/ProductoStock"}/${nombre}`;
    return this.http.get<ProductoEnBodega[]>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<ProductoEnBodega[]>("Consulta por código", null)
      )
    );
  }
  getProductosxMateria(codigo: string): Observable<ProductoEnBodega[]> {
    const url = `${this.baseUrl + "api/ProductoStockMateria"}/${codigo}`;
    return this.http.get<ProductoEnBodega[]>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<ProductoEnBodega[]>("Consulta por código", null)
      )
    );
  }
}
