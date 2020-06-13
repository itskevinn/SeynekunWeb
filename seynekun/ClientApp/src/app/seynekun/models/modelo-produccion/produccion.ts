import { AjusteDeInventario } from "../modelo-ajuste-inventario/ajuste-de-inventario"

export class Produccion {
  codigoVenta: string
  Ajustes: AjusteDeInventario[]
  clienteId: string
  empleadoId: string
  fecha: Date
  observacion: string
  totalVenta: number
}
