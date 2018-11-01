using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class DomeinController
    {
        //TO DO: gebruiker toevoegen aan database bij creatie in methode !!!
        public Gebruiker CurrentUser { get; set; }

        public DomeinController()
        {
            CurrentUser = new Gebruiker();
        }

        public void MaakNieuweGebruiker(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail)
        {
            CurrentUser = new IngelogdeGebruiker(naam, voornaam, gebruikersnaam, wachtwoord, mail);
        }

        public void MaakNieuweOndernemer(string naam, string gebruikersnaam, string wachtwoord, string mail)
        {
            CurrentUser = new Ondernemer(naam, gebruikersnaam, wachtwoord, mail);
        }
    }
}
