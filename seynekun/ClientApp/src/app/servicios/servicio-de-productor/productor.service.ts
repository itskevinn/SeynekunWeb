import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { HandleHttpErrorService } from '../../@base/handle-http-error.service'
import { Observable, from } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor'

const httpOptionsPut = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  responseType: 'text'
};

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})
export class ProductorService {
  baseUrl: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.baseUrl = baseUrl
  }
  gets(): Observable<Productor[]> {
    return this.http.get<Productor[]>(this.baseUrl + 'api/Productor').pipe(
      tap((_) => console.log('Datos traídos')),
      catchError(
        this.handleErrorService.handleError<Productor[]>(
          'Consulta de prodcutores',
          null,
        ),
      ),
    )
  }
  delete(productor: Productor| string): Observable<string> {
    const id =
      typeof productor === "string" ? productor : productor.identificacion;
    return this.http.delete<string>(this.baseUrl + 'api/productor/'+ id)
    .pipe(
      tap(_ => this.handleErrorService.logOk('datos enviados')),
      catchError(this.handleErrorService.handleError<string>('Elimiar Persona', null))
    );
  }
  post(productor: Productor): Observable<Productor> {
    return this.http
      .post<Productor>(this.baseUrl + 'api/Productor', productor)
      .pipe(
        tap((_) => this.handleErrorService.logOk('Productor registrado con éxito')),
        catchError(
          this.handleErrorService.handleError<Productor>(
            'Registro del prodcutor',
            null,
          ),
        ),
      )
  }
  get(identificacion: string): Observable<Productor> {
    const url = `${this.baseUrl + 'api/Productor'}/${identificacion}`
    return this.http.get<Productor>(url, httpOptions).pipe(
      tap((_) => console.log('Datos enviados y recibidos')),
      catchError(
        this.handleErrorService.handleError<Productor>('Consulta x id', null),
      ),
    )
  }

  put(identificacion: string, productor: Productor): Observable<Productor> {
    const url = `${this.baseUrl}api/Productor/${identificacion}`
    return this.http.put<Productor>(url, productor, httpOptions).pipe(
      tap((_) => this.handleErrorService.logOk('Datos enviados')),
      catchError(
        this.handleErrorService.handleError<Productor>('Actualizar', null),
      ),
    )
  }
}
