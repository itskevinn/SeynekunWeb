import { Pipe, PipeTransform } from '@angular/core';
import { Productor } from '../../seynekun/models/modelo-productor/productor';

@Pipe({
  name: 'filtroProductor'
})
export class FiltroProductorPipe implements PipeTransform {

  transform(productores: Productor[], textoABuscar: string): any {
    if (textoABuscar == null) return productores;
    return productores.filter(p => p.nombreProductor.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.apellidoProductor.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.cedulaProductor.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.cedulaCafetera.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.codigoFinca.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.codigoSica.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.vereda.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || p.municipio.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1 
      || p.nombrePredio.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1);
  }

}
