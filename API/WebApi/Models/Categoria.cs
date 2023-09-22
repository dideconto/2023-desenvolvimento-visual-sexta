namespace WebApi.Models;

public class Categoria
{
    public Categoria() =>
        CriadoEm = DateTime.Now;

    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; }

}
