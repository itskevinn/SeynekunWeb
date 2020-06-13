import { Component } from "@angular/core";
import { Usuario } from "../seynekun/models/modelo-usuario/usuario";
import { AutenticacionService } from "../servicios/servicio-autenticacion/autenticacion.service";
import { Router } from "@angular/router";
import { EventoService } from "../servicios/servicio-evento/evento.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded : boolean;
  usuario: Usuario;
  ingreso = false;
  primerIngreso: number;
  tipo: string;

  constructor(
    private router: Router,
    private autenticacionServicio: AutenticacionService,
    private eventoServicio: EventoService
  ) {
    this.autenticacionServicio.currentUser.subscribe((x) => (this.usuario = x));
    if (this.autenticacionServicio.currentUserValue != null) {
      this.tipo = this.usuario.tipo;
      this.ingreso = true;
      this.primerIngreso = this.primerIngreso + 1;
    }
  }
  ngOnInit(){
    this.eventoServicio.mensajePersonalizado.subscribe(estado=>this.isExpanded=estado)
  }
  cambiarEstado(){
    this.eventoServicio.cambiarMensaje(this.isExpanded);
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    this.cambiarEstado()
  }
}
