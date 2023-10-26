using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Genero")]
    public class Genero
    {

        [Column("GeneroId")]
        [Display(Name = "Código do Genêro")]
        public int GeneroId { get; set; }

        [Column("GeneroNome")]
        [Display(Name = "Nome do Genêro")]
        public string GeneroNome { get; set; } = string.Empty;

    }
}
