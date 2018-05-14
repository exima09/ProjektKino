namespace ProjektKinoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filmies", "GodzinaSeansu", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Filmies", "DlugoscSeansu", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filmies", "DlugoscSeansu", c => c.Int(nullable: false));
            AlterColumn("dbo.Filmies", "GodzinaSeansu", c => c.Int(nullable: false));
        }
    }
}
