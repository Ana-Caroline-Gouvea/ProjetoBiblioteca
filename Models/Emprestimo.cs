using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Emprestimo")]
    public class Emprestimo
    {
        [Column("EmprestimoId")]
        [Display(Name = "Código do Empréstimo")]
        public int EmprestimoId { get; set; }

        [ForeignKey("PessoaId")]
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }

        [ForeignKey("LivroId")]
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }

        [Column("DataEmprestimo")]
        [Display(Name = "Data do Empréstimo")]
        public DateTime DataEmprestimo { get; set; }

        [Column("DevolucaoPrevista")]
        [Display(Name = "Data Prevista da Devolução")]
        public DateTime DevolucaoPrevista { get; set; }

        [Column("Devolvido")]
        [Display(Name = "Data da Devolução")]
        public bool Devolvido { get; set; }

        [NotMapped]
        public string DescricaoEmprestimo { get; set; } = string.Empty;
    }
}
