import { Pipe, PipeTransform } from "@angular/core";
import { Bodega } from "src/app/seynekun/models/modelo-bodega/bodega";

@Pipe({
  name: "filtroBodega",
})
export class FiltroBodegaPipe implements PipeTransform {
  transform(bodegas: Bodega[], textoABuscar: string): any {
    if (textoABuscar == null) return bodegas;
    return bodegas.filter(
      (b) =>
        b.nombre.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1 ||        
        b.direccion.toLowerCase().indexOf(textoABuscar.toLowerCase()) !==
          -1 ||
        b.estado.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
    );
  }
}
