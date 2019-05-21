using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public enum TipoMensagem { Público, Responsaveis, Individual }
   public class Mensagem
   {
      public int Id { get; set; }
      public string Titulo { get; set; }
      public string Texto { get; set; }
      public DateTime Data { get; set; }
      public TipoMensagem TipoMensagem { get; set; }

      public int? ResponsavelId { get; set;}
      public virtual Responsavel Responsavel { get; set; }
   }
}