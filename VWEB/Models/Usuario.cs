using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
   public class Usuario
   {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

      public virtual ICollection<Postagem> Postagems { get; set; }
   }
}