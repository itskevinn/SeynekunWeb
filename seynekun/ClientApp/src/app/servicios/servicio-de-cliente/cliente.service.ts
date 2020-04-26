import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable, from } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Injectable, Inject } from '@angular/core';
import { Cliente } from 'src/app/seynekun/models/modelo-cliente/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  urlBase: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') urlBase: string,
    private handleErrorService: HandleHttpErrorService) {
    this.urlBase = urlBase;
  }
  gets(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.urlBase + 'api/Cliente')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos traídos')),
        catchError(this.handleErrorService.handleError<Cliente[]>("Consulta de clientes", null))
      );
  }
  post(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.urlBase + 'api/Cliente', cliente)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Cliente>("Registro del cliente", null))
      );
  }
  get(identificacion: string): Observable<Cliente> {
    return this.http.get<Cliente>(this.urlBase + 'api/Cliente')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados al y traídos del backend')),
        catchError(this.handleErrorService.handleError<Cliente>("Consulta del cliente por id", null))
      );
  }
}
