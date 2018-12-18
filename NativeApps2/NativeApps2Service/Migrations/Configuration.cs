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
                new Ondernemer{Naam="Brodin", Voornaam="Jesper", Gebruikersnaam="JesperBrodin", Wachtwoord="xrZtucYEqto/LkWjIaMp/x+HE9TaXelikq9ktmEs//rAekcCM+3mVBgvdpHX0Hw2BlImKBtSTK81kkpjyNmuuQ==", Email="jesper.brodin@ikea.com"}, //password jesperbrodin
                new Ondernemer{Naam="Colruyt", Voornaam="Jef", Gebruikersnaam="JefColruyt", Wachtwoord="JfmYF8LeV2m82a5+iQ6nUmr/knriZHiye3v70cKqxOdl34tzvRjmwUucyShTWzNICr8EFbwROky06qF2jCJYkA==", Email="jef.colruyt@colruytgroup.be"}, //password jefcolruyt
                new Ondernemer{Naam="Claeyssens", Voornaam="Michel", Gebruikersnaam="MichelClaeyssens", Wachtwoord="TYJ3vBXh/KkjSCfq57cfCQFiqOnu9hoE1+DQcUMv63XZG7f3odp2pbifFG8UVeRDPpVf1dovCGH3x0N7ny5GAw==", Email="michel.claeyssens@claeyssensoptiek.be"}, //password michelclaeyssens
                new Ondernemer{Naam="Johnson", Voornaam="Kevin", Gebruikersnaam="KevinJohnson", Wachtwoord="Wa51CZ/X1Cv+lRY5qfvPYi4Wg90h/OG59Ilg1rbK2NnqZamO/lS6Yd0XI/+okstkQpyxj2eYaKHNYyEWK6aUTQ==", Email="kevin.johnson@starbucks.com"}, //password kevinjohnson
                new Ondernemer{Naam="Vanherpe", Voornaam="Guido", Gebruikersnaam="GuidoVanherpe", Wachtwoord="JB9RxKEWcFKXb46zhEyu50UgPMcBBjDHSGPhXa/z2Hfiu3t7JJGeh5qwU3d2dn85r3nJxxYNrgF/OWh+/Ly9pw==", Email="guido.vanherpe@lalorraine.be"}, //password guidovanherpe
                new Ondernemer{Naam="Hendricks", Voornaam="Jan", Gebruikersnaam="JanHendricks", Wachtwoord="VbdISEUzCZC6XEcVF40I89CfjVjO3Ad3wcinciFGTBWHdiHoxQfAEK5i5jdOz5cvVUB3HzwS9gLfXUhcsFKlkA==", Email="jan.hendricks@gmail.com"}, //password janhendricks
                new Ondernemer{Naam="Peeters", Voornaam="Peter", Gebruikersnaam="PeterPeeters", Wachtwoord="vndIBoy7ryxZW9Qg9pt8H8wh/RF875CDVyPY5RtQ2jFLbS9Os6sHl4jMQzJeE5dQdXHt5sZFysG2yPXIpeTspg==", Email="peter.peeters@gmail.com"}, //password=peterpeeters
                new Ondernemer{Naam="Van De Velde", Voornaam="Jonas", Gebruikersnaam="JonasVdv", Wachtwoord="kbr7DbwlKxcccGlwqbtRFw7quDLIt32YQXeoKyi0LypENmwTxyno6ElhtlGBD1uPWU7u5KSywRQkQvB6EIFIeQ==", Email="jonas.vandevelde@gmail.com" } //password=jonasvdv
            };
            ondernemers.ForEach(s => context.Ondernemers.AddOrUpdate(o => o.OndernemerID, s));
            context.SaveChanges();

            var ondernemingen = new List<Onderneming>
            {
                new Onderneming{Naam="Ikea Gent", Categorie="Meubelwinkel", Adres="Maaltekouter 2, 9051 Gent", Openingsuren="MA-DO 10u-20u, VRIJ 10u-21u, ZAT 09u-20u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JesperBrodin")).OndernemerID},
                new Onderneming{Naam="OKay Gent", Categorie="Grootwarenhuis", Adres="Voskenslaan 228, 9000 Gent", Openingsuren="MA-ZAT 8u30-19u30", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JefColruyt")).OndernemerID},
                new Onderneming{Naam="Claeyssens optiek Gent", Categorie="Optieker", Adres="Voskenslaan 32, 9000 Gent", Openingsuren="DI-VRIJ 09u-18u, ZAT 09u-12u30 & 13u30-18u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("MichelClaeyssens")).OndernemerID},
                new Onderneming{Naam="Colruyt Gent", Categorie="Grootwarenhuis", Adres="Drongensesteenweg 197, 9000 Gent", Openingsuren="MA-DO 08u30-20u, VRIJ 08u30-21u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JefColruyt")).OndernemerID},
                new Onderneming{Naam="Starbucks station Gent-Sint-Pieters", Categorie="Koffiehuis", Adres="Kon. Maria Hendrikaplein 1, 9000 Gent", Openingsuren="MA-VRIJ 05u30-21u30, ZAT 06u30-21u30, ZON 07u30-21u30", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("KevinJohnson")).OndernemerID},
                new Onderneming{Naam="Starbucks Korenmarkt", Categorie="Koffiehuis", Adres="Korenmarkt 4, 9000 Gent", Openingsuren="MA-VRIJ 08u-19u, ZAT 08u-20u, ZON 10u-19u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("KevinJohnson")).OndernemerID},
                new Onderneming{Naam="Panos Veldstraat", Categorie="Broodjeszaak", Adres="Veldstraat 96, 9000 Gent", Openingsuren="MA-VRIJ 05u30-20u, ZAT-ZON 06u30-20u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("GuidoVanherpe")).OndernemerID},
                new Onderneming{Naam="Panos Station", Categorie="Broodjeszaak", Adres="Kon. Maria Hendrikaplein 1, 9000 Gent", Openingsuren="MA-VRIJ 05u30-20u, ZAT-ZON 06u30-20u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("GuidoVanherpe")).OndernemerID},
                new Onderneming{Naam="Meme Gusta", Categorie="Restaurant", Adres="Burgstraat 19, 9000 Gent", Openingsuren="DI, DO-ZAT 12u-16u & 18u-22u, WOE 18u-22u", OndernemerID = ondernemers.Single(o => o.Gebruikersnaam.Equals("JanHendricks")).OndernemerID},

                new Onderneming{Naam="Sport utilities", Categorie="Sportwinkel", Adres="Vlasmarkt 6, 9000 Gent", Openingsuren="MA-VRIJ 10u-18u30", OndernemerID= ondernemers.Single(o => o.Gebruikersnaam.Equals("PeterPeeters")).OndernemerID},
                new Onderneming{Naam="Cuba Gent", Categorie="Discotheek", Adres="Overpoortstraat 74, 9000 Gent", Openingsuren="MA-DO 20u-06u VRIJ-ZAT 21u-06u", OndernemerID= ondernemers.Single(o => o.Gebruikersnaam.Equals("JonasVdv")).OndernemerID},
                new Onderneming{Naam="Overpoort Bowl", Categorie="Café", Adres="Overpoortstraat 38, 9000 Gent", Openingsuren="MA-VRIJ 10u-02u", OndernemerID= ondernemers.Single(o => o.Gebruikersnaam.Equals("JonasVdv")).OndernemerID}

            };
            ondernemingen.ForEach(s => context.Ondernemings.AddOrUpdate(o => o.OndernemingID, s));
            context.SaveChanges();

            var evenementen = new List<Evenement>
            {
                new Evenement {Naam="Nieuwe folder Ikea België", Omschrijving="Lancering van de nieuwe folder voor Ikea België", Begindatum=DateTime.Parse("01/01/2019"), Einddatum=DateTime.Parse("01/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Ikea Gent") ).OndernemingID},
                new Evenement {Naam="Holiday Season", Omschrijving="Kom genieten van onze bereidingen speciaal voor de feestdagen! Tijdelijk beschikbaar", Begindatum=DateTime.Parse("01/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Starbucks station Gent-Sint-Pieters") ).OndernemingID},
                new Evenement {Naam="Holiday Season", Omschrijving="Kom genieten van onze bereidingen speciaal voor de feestdagen! Tijdelijk beschikbaar", Begindatum=DateTime.Parse("01/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Starbucks Korenmarkt") ).OndernemingID},
                new Evenement {Naam="Kerstactie Meme Gusta", Omschrijving="Gratis fles wijn bij elk kerstdiner voor 2 personen!", Begindatum=DateTime.Parse("24/12/2018"), Einddatum=DateTime.Parse("25/12/2018"), OndernemingID = ondernemingen.Single(o => o.Naam.Equals("Meme Gusta")).OndernemingID},
                new Evenement {Naam="Bier bowling!", Omschrijving="Bier bowling voor 15 euro all-in", Begindatum=DateTime.Parse("05/01/2019"), Einddatum=DateTime.Parse("06/01/2019"), OndernemingID=ondernemingen.Single(o => o.Naam.Equals("Overpoort Bowl")).OndernemingID},
                new Evenement {Naam="Bottle night!", Omschrijving="Alle flessen sterke drank aan 30 euro", Begindatum=DateTime.Parse("28/01/2019"), Einddatum=DateTime.Parse("29/01/2019"), OndernemingID=ondernemingen.Single(o => o.Naam.Equals("Cuba Gent")).OndernemingID}

            };
            evenementen.ForEach(s => context.Evenements.AddOrUpdate(e => e.EvenementID, s));
            context.SaveChanges();

            var promoties = new List<Promotie>
            {
                new Promotie {Naam="Eindejaarspromo", Omschrijving="5% korting bij alle aankopen boven de 100 euro", Begindatum=DateTime.Parse("06/12/2018"), Einddatum=DateTime.Parse("02/01/2019"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Ikea Gent") ).OndernemingID, Korting="5%"},
               new Promotie {Naam="Graindor koffie", Omschrijving="10% korting bij aankoop vanaf 3 verpakkingen Graindor koffie, enkel geldig op vertoon van uw extra-kaart", Begindatum = DateTime.Parse("17/12/2018"), Einddatum=DateTime.Parse("30/12/2018"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("OKay Gent")).OndernemingID, Korting="10%"},
               new Promotie {Naam="Graindor koffie", Omschrijving="10% korting bij aankoop vanaf 3 verpakkingen Graindor koffie, enkel geldig op vertoon van uw extra-kaart", Begindatum = DateTime.Parse("17/12/2018"), Einddatum=DateTime.Parse("30/12/2018"), OndernemingID= ondernemingen.Single(o => o.Naam.Equals("Colruyt Gent")).OndernemingID, Korting="10%"},
               new Promotie {Naam="Winteractie", Omschrijving="15% korting op alle wintersportartikelen", Begindatum=DateTime.Parse("18/12/2018"), Einddatum=DateTime.Parse("05/01/2019"), OndernemingID=ondernemingen.Single(o => o.Naam.Equals("Sport utilities")).OndernemingID, Korting="15%"}
            };
            promoties.ForEach(s => context.Promoties.AddOrUpdate(p => p.PromotieID, s));
            context.SaveChanges();

            var gebruikers = new List<IngelogdeGebruiker>
            {
                new IngelogdeGebruiker { Naam = "Van De Velde", Voornaam = "Ruben", Gebruikersnaam = "rubenvdv", Wachtwoord = "hCcYm/HNUJ1+lnzjUFkGi/feZX8qNuJDLWtsgfjSaYtz3vcgHeboVjwqd1DvoWE4i+rcf/nfD9UBM7EId/FyQg==", Email = "rubenvdv26@live.com" , VolgendeOndernemingen = ondernemingen.GetRange(1, 2)}, //password rubenvdv
                new IngelogdeGebruiker { Naam = "Roelants", Voornaam = "Jeroen", Gebruikersnaam = "jeroenroelants", Wachtwoord = "04Lcqi1CyOavmpLPmPL7M/dBIiR5QTKvOipjgE2E0jFOL6fFWmJ6Rkmo22pRZjh5zscCx9XUpC9BX7eSOBKTSQ==", Email = "jeroenroelants26@live.com", VolgendeOndernemingen = ondernemingen.GetRange(0, 2) }, //password jeroenroelants
                new IngelogdeGebruiker { Naam = "Janssens", Voornaam = "Bavo", Gebruikersnaam = "bavojanssens", Wachtwoord = "G0CgLdnlWsSoiRHmML6y0VVxQggSXIodr9LryE9k/n0QpEvXWg0NGlDmLIHgwPCyVGXh3UCDTAyMlAw9+WmCNw==", Email = "bavojanssens26@live.com", VolgendeOndernemingen = ondernemingen.GetRange(0, ondernemingen.Count()) }, //password bavojanssens
            };

            gebruikers.ForEach(g => context.IngelogdeGebruikers.AddOrUpdate(ig => ig.IngelogdeGebruikerID, g));
            context.SaveChanges();
        }


    }
    
}
