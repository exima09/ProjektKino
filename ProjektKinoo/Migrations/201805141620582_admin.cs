namespace ProjektKinoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uzytkownicies", "Admin", c => c.Int(nullable: false));
            AlterColumn("dbo.Uzytkownicies", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uzytkownicies", "Email", c => c.String());
            DropColumn("dbo.Uzytkownicies", "Admin");
        }
    }
}
