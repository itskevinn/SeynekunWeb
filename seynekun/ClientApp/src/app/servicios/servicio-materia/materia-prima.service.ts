import { Injectable, Inject} from '@angular/core';
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
        tap((_) => this.handleErrorService.log("Datos traídos")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima[]>(
            "Consulta de MateriaPrimas",
            null
          )
        )
      );
  }
 
  delete(ajusteInventario: MateriaPrima | string): Observable<string> {
    const id =
      typeof ajusteInventario === "string"
        ? ajusteInventario
        : ajusteInventario.codigo;
    return this.http
      .delete<string>(this.baseUrl + "api/MateriaPrima/" + id)
      .pipe(
        tap((_) => this.handleErrorService.log("datos enviados")),
        catchError(
          this.handleErrorService.handleError<string>(
            "Eliminar MateriaPrima",
            null
          )
        )
      );
  }
  post(ajusteInventario: MateriaPrima): Observable<MateriaPrima> {
    return this.http
      .post<MateriaPrima>(
        this.baseUrl + "api/MateriaPrima",
        ajusteInventario
      )
      .pipe(
        tap((_) => this.handleErrorService.log("Datos enviados")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima>(
            "Registro del MateriaPrima",
            null
          )
        )
      );
  }
  get(codigo: string): Observable<MateriaPrima> {
    const url = `${this.baseUrl + "api/MateriaPrima"}/${codigo}`;
    return this.http.get<MateriaPrima>(url, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<MateriaPrima>(
          "Consulta por código",
          null
        )
      )
    );
  }

  put(
    codigo: string,
    ajusteInventario: MateriaPrima
  ): Observable<MateriaPrima> {
    const url = `${this.baseUrl}api/MateriaPrima/${codigo}`;
    return this.http
      .put<MateriaPrima>(url, ajusteInventario, httpOptions)
      .pipe(
        tap((_) => this.handleErrorService.log("Datos enviados")),
        catchError(
          this.handleErrorService.handleError<MateriaPrima>(
            "Actualizar",
            null
          )
        )
      );
  }
}
