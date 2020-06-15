import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReporteService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(tipo: string): Observable<string> {
    return this.http.post<string>(this.baseUrl + "api/Reporte", tipo).pipe(
      tap((_) => this.handleErrorService.logOk("Reporte generado")),
      catchError(
        this.handleErrorService.handleError<string>("Generar reporte", null)
      )
    );
  }
}
