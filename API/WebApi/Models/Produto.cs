namespace WebApi.Models;
public class Produto
{
    public Produto() =>
        CriadoEm = DateTime.Now;

    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }
}
