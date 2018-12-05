namespace NativeApps2Service.Migrations
{
    using NativeApps2Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NativeApps2Service.Models.NativeApps2ServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NativeApps2Service.Models.NativeApps2ServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /*var ondernemers = new List<Ondernemer>
            {
                new Ondernemer{Naam="Ondernemer1Naam", Voornaam="Ondernemer1Voornaam", Gebruikersnaam="Ondernemer1", Wachtwoord="password", Email="Ondernemer1@gmail.com"},
                new Ondernemer{Naam="Ondernemer2Naam", Voornaam="Ondernemer2Voornaam", Gebruikersnaam="Ondernemer2", Wachtwoord="password", Email="Ondernemer2@gmail.com"},
                new Ondernemer{Naam="Ondernemer3Naam", Voornaam="Ondernemer3Voornaam", Gebruikersnaam="Ondernemer3", Wachtwoord="password", Email="Ondernemer3@gmail.com"},
                new Ondernemer{Naam="Ondernemer4Naam", Voornaam="Ondernemer4Voornaam", Gebruikersnaam="Ondernemer4", Wachtwoord="password", Email="Ondernemer4@gmail.com"},
                new Ondernemer{Naam="Ondernemer5Naam", Voornaam="Ondernemer5Voornaam", Gebruikersnaam="Ondernemer5", Wachtwoord="password", Email="Ondernemer5@gmail.com"},
                new Ondernemer{Naam="Ondernemer6Naam", Voornaam="Ondernemer6Voornaam", Gebruikersnaam="Ondernemer6", Wachtwoord="password", Email="Ondernemer6@gmail.com"},
                new Ondernemer{Naam="Ondernemer7Naam", Voornaam="Ondernemer7Voornaam", Gebruikersnaam="Ondernemer7", Wachtwoord="password", Email="Ondernemer7@gmail.com"}
            };
            ondernemers.ForEach(s => context.Ondernemers.AddOrUpdate(o => o.OndernemerID, s));
            context.SaveChanges();

            var ondernemingen = new List<Onderneming>
            {
                new Onderneming{Naam="Onderneming1", Categorie="Restaurant", Adres="Straat 1, 1234 Dorp", Openingsuren="9u-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer1Naam").OndernemerID},
                new Onderneming{Naam="Onderneming2", Categorie="Cafe", Adres="Straat 20, 9632 Dorp", Openingsuren="10u-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer2Naam").OndernemerID},
                new Onderneming{Naam="Onderneming3", Categorie="Bar", Adres="Straat 74, 7894 Dorp", Openingsuren="9u30-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer3Naam").OndernemerID},
                new Onderneming{Naam="Onderneming4", Categorie="Winkel", Adres="Straat 63, 5263 Dorp", Openingsuren="12u-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer4Naam").OndernemerID},
                new Onderneming{Naam="Onderneming5", Categorie="Bakkerij", Adres="Straat 15, 8521 Dorp", Openingsuren="7u-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer5Naam").OndernemerID},
                new Onderneming{Naam="Onderneming6", Categorie="Slagerij", Adres="Straat 14, 7412 Dorp", Openingsuren="8u-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer6Naam").OndernemerID},
                new Onderneming{Naam="Onderneming7", Categorie="Viswinkel", Adres="Straat 10, 3674 Dorp", Openingsuren="10u-20u", OndernemerID = ondernemers.Single(o => o.Naam == "Ondernemer7Naam").OndernemerID},
            };
            ondernemingen.ForEach(s => context.Ondernemings.AddOrUpdate(o => o.OndernemingID, s));
            context.SaveChanges();

            var evenementen = new List<Evenement>
            {
                new Evenement {Naam="Evenement1", Omschrijving="Evenement 1 gaat over.....", Begindatum=DateTime.Parse("01/01/2019"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Onderneming1" ).OndernemingID},
                new Evenement {Naam="Evenement2", Omschrijving="Evenement 2 gaat over.....", Begindatum=DateTime.Parse("01/10/2019"), Einddatum=DateTime.Parse("02/10/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Onderneming3" ).OndernemingID},
                new Evenement {Naam="Evenement3", Omschrijving="Evenement 3 gaat over.....", Begindatum=DateTime.Parse("01/03/2019"), Einddatum=DateTime.Parse("02/04/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Onderneming6" ).OndernemingID},
                new Evenement {Naam="Evenement4", Omschrijving="Evenement 4 gaat over.....", Begindatum=DateTime.Parse("20/01/2019"), Einddatum=DateTime.Parse("28/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Onderneming7" ).OndernemingID}
            };
            evenementen.ForEach(s => context.Evenements.AddOrUpdate(e => e.EvenementID, s));
            context.SaveChanges();


            var gebruiker = new IngelogdeGebruiker { Naam = "Gebruiker1Naam", Voornaam = "Gebruiker1VoorNaam", Gebruikersnaam = "Gebruiker1", Wachtwoord = "password", Email = "Gebruiker123@Hogent.be", VolgendeOndernemingen = ondernemingen.GetRange(2, 2) };
            context.IngelogdeGebruikers.Add(gebruiker);
            context.SaveChanges();

        */

        }
    }
}
