import { Producto } from "../modelo-producto/producto"
import { Cliente } from "../modelo-cliente/cliente"

export class DetalleVenta {
    codigoDetalle: string
    codigoVenta: string
    codigoProducto: string
    cantidadProducto: number
    total: number
}
