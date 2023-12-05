import { Categoria } from "./categoria.model";

export interface Tarefa {
  tarefaId?: number;
  titulo: string;
  descricao: string;
  criadoEm?: string;
  status?: string;
  categoria?: Categoria;
  categoriaId: number;
}
