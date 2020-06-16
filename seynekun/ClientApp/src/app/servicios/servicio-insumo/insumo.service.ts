import { HttpClient } from '@angular/common/http'
import { Observable, from } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { Injectable, Inject } from '@angular/core'
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service'
import { Insumo } from 'src/app/seynekun/models/modelo-insumo/insumo'

@Injectable({
  providedIn: 'root'
})
export class InsumoService {
  urlBase: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') urlBase: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.urlBase = urlBase }

  post(insumo: Insumo): Observable<Insumo> {
    return this.http.post<Insumo>(this.urlBase + 'api/Insumo', insumo).pipe(
      tap((_) => this.handleErrorService.logOk('Insumo registrado con éxito')),
      catchError(
        this.handleErrorService.handleError<Insumo>(
          'Registro del insumo',
          null
        ),
      ),
    )
  }

  gets(): Observable<Insumo[]> {
    return this.http.get<Insumo[]>(this.urlBase + 'api/Insumo').pipe(
      tap((_) => console.log('Datos traídos')),
      catchError(
        this.handleErrorService.handleError<Insumo[]>(
          'Consulta de insumo',
          null
        ),
      ),
    )
  }

  get(codigo: string): Observable<Insumo> {
    return this.http.get<Insumo>(this.urlBase + 'api/Insumo/' + codigo).pipe(
      tap((_) =>
        console.log('Datos enviados y traídos del backend'),
      ),
      catchError(
        this.handleErrorService.handleError<Insumo>(
          'Consulta del insumo por id',
          null
        ),
      ),
    )
  }

  put(identificacion: string, insumo: Insumo): Observable<Insumo> {
    const url = `${this.urlBase}api/Insumo/${identificacion}`
    return this.http.put<Insumo>(url, insumo).pipe(
      catchError(
        this.handleErrorService.handleError<Insumo>('Actualizar', null),
      ),
    )
  }
}
