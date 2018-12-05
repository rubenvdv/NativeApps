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

            var ondernemers = new List<Ondernemer>
            {
                new Ondernemer{Naam="Brodin", Voornaam="Jesper", Gebruikersnaam="JesperBrodin", Wachtwoord="jesperbrodin", Email="jesper.brodin@ikea.com"},
                new Ondernemer{Naam="Colruyt", Voornaam="Jef", Gebruikersnaam="JefColruyt", Wachtwoord="jefcolruyt", Email="jef.colruyt@colruytgroup.be"},
                new Ondernemer{Naam="Claeyssens", Voornaam="Michel", Gebruikersnaam="MichelClaeyssens", Wachtwoord="michelclaeyssens", Email="michel.claeyssens@claeyssensoptiek.be"},
                new Ondernemer{Naam="Johnson", Voornaam="Kevin", Gebruikersnaam="KevinJohnson", Wachtwoord="kevinjohnson", Email="kevin.johnson@starbucks.com"},
                new Ondernemer{Naam="Vanherpe", Voornaam="Guido", Gebruikersnaam="GuidoVanherpe", Wachtwoord="guidovanherpe", Email="guido.vanherpe@lalorraine.be"},
                new Ondernemer{Naam="Hendricks", Voornaam="Jan", Gebruikersnaam="JanHendricks", Wachtwoord="janhendricks", Email="jan.hendricks@gmail.com"},
                //new Ondernemer{Naam="Ondernemer7Naam", Voornaam="Ondernemer7Voornaam", Gebruikersnaam="Ondernemer7", Wachtwoord="password", Email="Ondernemer7@gmail.com"}
            };
            ondernemers.ForEach(s => context.Ondernemers.AddOrUpdate(o => o.OndernemerID, s));
            context.SaveChanges();

            var ondernemingen = new List<Onderneming>
            {
                new Onderneming{Naam="Ikea Gent", Categorie="Meubilair", Adres="Maaltekouter 2, 9051 Gent", Openingsuren="MA-DO 10u-20u, VRIJ 10u-21u, ZAT 09u-20u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam == "JesperBrodin").OndernemerID},
                new Onderneming{Naam="OKay Gent", Categorie="warenhuis", Adres="Voskenslaan 228, 9000 Gent", Openingsuren="MA-ZAT 8u30-19u30", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam == "JefColruyt").OndernemerID},
                new Onderneming{Naam="Claeyssens optiek Gent", Categorie="Optiek", Adres="Voskenslaan 32, 9000 Gent", Openingsuren="DI-VRIJ 09u-18u, ZAT 09u-12u30 & 13u30-18u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam == "MichelClaeyssens").OndernemerID},
                new Onderneming{Naam="Colruyt Gent", Categorie="Grootwarenhuis", Adres="Drongensesteenweg 197, 9000 Gent", Openingsuren="MA-DO 08u30-20u, VRIJ 08u30-21u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam == "JefColruyt").OndernemerID},
                new Onderneming{Naam="Starbucks station Gent-Sint-Pieters", Categorie="Koffiehuis", Adres="Kon. Maria Hendrikaplein 1, 9000 Gent", Openingsuren="MA-VRIJ 05u30-21u30, ZAT 06u30-21u30, ZON 07u30-21u30", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam == "KevinJohnson").OndernemerID},
                new Onderneming{Naam="Starbucks Korenmarkt", Categorie="Koffiehuis", Adres="Korenmarkt 4, 9000 Gent", Openingsuren="MA-VRIJ 08u-19u, ZAT 08u-20u, ZON 10u-19u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam == "KevinJohnson").OndernemerID},
                new Onderneming{Naam="Panos Veldstraat", Categorie="Broodjeszaak", Adres="Veldstraat 96", Openingsuren="MA-VRIJ 05u30-20u, ZAT-ZON 06u30-20u", OndernemerID = ondernemers.Single(o => o.Naam == "GuidoVanherpe").OndernemerID},
                new Onderneming{Naam="Panos Station", Categorie="Broodjeszaak", Adres="Kon. Maria Hendrikaplein 1, 9000 Gent", Openingsuren="MA-VRIJ 05u30-20u, ZAT-ZON 06u30-20u", OndernemerID = ondernemers.Single(o => o.Naam == "GuidoVanherpe").OndernemerID},
                new Onderneming{Naam="Meme Gusta", Categorie="Restaurant", Adres="Burgstraat 19, 9000 Gent", Openingsuren="DI, DO-ZAT 12u-16u & 18u-22u, WOE 18u-22u", OndernemerID = ondernemers.Single(o => o.Naam == "JanHendricks").OndernemerID},

            };
            ondernemingen.ForEach(s => context.Ondernemings.AddOrUpdate(o => o.OndernemingID, s));
            context.SaveChanges();

            var evenementen = new List<Evenement>
            {
                new Evenement {Naam="Nieuwe folder Ikea België", Omschrijving="Lancering van de nieuwe folder voor Ikea België", Begindatum=DateTime.Parse("01/01/2019"), Einddatum=DateTime.Parse("01/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Ikea Gent" ).OndernemingID},
                new Evenement {Naam="Holiday Season", Omschrijving="Kom genieten van onze bereidingen speciaal voor de feestdagen! Tijdelijk beschikbaar", Begindatum=DateTime.Parse("01/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Starbucks station Gent-Sint-Pieters" ).OndernemingID},
                new Evenement {Naam="Holiday Season", Omschrijving="Kom genieten van onze bereidingen speciaal voor de feestdagen! Tijdelijk beschikbaar", Begindatum=DateTime.Parse("01/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Starbucks Korenmarkt" ).OndernemingID},
                //new Evenement {Naam="Evenement3", Omschrijving="Evenement 3 gaat over.....", Begindatum=DateTime.Parse("01/03/2019"), Einddatum=DateTime.Parse("02/04/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Onderneming6" ).OndernemingID},
            };
            evenementen.ForEach(s => context.Evenements.AddOrUpdate(e => e.EvenementID, s));
            context.SaveChanges();


            var gebruiker = new IngelogdeGebruiker { Naam = "Gebruiker1Naam", Voornaam = "Gebruiker1VoorNaam", Gebruikersnaam = "Gebruiker1", Wachtwoord = "password", Email = "Gebruiker123@Hogent.be", VolgendeOndernemingen = ondernemingen.GetRange(2, 2) };
            context.IngelogdeGebruikers.Add(gebruiker);
            context.SaveChanges();



        }
    }
}
