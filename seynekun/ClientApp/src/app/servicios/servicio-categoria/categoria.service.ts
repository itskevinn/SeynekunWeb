import { Injectable, Inject } from "@angular/core";
import { Categoria } from "src/app/seynekun/models/modelo-categoria/categoria";
import { Observable } from "rxjs";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { catchError, tap } from "rxjs/operators";
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
export class CategoriaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  gets(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.baseUrl + "api/Categoria").pipe(
      tap((_) => this.handleErrorService.log("Datos traídos")),
      catchError(
        this.handleErrorService.handleError<Categoria[]>(
          "Consulta de Categorias",
          null
        )
      )
    );
  }
  delete(categoria: Categoria | string): Observable<string> {
    const id = typeof categoria === "string" ? categoria : categoria.nombre;
    return this.http.delete<string>(this.baseUrl + "api/Categoria/" + id).pipe(
      tap((_) => this.handleErrorService.log("datos enviados")),
      catchError(
        this.handleErrorService.handleError<string>("Eliminar Categoria", null)
      )
    );
  }
  post(categoria: Categoria): Observable<Categoria> {
    return this.http
      .post<Categoria>(this.baseUrl + "api/Categoria", categoria)
      .pipe(
        tap((_) => this.handleErrorService.log("Datos enviados")),
        catchError(
          this.handleErrorService.handleError<Categoria>(
            "Registro del Categoria",
            null
          )
        )
      );
  }
  get(codigo: string): Observable<Categoria> {
    const url = `${this.baseUrl + "api/Categoria"}/${codigo}`;
    return this.http.get<Categoria>(url, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<Categoria>(
          "Consulta por código",
          null
        )
      )
    );
  }

  put(codigo: string, categoria: Categoria): Observable<Categoria> {
    const url = `${this.baseUrl}api/Categoria/${codigo}`;
    return this.http.put<Categoria>(url, categoria, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("Datos enviados")),
      catchError(
        this.handleErrorService.handleError<Categoria>("Actualizar", null)
      )
    );
  }
}
