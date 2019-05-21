using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public class MensagemView
   {
      public int Id { get; set; }
      public DateTime Data { get; set; }
      public Mensagem Mensagem { get; set; }
      public Responsavel Responsavel { get; set; }
   }
}