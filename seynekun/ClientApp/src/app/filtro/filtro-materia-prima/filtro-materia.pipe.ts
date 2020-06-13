import { Pipe, PipeTransform } from '@angular/core';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';

@Pipe({
  name: 'filtroMateria'
})
export class FiltroMateriaPipe implements PipeTransform {

  transform(clientes: MateriaPrima[], textoABuscar: string): any {
    if (textoABuscar == null) return clientes;
    return clientes.filter(e => e.codigoProductor.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.nombreProductor.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.tipo.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.estadoMateria.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
    );
  }
}
