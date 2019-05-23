namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoControllerDePostagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Postagems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        Texto = c.String(),
                        Imagem = c.String(),
                        Data = c.DateTime(nullable: false),
                        UsuarioResponsavel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioResponsavel_Id)
                .Index(t => t.UsuarioResponsavel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postagems", "UsuarioResponsavel_Id", "dbo.Usuarios");
            DropIndex("dbo.Postagems", new[] { "UsuarioResponsavel_Id" });
            DropTable("dbo.Postagems");
        }
    }
}
