using OrientacaoObjetos.Models;

Console.Clear();
// Pessoa pessoa = new Pessoa();
// pessoa.setNome("Diogo");
// Console.WriteLine(pessoa.getNome());

Produto produto = new Produto();
produto.Nome = "Bolacha";
produto.Preco = 4.5;
Console.WriteLine(produto.Nome);
Console.WriteLine(produto);

Produto produto1 = new Produto
{
    Nome = "Arroz",
    Preco = 10,
    Validade = DateTime.Now
};

Console.WriteLine(produto1);

