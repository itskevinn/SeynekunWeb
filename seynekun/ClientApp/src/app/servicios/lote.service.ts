import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from './@base/handle-http-error.service';
import { Observable, from } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Lote } from '../seynekun/models/modelo-lote/lote';

@Injectable({
  providedIn: 'root'
})
export class LoteService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Lote[]> {
    return this.http.get<Lote[]>(this.baseUrl + 'api/Lote')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos traídos')),
        catchError(this.handleErrorService.handleError<Lote[]>("Consulta de lotes", null))
      );
  }
  post(lote: Lote): Observable<Lote> {
    return this.http.post<Lote>(this.baseUrl + 'api/Lote', lote)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Lote>("Registro del lote", null))
      );
  }
} 
