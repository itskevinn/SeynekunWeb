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
