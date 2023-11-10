import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Produto } from "src/app/models/produto.models";

@Component({
  selector: "app-listar-produto",
  templateUrl: "./listar-produto.component.html",
  styleUrls: ["./listar-produto.component.css"],
})
export class ListarProdutoComponent {
  colunasTabela: string[] = [
    "id",
    "nome",
    "descricao",
    "quantidade",
    "preco",
    "categoria",
    "criadoEm",
    "deletar",
    "alterar",
  ];

  produtos: Produto[] = [];

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  //Método que é executado ao abrir um componente
  ngOnInit(): void {
    this.client
      .get<Produto[]>("https://localhost:7083/api/produto/listar")
      .subscribe({
        //A requição funcionou
        next: (produtos) => {
          this.produtos = produtos;
        },
        //A requição não funcionou
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(produtoId: number) {
    this.client
      .delete<Produto[]>(
        `https://localhost:7083/api/produto/deletar/${produtoId}`
      )
      .subscribe({
        //Requisição com sucesso
        next: (produtos) => {
          this.produtos = produtos;
          this.snackBar.open("Produto deletado com sucesso!!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
        },
        //Requisição com erro
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}
