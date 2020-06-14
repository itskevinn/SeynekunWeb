import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { AutenticacionService } from 'src/app/servicios/servicio-autenticacion/autenticacion.service';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';
import { Usuario } from 'src/app/seynekun/models/modelo-usuario/usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;
  submitted: boolean;
  loading: boolean;
  invitado: Usuario;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private autenticacionServicio: AutenticacionService,
    private modalService: NgbModal,
    public eventoServicio: EventoService
  ) {
    // redirect to home if already logged in
    if (this.autenticacionServicio.currentUserValue) {
      this.router.navigate(['/']);
    }
  }
  solicitarRegistro() {
    this.eventoServicio.cambiarMensaje(true);
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      usuario: ['', Validators.required],
      contrasena: ['', Validators.required]
    });
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  reload() {
    window.location.reload();
  }
  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }
  crearInvitado() {
    this.invitado = new Usuario();
    this.invitado.id = "Invitado";
    this.invitado.nombre = "Invitado";
    this.invitado.nombreUsuario = "Invitado";
    this.invitado.contrasena = "Invitado";
    this.invitado.apellido = "Invitado";
    this.invitado.tipo = "Invitado";
    this.invitado.token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwiZW1haWwiOiJhZG1pbkBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9tb2JpbGVwaG9uZSI6IjMxODAwMDAwMDAiLCJyb2xlIjpbIlJvbDEiLCJSb2wyIl0sIm5iZiI6MTU5MjEwMTczNSwiZXhwIjoxNTkyNzA2NTM1LCJpYXQiOjE1OTIxMDE3MzV9.Ofe6e976uvRwfPk9c-v73i5m0vhZfxPCVZU016bmRJc"
    sessionStorage.setItem('currentUser', JSON.stringify(this.invitado));
  }
  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.autenticacionServicio.login(this.f.usuario.value, this.f.contrasena.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
          if (sessionStorage.getItem('currentUser')) {
            this.reload();
          }
          else {
            this.loading = false;
          }
        },
        error => {
          this.loading = false;
        });
  }
}
