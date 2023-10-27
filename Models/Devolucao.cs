using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Devolucao")]
    public class Devolucao
    {
        [Column("DevolucaoId")]
        [Display(Name = "Código da Devolução")]
        public int DevolucaoId { get; set; }

        [ForeignKey("EmprestimoId")]
        public int EmprestimoId { get; set; }
        public Emprestimo? Emprestimo { get; set; }

        [Column("DataDevolucao")]
        [Display(Name = "Data da Devolução")]
        public DateTime DataDevolucao { get; set; }
               
    }
 }
