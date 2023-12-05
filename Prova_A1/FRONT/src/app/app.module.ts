import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ListarTarefaComponent } from "./pages/tarefa/listar-tarefa/listar-tarefa.component";
import { ListarTarefaNaoConcluidaComponent } from "./pages/tarefa/listar-tarefa-nao-concluida/listar-tarefa-nao-concluida.component";
import { ListarTarefaConcluidaComponent } from "./pages/tarefa/listar-tarefa-concluida/listar-tarefa-concluida.component";
import { CadastrarTarefaComponent } from "./pages/tarefa/cadastrar-tarefa/cadastrar-tarefa.component";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    ListarTarefaComponent,
    ListarTarefaNaoConcluidaComponent,
    ListarTarefaConcluidaComponent,
    CadastrarTarefaComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
