import { Injectable, Inject, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Productor } from 'src/app/seynekun/models/modelo-productor/productor';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import * as singnalR from '@aspnet/signalr';

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
  baseUrl: string
  private hubConnection: singnalR.HubConnection;
  signalRecived = new EventEmitter<Productor>();

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
    this.buildConnection();
    this.startConnection();
  }

  private buildConnection = () => {
    this.hubConnection = new singnalR.HubConnectionBuilder()
    .withUrl(this.baseUrl + "signalHub")
    .build();
  }
  private startConnection = () => {
    this.hubConnection
    .start()
    .then(() => {
      console.log("Iniciando signal");
      this.registerSignalEvents();
    })
    .catch(err => {
      console.log("Error en el signal" + err);
      setTimeout(function() {
        this.startConnection();
      }, 3000);
    });
  }
  private registerSignalEvents(){
    this.hubConnection.on("productorRegistrado", (data: Productor) => {
      this.signalRecived.emit(data);
    });
    this.hubConnection.on("productorLista", (productores) => {
      this.signalRecived.emit(productores);
    });
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
