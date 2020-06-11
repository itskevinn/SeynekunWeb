import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/seynekun/models/modelo-usuario/usuario';
import { AutenticacionService } from 'src/app/servicios/servicio-autenticacion/autenticacion.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';
import { MateriaPrimaService } from 'src/app/servicios/servicio-materia/materia-prima.service';

@Component({
  selector: 'app-materia-prima-productor-vista',
  templateUrl: './materia-prima-productor-vista.component.html',
  styleUrls: ['./materia-prima-productor-vista.component.css']
})
export class MateriaPrimaProductorVistaComponent implements OnInit {
  usuario: Usuario;
  ingreso = false;
  materia: MateriaPrima;
  primerIngreso: number;
  constructor(
    private router: Router,
    private materiaService: MateriaPrimaService,
    private autenticacionServicio: AutenticacionService,
    private rutaActiva: ActivatedRoute
  ) {
    this.autenticacionServicio.currentUser.subscribe(x => this.usuario = x);
    this.ingreso = true;
  }
  ngOnInit(): void {
    const nombre = this.rutaActiva.snapshot.params.id;
    this.materiaService.getInfo(nombre).subscribe((result) => {
      this.materia = result;
    });
  }

}
