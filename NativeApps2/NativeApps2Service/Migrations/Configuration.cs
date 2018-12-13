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
                new Onderneming{Naam="Ikea Gent", Categorie="Meubilair", Adres="Maaltekouter 2, 9051 Gent", Openingsuren="MA-DO 10u-20u, VRIJ 10u-21u, ZAT 09u-20u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JesperBrodin")).OndernemerID},
                new Onderneming{Naam="OKay Gent", Categorie="warenhuis", Adres="Voskenslaan 228, 9000 Gent", Openingsuren="MA-ZAT 8u30-19u30", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JefColruyt")).OndernemerID},
                new Onderneming{Naam="Claeyssens optiek Gent", Categorie="Optiek", Adres="Voskenslaan 32, 9000 Gent", Openingsuren="DI-VRIJ 09u-18u, ZAT 09u-12u30 & 13u30-18u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("MichelClaeyssens")).OndernemerID},
                new Onderneming{Naam="Colruyt Gent", Categorie="Grootwarenhuis", Adres="Drongensesteenweg 197, 9000 Gent", Openingsuren="MA-DO 08u30-20u, VRIJ 08u30-21u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JefColruyt")).OndernemerID},
                new Onderneming{Naam="Starbucks station Gent-Sint-Pieters", Categorie="Koffiehuis", Adres="Kon. Maria Hendrikaplein 1, 9000 Gent", Openingsuren="MA-VRIJ 05u30-21u30, ZAT 06u30-21u30, ZON 07u30-21u30", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("KevinJohnson")).OndernemerID},
                new Onderneming{Naam="Starbucks Korenmarkt", Categorie="Koffiehuis", Adres="Korenmarkt 4, 9000 Gent", Openingsuren="MA-VRIJ 08u-19u, ZAT 08u-20u, ZON 10u-19u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("KevinJohnson")).OndernemerID},
              // new Onderneming{Naam="Panos Veldstraat", Categorie="Broodjeszaak", Adres="Veldstraat 96", Openingsuren="MA-VRIJ 05u30-20u, ZAT-ZON 06u30-20u", OndernemerID = ondernemers.Single(o => o.Naam.Equals("GuidoVanherpe")).OndernemerID},
                //new Onderneming{Naam="Panos Station", Categorie="Broodjeszaak", Adres="Kon. Maria Hendrikaplein 1, 9000 Gent", Openingsuren="MA-VRIJ 05u30-20u, ZAT-ZON 06u30-20u", OndernemerID = ondernemers.Single(o => o.Naam.Equals("GuidoVanherpe")).OndernemerID},
                // new Onderneming{Naam="Meme Gusta", Categorie="Restaurant", Adres="Burgstraat 19, 9000 Gent", Openingsuren="DI, DO-ZAT 12u-16u & 18u-22u, WOE 18u-22u", OndernemerID = ondernemers.Single(o => o.Naam.Equals("janhendricks")).OndernemerID},
                
            };
            ondernemingen.ForEach(s => context.Ondernemings.AddOrUpdate(o => o.OndernemingID, s));
            context.SaveChanges();

            var evenementen = new List<Evenement>
            {
                new Evenement {Naam="Nieuwe folder Ikea België", Omschrijving="Lancering van de nieuwe folder voor Ikea België", Begindatum=DateTime.Parse("01/01/2019"), Einddatum=DateTime.Parse("01/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Ikea Gent") ).OndernemingID},
                new Evenement {Naam="Holiday Season", Omschrijving="Kom genieten van onze bereidingen speciaal voor de feestdagen! Tijdelijk beschikbaar", Begindatum=DateTime.Parse("01/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Starbucks station Gent-Sint-Pieters") ).OndernemingID},
                new Evenement {Naam="Holiday Season", Omschrijving="Kom genieten van onze bereidingen speciaal voor de feestdagen! Tijdelijk beschikbaar", Begindatum=DateTime.Parse("01/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Starbucks Korenmarkt") ).OndernemingID},
                //new Evenement {Naam="Evenement3", Omschrijving="Evenement 3 gaat over.....", Begindatum=DateTime.Parse("01/03/2019"), Einddatum=DateTime.Parse("02/04/2019"), OndernemingID= ondernemingen.Single(o => o.Naam == "Onderneming6" ).OndernemingID},
            };
            evenementen.ForEach(s => context.Evenements.AddOrUpdate(e => e.EvenementID, s));
            context.SaveChanges();

            var promoties = new List<Promotie>
            {
                new Promotie {Naam="Eindejaarspromo", Omschrijving="5% korting bij alle aankopen boven de 100 euro", Begindatum=DateTime.Parse("06/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Ikea Gent") ).OndernemingID, Korting="5%"},
               // new Promotie {Naam="Date time", Omschrijving="Krijg 1 gratis fles wijn bij een diner voor 2 op kerstavond", Begindatum=DateTime.Parse("24/12/2018"), Einddatum=DateTime.Parse("24/12/2018"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Meme Gusta") ).OndernemingID, Korting="1 gratis fles wijn, geldig bij een kerstdiner voor 2"},
               // new Promotie {Naam="Promotie3", Omschrijving="Promotie 3 gaat over.....", Begindatum=DateTime.Parse("01/03/2019"), Einddatum=DateTime.Parse("02/04/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Onderneming5") ).OndernemingID, Korting="20% op alle artikelen"},
                //new Promotie {Naam="Promotie4", Omschrijving="Promotie 4 gaat over.....", Begindatum=DateTime.Parse("20/01/2019"), Einddatum=DateTime.Parse("28/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Onderneming6") ).OndernemingID, Korting="1 euro korting bij een glimlach aan de kassa!"}
            };
            promoties.ForEach(s => context.Promoties.AddOrUpdate(p => p.PromotieID, s));
            context.SaveChanges();

            var gebruikers = new List<IngelogdeGebruiker>
            {
                new IngelogdeGebruiker { Naam = "Van De Velde", Voornaam = "Ruben", Gebruikersnaam = "rubenvdv", Wachtwoord = "rubenvdv", Email = "rubenvdv26@live.com" , VolgendeOndernemingen = ondernemingen.GetRange(2, 2)},
                new IngelogdeGebruiker { Naam = "Roelants", Voornaam = "Jeroen", Gebruikersnaam = "jeroenroelants", Wachtwoord = "jeroenroelants", Email = "rubenvdv26@live.com", VolgendeOndernemingen = ondernemingen.GetRange(0, 2) },
                new IngelogdeGebruiker { Naam = "Janssens", Voornaam = "Bavo", Gebruikersnaam = "bavojanssens", Wachtwoord = "bavojanssens", Email = "rubenvdv26@live.com", VolgendeOndernemingen = ondernemingen.GetRange(0, ondernemingen.Count()) }
            };

            gebruikers.ForEach(g => context.IngelogdeGebruikers.AddOrUpdate(ig => ig.Email, g));
            context.SaveChanges();
        }
    }
}
