import { Pipe, PipeTransform } from '@angular/core';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';

@Pipe({
  name: 'materiaPrima'
})
export class MateriaPrimaPipe implements PipeTransform {

  transform(
    ajusteInventarios: MateriaPrima[],
    textoABuscar: string
  ): any {
    if (textoABuscar == null) return ajusteInventarios;
    return ajusteInventarios.filter(
      (a) =>
        a.codigoProductor.toLowerCase().indexOf(textoABuscar.toLowerCase()) !==
        -1 ||
        a.estadoMateria.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
    );
  }

}
