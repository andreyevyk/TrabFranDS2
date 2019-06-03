using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
    public class Aluno
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Matricula { get; set; }
        public string Observacao { get; set; }
        public string Img { get; set; }
        public int? ReponsavelId { get; set; }
        public virtual Responsavel Reponsavel { get; set; }

    }
}