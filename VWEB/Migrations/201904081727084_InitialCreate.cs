namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Matricula = c.String(),
                        Observacao = c.String(),
                        Img = c.String(),
                        SenhaSei = c.String(),
                        Responsavel_Id = c.Int(),
                        Turma_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Responsavels", t => t.Responsavel_Id)
                .ForeignKey("dbo.Turmas", t => t.Turma_Id)
                .Index(t => t.Responsavel_Id)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "dbo.Responsavels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Senha = c.String(),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Endereco_Cep = c.String(),
                        Endereco_Rua = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_Estado = c.String(),
                        EndNumero = c.String(),
                        EndComplemento = c.String(),
                        Telefone = c.String(),
                        Telefone2 = c.String(),
                        Observacao = c.String(),
                        UltimoAcesso = c.String(),
                        PrimeiroAcesso = c.Boolean(nullable: false),
                        TipoResponsavel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turmas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        MaxAlunos = c.Int(nullable: false),
                        Seriado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seriadoes", t => t.Seriado_Id)
                .Index(t => t.Seriado_Id);
            
            CreateTable(
                "dbo.Seriadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turmas", "Seriado_Id", "dbo.Seriadoes");
            DropForeignKey("dbo.Alunoes", "Turma_Id", "dbo.Turmas");
            DropForeignKey("dbo.Alunoes", "Responsavel_Id", "dbo.Responsavels");
            DropIndex("dbo.Turmas", new[] { "Seriado_Id" });
            DropIndex("dbo.Alunoes", new[] { "Turma_Id" });
            DropIndex("dbo.Alunoes", new[] { "Responsavel_Id" });
            DropTable("dbo.Seriadoes");
            DropTable("dbo.Turmas");
            DropTable("dbo.Responsavels");
            DropTable("dbo.Alunoes");
        }
    }
}
