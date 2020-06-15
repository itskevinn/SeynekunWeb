import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
  baseUrl: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.baseUrl = baseUrl
  }

  gets(): Observable<Productor[]> {
    return this.http.get<Productor[]>(this.baseUrl + 'api/Solicitud').pipe(
      tap((_) => console.log('Datos traídos')),
      catchError(
        this.handleErrorService.handleError<Productor[]>(
          'Consulta de solicitudes',
          null,
        ),
      ),
    )
  }
  post(productor: Productor): Observable<Productor> {
    return this.http
      .post<Productor>(this.baseUrl + 'api/Productor', productor)
      .pipe(
        tap((_) => this.handleErrorService.logOk('Solicitud registrada con éxito')),
        catchError(
          this.handleErrorService.handleError<Productor>(
            'Registro del prodcutor',
            null,
          ),
        ),
      )
  }
  getCantidadSolicitud(): Observable<number> {
    const url = `${this.baseUrl + "api/SolicitudCantidad"}`;
    return this.http.get<number>(url, httpOptions).pipe(
      tap((_) => console.log("Datos enviados y recibidos")),
      catchError(
        this.handleErrorService.handleError<number>(
          "Consulta por código",
          null
        )
      )
    );
  }
}
