namespace VWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _050620191540 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Alunoes", name: "Turma_Id", newName: "TurmaId");
            RenameIndex(table: "dbo.Alunoes", name: "IX_Turma_Id", newName: "IX_TurmaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Alunoes", name: "IX_TurmaId", newName: "IX_Turma_Id");
            RenameColumn(table: "dbo.Alunoes", name: "TurmaId", newName: "Turma_Id");
        }
    }
}
