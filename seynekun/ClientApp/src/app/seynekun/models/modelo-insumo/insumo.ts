import { Documento } from "../modelo-documento/documento"

export class Insumo {
  id: string
  idFabricante: string
  nombre: string
  uso: string
  registroIca: string
  descripcion: string
  resultado: string
  estado: string
  documento: Documento[];
}
