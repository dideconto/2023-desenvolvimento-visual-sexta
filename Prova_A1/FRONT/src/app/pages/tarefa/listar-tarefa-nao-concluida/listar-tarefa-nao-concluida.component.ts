import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Tarefa } from "src/app/models/tarefa.model";

@Component({
  selector: "app-listar-tarefa-nao-concluida",
  templateUrl: "./listar-tarefa-nao-concluida.component.html",
  styleUrls: ["./listar-tarefa-nao-concluida.component.css"],
})
export class ListarTarefaNaoConcluidaComponent {
  tarefas: Tarefa[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Tarefa[]>("https://localhost:7015/api/tarefa/naoconcluidas").subscribe({
      next: (tarefas) => {
        this.tarefas = tarefas;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
