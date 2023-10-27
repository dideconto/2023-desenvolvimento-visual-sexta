import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Produto } from 'src/app/models/produto.models';

@Component({
  selector: 'app-listar-produto',
  templateUrl: './listar-produto.component.html',
  styleUrls: ['./listar-produto.component.css']
})
export class ListarProdutoComponent {

  produtos : Produto[] = [];

  constructor(private client : HttpClient){ }

  //Método que é executado ao abrir um componente
  ngOnInit() : void{
    this.client.get<Produto[]>
      ("https://localhost:7083/api/produto/listar")
      .subscribe({
        //A requição funcionou
        next : (produtos) => {
          this.produtos = produtos;
        },
        //A requição não funcionou
        error : (erro) => {
          console.log(erro);
        }
      });
  }

}
