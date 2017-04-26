namespace TABprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mecze : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sedzia", name: "Mecze_id", newName: "mecz_id");
            RenameIndex(table: "dbo.Sedzia", name: "IX_Mecze_id", newName: "IX_mecz_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Sedzia", name: "IX_mecz_id", newName: "IX_Mecze_id");
            RenameColumn(table: "dbo.Sedzia", name: "mecz_id", newName: "Mecze_id");
        }
    }
}
