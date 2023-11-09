using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Reclamacao")]
    public class Reclamacao
    {
        [Column("ReclamacaoId")]
        [Display(Name = "Código da Reclamação")]
        public int ReclamacaoId { get; set; }

        [ForeignKey("PessoaId")]
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }

        [Column("DescReclamacao")]
        [Display(Name = "Descrição da Reclamação")]
        public string DescReclamacao { get; set; } = string.Empty;

        [Column("LivroImagem")]
        [Display(Name = "Imagem do Livro")]
        public byte[]? LivroImagem { get; set; }

        [NotMapped]
        public string ImgExibicao { get; set; } = string.Empty;

        [NotMapped]
        public byte[]? LivroImagem2 { get; set; }

    }
}
