import { HttpClient } from '@angular/common/http'
import { HandleHttpErrorService } from '../../@base/handle-http-error.service'
import { Observable, from } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { Empleado } from 'src/app/seynekun/models/modelo-empleado/empleado'
import { Injectable, Inject } from '@angular/core'

@Injectable({
  providedIn: 'root',
})
export class EmpleadoService {
  urlBase: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') urlBase: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.urlBase = urlBase
  }
  gets(): Observable<Empleado[]> {
    return this.http.get<Empleado[]>(this.urlBase + 'api/Empleado').pipe(
      tap((_) => this.handleErrorService.log('Datos traídos')),
      catchError(
        this.handleErrorService.handleError<Empleado[]>(
          'Consulta de empelados',
          null,
        ),
      ),
    )
  }
  post(empleado: Empleado): Observable<Empleado> {
    return this.http
      .post<Empleado>(this.urlBase + 'api/Empleado', empleado)
      .pipe(
        tap((_) => this.handleErrorService.log('Datos enviados')),
        catchError(
          this.handleErrorService.handleError<Empleado>(
            'Registro del empleado',
            null,
          ),
        ),
      )
  }
  get(identificacion: string): Observable<Empleado> {
    return this.http
      .get<Empleado>(this.urlBase + 'api/Empleado/' + identificacion)
      .pipe(
        tap((_) =>
          this.handleErrorService.log(
            'Identifiación enviada y empleado recibido',
          ),
        ),
        catchError(
          this.handleErrorService.handleError<Empleado>('Consulta x id', null),
        ),
      )
  }
  put(identificacion: string, empleado: Empleado): Observable<Empleado> {
    return this.http
      .put<Empleado>(this.urlBase + 'api/Empleado/' + identificacion, empleado)
      .pipe(
        tap((_) =>
          this.handleErrorService.log(
            'Identifiación enviada y empleado actualizado',
          ),
        ),
        catchError(
          this.handleErrorService.handleError<Empleado>('Actualizar', null),
        ),
      )
  }
  delete(empleado: Empleado | string): Observable<string> {
    const id =
      typeof empleado === "string" ? empleado : empleado.identificacion;
    return this.http.delete<string>(this.urlBase + 'api/empleado/' + id)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<string>('Eliminar Empleado', null))
      );
  }
}
