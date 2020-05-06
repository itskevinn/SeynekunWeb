import { Producto } from "../modelo-producto/producto";

export class Categoria {
    nombre: string;
    detalle: string;
    productos: Producto[];
    estado: string;
}
