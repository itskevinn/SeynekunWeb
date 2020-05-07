import { Pipe, PipeTransform } from '@angular/core';
import { Producto } from 'src/app/seynekun/models/modelo-producto/producto';

@Pipe({
  name: "filtroProducto",
})
export class FiltroProductoPipe implements PipeTransform {
  transform(productos: Producto[], textoABuscar: string): any {
    if (textoABuscar == null) return productos;
    return productos.filter(
      (e) =>
        e.nombre.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1 ||
        e.codigo.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1 ||
        e.nombreBodega.toLowerCase().indexOf(textoABuscar.toLowerCase()) !==
          -1 ||
        e.nombreCategoria.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
    );
  }
}
