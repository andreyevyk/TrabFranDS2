using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public class Matricula
   {
      public int Id { get; set; }
      public int Ano { get; set; }
      public Aluno Aluno { get; set; }
      public Turma Turma { get; set; }
   }
}