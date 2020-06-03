import { HttpClient } from '@angular/common/http'
import { Observable, from } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { Injectable, Inject } from '@angular/core'
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service'
import { Fabricante } from 'src/app/seynekun/models/modelo-fabricante/fabricante'

@Injectable({
  providedIn: 'root'
})
export class FabricanteService {
  urlBase: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') urlBase: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.urlBase = urlBase }
  
  post(fabricante: Fabricante): Observable<Fabricante> {
    return this.http.post<Fabricante>(this.urlBase + 'api/Fabricante', fabricante).pipe(
      tap((_) => this.handleErrorService.logOk('Fabricante registrado con éxito')),
      catchError(
        this.handleErrorService.handleError<Fabricante>(
          'Registro del fabricante',
          null
        ),
      ),
    )
  }

  gets(): Observable<Fabricante[]> {
    return this.http.get<Fabricante[]>(this.urlBase + 'api/Fabricante').pipe(
      tap((_) => console.log('Datos traídos')),
      catchError(
        this.handleErrorService.handleError<Fabricante[]>(
          'Consulta de fabricante',
          null
        ),
      ),
    )
  }

  get(identificacion: string): Observable<Fabricante> {
    return this.http.get<Fabricante>(this.urlBase + 'api/Fabricante').pipe(
      tap((_) =>
        console.log('Datos enviados y traídos del backend'),
      ),
      catchError(
        this.handleErrorService.handleError<Fabricante>(
          'Consulta del fabricante por id',
          null
        ),
      ),
    )
  }
  
  put(identificacion: string, fabricante: Fabricante): Observable<Fabricante> {
    const url = `${this.urlBase}api/Fabricante/${identificacion}`
    return this.http.put<Fabricante>(url, fabricante).pipe(
      tap((_) => this.handleErrorService.logOk('Datos enviados y recibidos')),
      catchError(
        this.handleErrorService.handleError<Fabricante>('Actualizar', null),
      ),
    )
  }
}
