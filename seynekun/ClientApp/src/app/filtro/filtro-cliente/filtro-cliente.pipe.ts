import { Pipe, PipeTransform } from '@angular/core';
import { Cliente } from 'src/app/seynekun/models/modelo-cliente/cliente';

@Pipe({
  name: 'filtroCliente'
})
export class FiltroClientePipe implements PipeTransform {

  transform(clientes: Cliente[], textoABuscar: string): any {
    if (textoABuscar == null) return clientes;
    return clientes.filter(e => e.nombre.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.apellido.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.identificacion.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.barrio.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.departamento.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.municipio.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.tipoIdentificacion.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1);      
  }
}
