using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public class Postagem
   {
      public int Id { get; set; }
      public string Titulo { get; set; }
      public string Codigo { get; set; }
      public string Descricao { get; set; }
      public string Texto { get; set; }
      public string Imagem { get; set; }
      public DateTime Data { get; set; }
      public Usuario UsuarioResponsavel { get; set; }
   }
}