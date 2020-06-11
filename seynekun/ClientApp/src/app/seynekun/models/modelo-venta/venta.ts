import { DetalleVenta } from "../modelo-detalle-venta/detalle-venta"
import { Cliente } from "../modelo-cliente/cliente"

export class Venta {
    codigoVenta: string
    detallesVentas: DetalleVenta[]
    clienteId: string
    fecha: Date
    observacion:  string
    totalVenta: number
}
