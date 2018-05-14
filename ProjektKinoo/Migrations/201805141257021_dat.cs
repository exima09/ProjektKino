namespace ProjektKinoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filmies", "GodzinaSeansu", c => c.String());
            AlterColumn("dbo.Filmies", "DlugoscSeansu", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filmies", "DlugoscSeansu", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Filmies", "GodzinaSeansu", c => c.DateTime(nullable: false));
        }
    }
}
