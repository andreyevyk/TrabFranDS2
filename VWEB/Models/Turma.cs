using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
    public enum Seriado { Berçario, G1, G2, G3, G4, G5 }
   public class Turma
   {
      public int Id { get; set; }
      public string Nome { get; set; }
      public int MaxAlunos { get; set; }
      public Seriado Seriado { get; set; }
      public ICollection<Aluno> Alunos { get; set; }
   }
}