import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/seynekun/models/modelo-cliente/cliente';
import { ClienteService } from 'src/app/servicios/servicio-de-cliente/cliente.service';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-consulta-cliente',
  templateUrl: './consulta-cliente.component.html',
  styleUrls: ['./consulta-cliente.component.css']
})
export class ConsultaClienteComponent implements OnInit {
  clientes: Cliente[];
  cliente: Cliente;
  listaVacia: Boolean = true;
  cantidadclientes: Number;
  textoABuscar: String;
  constructor(private clienteService: ClienteService, private eventoServicio: EventoService, public activeModal: NgbActiveModal) { }

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
  enviarId(id: string) {
    this.eventoServicio.cambiarCodigoCliente(id);
    console.log(id)
  }
}
