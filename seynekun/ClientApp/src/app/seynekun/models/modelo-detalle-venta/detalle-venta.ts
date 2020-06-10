import { Producto } from "../modelo-producto/producto"
import { Cliente } from "../modelo-cliente/cliente"

export class DetalleVenta {
    codigoDetalle: string
    codigoVenta: string
    cliente: Cliente
    producto: Producto
    cantidadProducto: number
    total: number
}
