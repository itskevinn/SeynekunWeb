import { AjusteDeInventario } from "../modelo-ajuste-inventario/ajuste-de-inventario"

export class Produccion {
  codigoProduccion: string
  fecha: Date
  descripcion: string
  ajustes: AjusteDeInventario[] 
}
