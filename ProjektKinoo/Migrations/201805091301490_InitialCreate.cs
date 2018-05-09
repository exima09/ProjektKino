namespace ProjektKinoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        IdFilmu = c.Int(nullable: false, identity: true),
                        Tytul = c.String(nullable: false),
                        Opis = c.String(nullable: false),
                        Cena = c.Double(nullable: false),
                        GodzinaSeansu = c.Int(nullable: false),
                        DlugoscSeansu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFilmu);
            
            CreateTable(
                "dbo.Uzytkownicies",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        Email = c.String(),
                        PasswordHash = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uzytkownicies");
            DropTable("dbo.Films");
        }
    }
}
