import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Tarefa } from "src/app/models/tarefa.model";

@Component({
  selector: "app-listar-tarefa",
  templateUrl: "./listar-tarefa.component.html",
  styleUrls: ["./listar-tarefa.component.css"],
})
export class ListarTarefaComponent {
  tarefas: Tarefa[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Tarefa[]>("https://localhost:7015/api/tarefa/listar").subscribe({
      next: (tarefas) => {
        this.tarefas = tarefas;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }

  alterar(id: number): void {
    this.http.patch<Tarefa[]>("https://localhost:7015/api/tarefa/alterar/" + id, null).subscribe({
      next: (tarefas) => {
        this.ngOnInit();
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
