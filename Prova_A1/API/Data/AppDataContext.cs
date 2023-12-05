using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) :
     base(options)
    { }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaId = 1, Nome = "Trabalho", CriadoEm = DateTime.Now.AddDays(1) },
            new Categoria { CategoriaId = 2, Nome = "Estudos", CriadoEm = DateTime.Now.AddDays(2) },
            new Categoria { CategoriaId = 3, Nome = "Lazer", CriadoEm = DateTime.Now.AddDays(3) }
        );

        modelBuilder.Entity<Tarefa>().HasData(
            new Tarefa { TarefaId = 1, Status = "Não iniciada", Titulo = "Concluir relatório", Descricao = "Terminar relatório para reunião", CriadoEm = DateTime.Now.AddDays(7), CategoriaId = 1 },
            new Tarefa { TarefaId = 2, Status = "Em andamento", Titulo = "Estudar Angular", Descricao = "Preparar-se para a aula de Angular", CriadoEm = DateTime.Now.AddDays(3), CategoriaId = 2 },
            new Tarefa { TarefaId = 3, Status = "Concluída", Titulo = "Passeio no parque", Descricao = "Dar um passeio relaxante no parque", CriadoEm = DateTime.Now.AddDays(14), CategoriaId = 3 }
        );
    }
}
