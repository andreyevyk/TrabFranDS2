using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public enum TipoResponsavel { Pai, Mãe, Avós, Outros };
   public class Responsavel
   {
      public int Id { get; set; }
      public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      public string Senha { get; set; }
      public string Nome { get; set; }
      public string Sobrenome { get; set; }
      public string Endereco { get; set; }

      [Display(Name = "Numero")]
      public string EndNumero { get; set; }
      [Display(Name = "Complemento")]
      public string EndComplemento { get; set; }

      public string Telefone { get; set; }
      [Display(Name = "Telefone 2(Opcional)")]
      public string Telefone2 { get; set; }
      public TipoResponsavel TipoResponsavel { get; set; }

      public ICollection<Aluno> Alunos { get; set; }
      public virtual ICollection<Mensagem> Mensagems { get; set; }
   }
}