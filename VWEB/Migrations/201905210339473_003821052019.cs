namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003821052019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagems", "ResponsavelId", c => c.Int());
            CreateIndex("dbo.Mensagems", "ResponsavelId");
            AddForeignKey("dbo.Mensagems", "ResponsavelId", "dbo.Responsavels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagems", "ResponsavelId", "dbo.Responsavels");
            DropIndex("dbo.Mensagems", new[] { "ResponsavelId" });
            DropColumn("dbo.Mensagems", "ResponsavelId");
        }
    }
}
