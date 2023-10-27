import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarProdutoComponent } from './pages/produto/listar-produto/listar-produto.component';
import { CadastrarProdutoComponent } from './pages/produto/cadastrar-produto/cadastrar-produto.component';

const routes: Routes = [
  {
    path : "",
    component : ListarProdutoComponent
  },
  {
    path : "pages/produto/listar",
    component : ListarProdutoComponent
  },
  {
    path : "pages/produto/cadastrar",
    component : CadastrarProdutoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
