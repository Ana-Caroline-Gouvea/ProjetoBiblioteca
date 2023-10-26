using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Column("PessoaId")]
        [Display(Name = "Código da Pessoa")]
        public int PessoaId { get; set; }

        [Column("PessoaNome")]
        [Display(Name = "Nome da Pessoa")]
        public string PessoaNome { get; set; } = string.Empty;

        [Column("PessoaRM")]
        [Display(Name = "RM da Pessoa")]
        public int PessoaRM { get; set; }

    }
}
