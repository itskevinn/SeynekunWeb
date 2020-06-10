import { Producto } from "../modelo-producto/producto";

export class MateriaPrima {
  fecha: Date;
  cantidad: number;
  codigo: string;
  codigoProductor: string;
  estado: string;
  estadoMateria: string;
  productos: Producto[]
}
