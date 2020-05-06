import { Categoria } from "../modelo-categoria/categoria"
import { Bodega } from "../modelo-bodega/bodega"

export class Producto {
    codigo: string
    precio: number
    nombre: string
    estado: string
    descripcion: string
    categoria: Categoria
    bodega: Bodega
}
