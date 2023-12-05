import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Categoria } from "src/app/models/categoria.model";
import { Tarefa } from "src/app/models/tarefa.model";

@Component({
  selector: "app-cadastrar-tarefa",
  templateUrl: "./cadastrar-tarefa.component.html",
  styleUrls: ["./cadastrar-tarefa.component.css"],
})
export class CadastrarTarefaComponent {
  constructor(private http: HttpClient, private router: Router) {}

  titulo: string = "";
  descricao: string = "";
  categorias: Categoria[] = [];
  categoriaId: number = 0;

  ngOnInit(): void {
    this.http.get<Categoria[]>("https://localhost:7015/api/categoria/listar").subscribe({
      next: (categorias) => {
        this.categorias = categorias;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }

  cadastrar(): void {
    let tarefa: Tarefa = {
      titulo: this.titulo,
      descricao: this.descricao,
      categoriaId: this.categoriaId,
    };

    this.http.post<Tarefa>("https://localhost:7015/api/tarefa/cadastrar", tarefa).subscribe({
      next: (tarefas) => {
        this.router.navigate(["/pages/tarefa/listar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
