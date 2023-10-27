import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Categoria } from 'src/app/models/categoria.models';
import { Produto } from 'src/app/models/produto.models';

@Component({
  selector: 'app-cadastrar-produto',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})
export class CadastrarProdutoComponent {

  nome : string = "";
  descricao : string = "";
  preco : string = "";
  quantidade : string = "";
  categoriaId : number = 0;
  categorias : Categoria[] = [];

  constructor(private client: HttpClient,
    private router: Router){}

  ngOnInit() : void{
    this.client.get<Categoria[]>
      ("https://localhost:7083/api/categoria/listar")
      .subscribe({
        //A requição funcionou
        next : (categorias) => {
          console.table(categorias);
          this.categorias = categorias;
        },
        //A requição não funcionou
        error : (erro) => {
          console.log(erro);
        }
      });
  }

  cadastrar() : void {
    let produto : Produto ={
      nome : this.nome,
      descricao : this.descricao,
      preco : Number.parseFloat(this.preco) ,
      quantidade : Number.parseInt(this.quantidade),
      categoriaId : this.categoriaId
    };
    
    this.client.post<Produto>
      ("https://localhost:7083/api/produto/cadastrar", produto)
      .subscribe({
        //A requição funcionou
        next : (produto) => {
          this.router.navigate(['pages/produto/listar']);
        },
        //A requição não funcionou
        error : (erro) => {
          console.log(erro);
        }
      });

  }

}
