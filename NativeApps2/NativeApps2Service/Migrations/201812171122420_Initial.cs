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
                    })
                .PrimaryKey(t => t.OndernemingID)
                .ForeignKey("dbo.Ondernemers", t => t.OndernemerID, cascadeDelete: true)
                .Index(t => t.OndernemerID);
            
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
                        IngelogdeGebruikerID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Voornaam = c.String(),
                        Gebruikersnaam = c.String(),
                        Wachtwoord = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IngelogdeGebruikerID);
            
            CreateTable(
                "dbo.Promoties",
                c => new
                    {
                        PromotieID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Omschrijving = c.String(),
                        Begindatum = c.DateTime(nullable: false),
                        Einddatum = c.DateTime(nullable: false),
                        OndernemingID = c.Int(nullable: false),
                        Korting = c.String(),
                    })
                .PrimaryKey(t => t.PromotieID)
                .ForeignKey("dbo.Ondernemings", t => t.OndernemingID, cascadeDelete: true)
                .Index(t => t.OndernemingID);
            
            CreateTable(
                "dbo.IngelogdeGebruikerOndernemings",
                c => new
                    {
                        IngelogdeGebruikersId = c.Int(nullable: false),
                        OndernemingsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IngelogdeGebruikersId, t.OndernemingsId });
            
            CreateTable(
                "dbo.IngelogdeGebruikerOndernemings1",
                c => new
                    {
                        IngelogdeGebruiker_IngelogdeGebruikerID = c.Int(nullable: false),
                        Onderneming_OndernemingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IngelogdeGebruiker_IngelogdeGebruikerID, t.Onderneming_OndernemingID })
                .ForeignKey("dbo.IngelogdeGebruikers", t => t.IngelogdeGebruiker_IngelogdeGebruikerID, cascadeDelete: true)
                .ForeignKey("dbo.Ondernemings", t => t.Onderneming_OndernemingID, cascadeDelete: true)
                .Index(t => t.IngelogdeGebruiker_IngelogdeGebruikerID)
                .Index(t => t.Onderneming_OndernemingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promoties", "OndernemingID", "dbo.Ondernemings");
            DropForeignKey("dbo.IngelogdeGebruikerOndernemings1", "Onderneming_OndernemingID", "dbo.Ondernemings");
            DropForeignKey("dbo.IngelogdeGebruikerOndernemings1", "IngelogdeGebruiker_IngelogdeGebruikerID", "dbo.IngelogdeGebruikers");
            DropForeignKey("dbo.Ondernemings", "OndernemerID", "dbo.Ondernemers");
            DropForeignKey("dbo.Evenements", "OndernemingID", "dbo.Ondernemings");
            DropIndex("dbo.IngelogdeGebruikerOndernemings1", new[] { "Onderneming_OndernemingID" });
            DropIndex("dbo.IngelogdeGebruikerOndernemings1", new[] { "IngelogdeGebruiker_IngelogdeGebruikerID" });
            DropIndex("dbo.Promoties", new[] { "OndernemingID" });
            DropIndex("dbo.Ondernemings", new[] { "OndernemerID" });
            DropIndex("dbo.Evenements", new[] { "OndernemingID" });
            DropTable("dbo.IngelogdeGebruikerOndernemings1");
            DropTable("dbo.IngelogdeGebruikerOndernemings");
            DropTable("dbo.Promoties");
            DropTable("dbo.IngelogdeGebruikers");
            DropTable("dbo.Ondernemers");
            DropTable("dbo.Ondernemings");
            DropTable("dbo.Evenements");
        }
    }
}
