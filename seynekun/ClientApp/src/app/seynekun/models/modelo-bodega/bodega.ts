import { AjusteDeInventario } from "../modelo-ajuste-inventario/ajuste-de-inventario";

export class Bodega {
    nombre: string;
    detalle: string;        
    ajustes: AjusteDeInventario[];
    estado: string;
    direccion: string;
}
