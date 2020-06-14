
import { Injectable, Inject } from '@angular/core';
import { tap, catchError } from "rxjs/operators";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { BodegaProducto } from 'src/app/seynekun/models/modelo-bodega-producto/bodega-producto';
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
export class BodegaStockService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  get(codigoProducto: string): Observable<BodegaProducto[]> {
    const url = `${this.baseUrl + "api/BodegaProducto"}/${codigoProducto}`;
    return this.http.get<BodegaProducto[]>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<BodegaProducto[]>("Consulta por código", null)
      )
    );
  }
}
