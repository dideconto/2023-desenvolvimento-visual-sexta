import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Endereco } from 'src/app/models/endereco.models';

@Component({
  selector: 'app-listar-produto',
  templateUrl: './listar-produto.component.html',
  styleUrls: ['./listar-produto.component.css']
})
export class ListarProdutoComponent {

  constructor(private client : HttpClient){ 

  }


  //Método que é executado ao abrir um componente
  ngOnInit() : void{
    this.client.get<Endereco>("https://viacep.com.br/ws/80020010/json/")
      .subscribe({
        //A requição funcionou
        next : (endereco) => {
          console.log(endereco.localidade, endereco.logradouro);
        },
        //A requição não funcionou
        error : (erro) => {
          console.log(erro);
        }
      });
  }

}
