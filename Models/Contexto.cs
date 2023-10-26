using Microsoft.EntityFrameworkCore;

namespace ProjetoBiblioteca.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
