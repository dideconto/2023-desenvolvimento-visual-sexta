import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ListarTarefaComponent } from "./pages/tarefa/listar-tarefa/listar-tarefa.component";
import { ListarTarefaConcluidaComponent } from "./pages/tarefa/listar-tarefa-concluida/listar-tarefa-concluida.component";
import { ListarTarefaNaoConcluidaComponent } from "./pages/tarefa/listar-tarefa-nao-concluida/listar-tarefa-nao-concluida.component";
import { CadastrarTarefaComponent } from "./pages/tarefa/cadastrar-tarefa/cadastrar-tarefa.component";

const routes: Routes = [
  {
    path: "",
    component: ListarTarefaComponent,
  },
  {
    path: "pages/tarefa/listar",
    component: ListarTarefaComponent,
  },
  {
    path: "pages/tarefa/listarconcluidas",
    component: ListarTarefaConcluidaComponent,
  },
  {
    path: "pages/tarefa/listarnaoconcluidas",
    component: ListarTarefaNaoConcluidaComponent,
  },
  {
    path: "pages/tarefa/cadastrar",
    component: CadastrarTarefaComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
