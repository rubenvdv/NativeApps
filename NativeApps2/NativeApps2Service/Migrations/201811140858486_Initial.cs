namespace NativeApps2Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        EvenementID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Omschrijving = c.String(),
                        Begindatum = c.DateTime(nullable: false),
                        Einddatum = c.DateTime(nullable: false),
                        OndernemingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvenementID)
                .ForeignKey("dbo.Ondernemings", t => t.OndernemingID, cascadeDelete: true)
                .Index(t => t.OndernemingID);
            
            CreateTable(
                "dbo.Ondernemings",
                c => new
                    {
                        OndernemingID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Categorie = c.String(),
                        Adres = c.String(),
                        Openingsuren = c.String(),
                        OndernemerID = c.Int(nullable: false),
                        IngelogdeGebruiker_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OndernemingID)
                .ForeignKey("dbo.Ondernemers", t => t.OndernemerID, cascadeDelete: true)
                .ForeignKey("dbo.IngelogdeGebruikers", t => t.IngelogdeGebruiker_Email)
                .Index(t => t.OndernemerID)
                .Index(t => t.IngelogdeGebruiker_Email);
            
            CreateTable(
                "dbo.Ondernemers",
                c => new
                    {
                        OndernemerID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Voornaam = c.String(),
                        Gebruikersnaam = c.String(),
                        Wachtwoord = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.OndernemerID);
            
            CreateTable(
                "dbo.IngelogdeGebruikers",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Naam = c.String(),
                        Voornaam = c.String(),
                        Gebruikersnaam = c.String(),
                        Wachtwoord = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ondernemings", "IngelogdeGebruiker_Email", "dbo.IngelogdeGebruikers");
            DropForeignKey("dbo.Ondernemings", "OndernemerID", "dbo.Ondernemers");
            DropForeignKey("dbo.Evenements", "OndernemingID", "dbo.Ondernemings");
            DropIndex("dbo.Ondernemings", new[] { "IngelogdeGebruiker_Email" });
            DropIndex("dbo.Ondernemings", new[] { "OndernemerID" });
            DropIndex("dbo.Evenements", new[] { "OndernemingID" });
            DropTable("dbo.IngelogdeGebruikers");
            DropTable("dbo.Ondernemers");
            DropTable("dbo.Ondernemings");
            DropTable("dbo.Evenements");
        }
    }
}
