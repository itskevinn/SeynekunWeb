import { Pipe, PipeTransform } from '@angular/core';
import { Categoria } from 'src/app/seynekun/models/modelo-categoria/categoria';

@Pipe({
  name: 'filtroCategoria'
})
export class FiltroCategoriaPipe implements PipeTransform {

   transform(categorias: Categoria[], textoABuscar: string): any {
    if (textoABuscar == null) return categorias;
    return categorias.filter(
      (b) =>
        b.nombre.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1 ||                
        b.estado.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
    );
  }

}
