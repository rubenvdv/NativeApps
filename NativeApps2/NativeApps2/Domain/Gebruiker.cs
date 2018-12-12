using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Gebruiker
    {
        #region properties
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public string ProfielFoto { get; set; }
        #endregion

        public Gebruiker(string naam="Doe", string voornaam="John", string gebruikersnaam="", string ww="", string mail="")
        {
            Naam = naam;
            Voornaam = voornaam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = ww;
            Email = mail;
            ProfielFoto = "/Images/anoniem.png";
        }

        public override bool Equals(object obj)
        {
            Gebruiker g = (Gebruiker)obj;
            return this.Gebruikersnaam.Equals(g.Gebruikersnaam);
        }
    }
}
