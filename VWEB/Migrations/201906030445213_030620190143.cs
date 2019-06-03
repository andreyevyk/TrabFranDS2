namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _030620190143 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Alunoes", name: "Responsavel_Id", newName: "ReponsavelId");
            RenameIndex(table: "dbo.Alunoes", name: "IX_Responsavel_Id", newName: "IX_ReponsavelId");
            AddColumn("dbo.Responsavels", "Endereco", c => c.String());
            DropColumn("dbo.Alunoes", "SenhaSei");
            DropColumn("dbo.Responsavels", "Endereco_Cep");
            DropColumn("dbo.Responsavels", "Endereco_Rua");
            DropColumn("dbo.Responsavels", "Endereco_Bairro");
            DropColumn("dbo.Responsavels", "Endereco_Cidade");
            DropColumn("dbo.Responsavels", "Endereco_Estado");
            DropColumn("dbo.Responsavels", "Observacao");
            DropColumn("dbo.Responsavels", "UltimoAcesso");
            DropColumn("dbo.Responsavels", "PrimeiroAcesso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Responsavels", "PrimeiroAcesso", c => c.Boolean(nullable: false));
            AddColumn("dbo.Responsavels", "UltimoAcesso", c => c.String());
            AddColumn("dbo.Responsavels", "Observacao", c => c.String());
            AddColumn("dbo.Responsavels", "Endereco_Estado", c => c.String());
            AddColumn("dbo.Responsavels", "Endereco_Cidade", c => c.String());
            AddColumn("dbo.Responsavels", "Endereco_Bairro", c => c.String());
            AddColumn("dbo.Responsavels", "Endereco_Rua", c => c.String());
            AddColumn("dbo.Responsavels", "Endereco_Cep", c => c.String());
            AddColumn("dbo.Alunoes", "SenhaSei", c => c.String());
            DropColumn("dbo.Responsavels", "Endereco");
            RenameIndex(table: "dbo.Alunoes", name: "IX_ReponsavelId", newName: "IX_Responsavel_Id");
            RenameColumn(table: "dbo.Alunoes", name: "ReponsavelId", newName: "Responsavel_Id");
        }
    }
}
