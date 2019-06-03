namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _030620190234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Responsavels", "Senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Responsavels", "Senha", c => c.String());
        }
    }
}
