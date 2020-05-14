import { Producto } from "../modelo-producto/producto";

export class MateriaPrima {
    fecha: Date;
    cantidad: number;
    unidadMedida: string;
    codigo: number;
    codigoProductor: string;
    productos: Producto[]
}
