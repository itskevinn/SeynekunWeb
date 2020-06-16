import { FichaTecnica } from "../modelo-ficha-tecnica/ficha-tecnica"

export class Insumo {
  id: string
  idFabricante: string
  nombre: string
  uso: string
  registroIca: string
  descripcion: string
  resultado: string
  estado: string
  fichaTecnica: FichaTecnica
}
