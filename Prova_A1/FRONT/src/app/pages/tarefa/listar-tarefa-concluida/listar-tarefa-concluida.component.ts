import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Tarefa } from "src/app/models/tarefa.model";

@Component({
  selector: "app-listar-tarefa-concluida",
  templateUrl: "./listar-tarefa-concluida.component.html",
  styleUrls: ["./listar-tarefa-concluida.component.css"],
})
export class ListarTarefaConcluidaComponent {
  tarefas: Tarefa[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Tarefa[]>("https://localhost:7015/api/tarefa/concluidas").subscribe({
      next: (tarefas) => {
        this.tarefas = tarefas;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
