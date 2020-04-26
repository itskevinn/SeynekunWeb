import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable, from } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor';

@Injectable({
  providedIn: 'root'
})
export class ProductorService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  gets(): Observable<Productor[]> {
    return this.http.get<Productor[]>(this.baseUrl + 'api/Productor')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos traídos')),
        catchError(this.handleErrorService.handleError<Productor[]>("Consulta de prodcutores", null))
      );
  }
  post(productor: Productor): Observable<Productor> {
    return this.http.post<Productor>(this.baseUrl + 'api/Productor', productor)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Productor>("Registro del prodcutor", null))
      );
  }  
} 
