namespace ProjektKinoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjektKinoo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Films", newName: "Filmies");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Filmies", newName: "Films");
        }
    }
}
