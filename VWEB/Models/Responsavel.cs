using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public enum TipoResponsavel { Pai, Mãe, Avós, Outros };
   public class Responsavel
   {
      public int Id { get; set; }
      public string Email { get; set; }
      public string Senha { get; set; }
      public string Nome { get; set; }
      public string Sobrenome { get; set; }
      public Endereco Endereco { get; set; }
      public string EndNumero { get; set; }
      public string EndComplemento { get; set; }
      public string Telefone { get; set; }
      public string Telefone2 { get; set; }
      public string Observacao { get; set; }
      public string UltimoAcesso { get; set; }
      public bool PrimeiroAcesso { get; set; }
      public TipoResponsavel TipoResponsavel { get; set; }
      public ICollection<Aluno> Alunos { get; set; }

       
    public virtual ICollection<Mensagem> Mensagems { get; set; }
   }
}