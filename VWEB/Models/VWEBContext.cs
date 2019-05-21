using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VWEB.Models
{
    public class VWEBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VWEBContext() : base("name=VWEBContext")
        {
        }

      public System.Data.Entity.DbSet<VWEB.Models.Aluno> Alunos { get; set; }

      public System.Data.Entity.DbSet<VWEB.Models.Responsavel> Responsavels { get; set; }

      public System.Data.Entity.DbSet<VWEB.Models.Turma> Turmas { get; set; }

        public System.Data.Entity.DbSet<VWEB.Models.Usuario> Usuarios { get; set; }
    }
}
