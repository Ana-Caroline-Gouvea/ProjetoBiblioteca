using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Sugestao")]
    public class Sugestao
    {

        [Column("SugestaoId")]
        [Display(Name = "Código da Sugestão")]
        public int SugestaoId { get; set; }

        [ForeignKey("PessoaId")]
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }

        [Column("DescSugestao")]
        [Display(Name = "Descrição da Sugestão")]
        public string DescSugestao { get; set; } = string.Empty;
    }
}
