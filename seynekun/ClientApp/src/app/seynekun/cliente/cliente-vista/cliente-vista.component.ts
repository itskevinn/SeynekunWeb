import { Component, OnInit } from '@angular/core';
import { Cliente } from '../../models/modelo-cliente/cliente';
import { ClienteService } from 'src/app/servicios/servicio-de-cliente/cliente.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cliente-vista',
  templateUrl: './cliente-vista.component.html',
  styleUrls: ['./cliente-vista.component.css']
})
export class ClienteVistaComponent implements OnInit {
  cliente: Cliente;
  textoABuscar: string;
  seEncontro : Boolean;
  constructor(private clienteService: ClienteService, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    const identificacion = this.rutaActiva.snapshot.params.identificacion;
      this.clienteService.get(identificacion).subscribe(result => {
        this.cliente = result;
        this.cliente !=null ? this.seEncontro = true : this.seEncontro = false;
        this.cliente = {
          nombre: "Kevin",
          apellido: "Pontón",
          numeroTelefono: "3213213214",
          identificacion: "119322",
          tipoIdentificacion: "CC",
          email: "keviinpn2@gmail.com",
          direccion: "Calle San Jorge",
          barrio: "Mareigua",
          departamento: "Cesar",
          municipio: "Valledupar",
          numeroTelefono2: "",
        }
      });
  }
}
