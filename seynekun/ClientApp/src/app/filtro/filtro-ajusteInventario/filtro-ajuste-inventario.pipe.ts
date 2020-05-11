import { Pipe, PipeTransform } from "@angular/core";
import { AjusteDeInventario } from "src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario";

@Pipe({
  name: "filtroAjusteInventario",
})
export class FiltroAjusteInventarioPipe implements PipeTransform {
  transform(
    ajusteInventarios: AjusteDeInventario[],
    textoABuscar: string
  ): any {
    if (textoABuscar == null) return ajusteInventarios;
    return ajusteInventarios.filter(
      (a) =>
        a.codigoElemento.toLowerCase().indexOf(textoABuscar.toLowerCase()) !==
          -1 ||
        a.nombreBodega.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
    );
  }
}
