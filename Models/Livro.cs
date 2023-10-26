using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Livro")]
    public class Livro
    {

        [Column("LivroId")]
        [Display(Name = "Código do Livro")]
        public int LivroId { get; set; }

        [Column("LivroNome")]
        [Display(Name = "Nome do Livro")]
        public string LivroNome { get; set; } = string.Empty;

        [Column("LivroAutor")]
        [Display(Name = "Autor do Livro")]
        public string LivroAutor { get; set; } = string.Empty;

        [ForeignKey("GeneroId")]
        public int GeneroId { get; set; }

        public Genero? Genero { get; set; }



    }
}
