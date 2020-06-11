import { Injectable, Inject } from '@angular/core';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
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
export class MateriaPrimaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  gets(): Observable<MateriaPrima[]> {
    return this.http
      .get<MateriaPrima[]>(this.baseUrl + "api/MateriaPrima")
      .pipe(
        tap((_) => console.log("Datos traídos")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima[]>(
            "Consulta de MateriaPrimas",
            null
          )
        )
      );
  }
  getDisponibles(): Observable<MateriaPrima[]> {
    return this.http
      .get<MateriaPrima[]>(this.baseUrl + "api/MateriaPrimaDisponible")
      .pipe(
        tap((_) => console.log("Datos traídos")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima[]>(
            "Consulta de MateriaPrimas",
            null
          )
        )
      );
  }
  delete(materiaPrima: MateriaPrima | string): Observable<string> {
    const id =
      typeof materiaPrima === "string"
        ? materiaPrima
        : materiaPrima.codigo;
    return this.http
      .delete<string>(this.baseUrl + "api/MateriaPrima/" + id)
      .pipe(
        tap((_) => this.handleErrorService.logOk("datos enviados")),
        catchError(
          this.handleErrorService.handleError<string>(
            "Eliminar MateriaPrima",
            null
          )
        )
      );
  }
  post(materiaPrima: MateriaPrima): Observable<MateriaPrima> {
    return this.http
      .post<MateriaPrima>(
        this.baseUrl + "api/MateriaPrima",
        materiaPrima
      )
      .pipe(
        tap((_) => this.handleErrorService.logOk("Materia prima registrada con éxito")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima>(
            "Registro del MateriaPrima",
            null
          )
        )
      );
  }
  get(codigo: string): Observable<MateriaPrima[]> {
    const url = `${this.baseUrl + "api/MateriaPrima"}/${codigo}`;
    return this.http.get<MateriaPrima[]>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<MateriaPrima[]>(
          "Consulta por código",
          null
        )
      )
    );
  }

  put(
    codigo: string,
    materiaPrima: MateriaPrima
  ): Observable<MateriaPrima> {
    const url = `${this.baseUrl}api/MateriaPrima/${codigo}`;
    return this.http
      .put<MateriaPrima>(url, materiaPrima, httpOptions)
      .pipe(
        tap((_) => this.handleErrorService.logOk("Datos enviados")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima>(
            "Actualizar",
            null
          )
        )
      );
  }
}
