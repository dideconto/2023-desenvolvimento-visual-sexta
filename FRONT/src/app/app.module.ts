import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListarProdutoComponent } from './pages/produto/listar-produto/listar-produto.component';

@NgModule({
  //Componentes da aplicação
  declarations: [
    AppComponent,
    ListarProdutoComponent
  ],
  //Bibliotecas externas da aplicação
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
