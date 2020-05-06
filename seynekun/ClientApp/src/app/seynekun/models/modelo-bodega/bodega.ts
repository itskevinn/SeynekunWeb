import { Producto } from "../modelo-producto/producto";

export class Bodega {
    nombre: string;
    detalle: string;        
    productos: Producto[];
    estado: string;
    direccion: string;
}
