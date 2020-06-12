import { Component } from "@angular/core";
import { Usuario } from "./seynekun/models/modelo-usuario/usuario";
import { AutenticacionService } from "./servicios/servicio-autenticacion/autenticacion.service";
import { Router } from "@angular/router";
import { EventoService } from "./servicios/servicio-evento/evento.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  title = "app";
  usuarioActual: Usuario;
  ingreso = false;
  primerIngreso: number;
  isExpanded: boolean;
  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService,
    private eventoServicio: EventoService
  ) {
    this.autenticacionServicio.currentUser.subscribe(
      (x) => (this.usuarioActual = x)
    );
    if (this.usuarioActual) {
      this.ingreso = true;
    }
    this.isExpanded = JSON.parse(localStorage.getItem("estadoNav"));
  }
  reload() {
    window.location.reload();
  }
  ngOnInit() {
    this.eventoServicio.mensajePersonalizado.subscribe(
      (estado) => (this.isExpanded = estado)
    );
  }
  cambiarEstado() {
    this.eventoServicio.cambiarMensaje(this.isExpanded);
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
    this.cambiarEstado();
  }
  logout() {
    this.autenticacionServicio.logout();
    this.router.navigate(["/Login"]);
    this.ingreso = false;
  }
}
