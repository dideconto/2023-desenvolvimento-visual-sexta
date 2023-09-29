using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;
public class ProdutoDTO
{
    //DataAnnotations
    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }

    [Range(1, 1000)]
    public double Preco { get; set; }
    public int CategoriaId { get; set; }
}
