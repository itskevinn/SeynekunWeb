import { Producto } from "../modelo-producto/producto";

export class MateriaPrima {
  fecha: Date;
  cantidad: number;
  codigo: string;
  codigoProductor: string;
  nombreProductor: string;
  estadoMateria: string;
  tipo: string;
  productos: Producto[]
}
