import { Component, OnInit } from '@angular/core';
import { Cliente } from '../../models/modelo-cliente/cliente';
import { ClienteService } from 'src/app/servicios/servicio-de-cliente/cliente.service';

@Component({
  selector: 'app-cliente-consulta',
  templateUrl: './cliente-consulta.component.html',
  styleUrls: ['./cliente-consulta.component.css']
})
export class ClienteConsultaComponent implements OnInit {

  clientes: Cliente[];
  cliente: Cliente;
  listaVacia: Boolean = true;
  cantidadclientes: Number;
  textoABuscar: String;
  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.clienteService.gets().subscribe(result => {
      this.clientes = result;
      this.clientes = [{
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
        numeroTelefono2:"",
      },
      {
        nombre: "Juan",
        apellido: "Macias",
        numeroTelefono: "3233213214",
        identificacion: "90909",
        tipoIdentificacion: "Pasaporte",
        email: "juan@gmail.com",
        direccion: "Calle Santa Marta",
        barrio: "Los Cortijos",
        departamento: "Guajira",
        municipio: "San Diego",
        numeroTelefono2:"399223818",
      }]
    });
  }
  validarTamañoLista() {
    if (this.clientes.length == 0) {
      this.listaVacia == true;
    }
    else this.listaVacia == false;
  }
  contarClientes() {
    this.cantidadclientes = this.clientes.length;
  }


}
