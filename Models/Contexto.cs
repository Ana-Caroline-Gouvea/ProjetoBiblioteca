using Microsoft.EntityFrameworkCore;

namespace ProjetoBiblioteca.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Devolucao> Devolução { get; set; }

        public DbSet<Emprestimo> Empréstimo { get; set; }

        public DbSet<Genero> Genêro { get; set; }

        public DbSet<Livro> Livro { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Reclamacao> Reclamação { get; set; }

        public DbSet<Sugestao> Sugestão { get; set; }

    }
}
