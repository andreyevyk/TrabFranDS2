namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _030620190225 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turmas", "Seriado_Id", "dbo.Seriadoes");
            DropIndex("dbo.Turmas", new[] { "Seriado_Id" });
            AddColumn("dbo.Turmas", "Seriado", c => c.Int(nullable: false));
            DropColumn("dbo.Turmas", "Seriado_Id");
            DropTable("dbo.Seriadoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Seriadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Turmas", "Seriado_Id", c => c.Int());
            DropColumn("dbo.Turmas", "Seriado");
            CreateIndex("dbo.Turmas", "Seriado_Id");
            AddForeignKey("dbo.Turmas", "Seriado_Id", "dbo.Seriadoes", "Id");
        }
    }
}
