import { DetalleVenta } from "../modelo-detalle-venta/detalle-venta"

export class Venta {
    codigoVenta: string
    detallesVentas: DetalleVenta[]
    clienteId: string
    empleadoId: string
    fecha: Date
    observacion: string
    totalVenta: number
}
