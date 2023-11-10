import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Categoria } from "src/app/models/categoria.models";
import { Produto } from "src/app/models/produto.models";

@Component({
  selector: "app-alterar-produto",
  templateUrl: "./alterar-produto.component.html",
  styleUrls: ["./alterar-produto.component.css"],
})
export class AlterarProdutoComponent {
  produtoId: number = 0;
  nome: string = "";
  descricao: string = "";
  preco: number | null = null;
  quantidade: number | null = null;
  categoriaId: number = 0;
  categorias: Categoria[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: (parametros) => {
        let { id } = parametros;
        this.client.get<Produto>(`https://localhost:7083/api/produto/buscar/${id}`).subscribe({
          next: (produto) => {
            this.client.get<Categoria[]>("https://localhost:7083/api/categoria/listar").subscribe({
              next: (categorias) => {
                this.categorias = categorias;

                this.produtoId = produto.produtoId!;
                this.nome = produto.nome;
                this.descricao = produto.descricao;
                this.quantidade = produto.quantidade;
                this.preco = produto.preco;
                this.categoriaId = produto.categoriaId;
              },
              error: (erro) => {
                console.log(erro);
              },
            });
          },
          //Requisição com erro
          error: (erro) => {
            console.log(erro);
          },
        });
      },
    });
  }

  alterar(): void {
    let produto: Produto = {
      nome: this.nome,
      descricao: this.descricao,
      preco: this.preco!,
      quantidade: this.quantidade!,
      categoriaId: this.categoriaId,
    };

    console.log(produto);

    this.client.put<Produto>(`https://localhost:7083/api/produto/alterar/${this.produtoId}`, produto).subscribe({
      //A requição funcionou
      next: (produto) => {
        this.snackBar.open("Produto alterado com sucesso!!", "E-commerce", {
          duration: 1500,
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        this.router.navigate(["pages/produto/listar"]);
      },
      //A requição não funcionou
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
