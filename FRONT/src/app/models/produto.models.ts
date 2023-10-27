import { Categoria } from "./categoria.models";

export interface Produto{
    produtoId? : number;
    nome : string;
    descricao : string;
    criadoEm? : string;
    preco : number;
    quantidade : number;
    categoriaId : number;
    categoria ?: Categoria;
}