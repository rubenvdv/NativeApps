using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class IngelogdeGebruiker : Gebruiker
    {
        #region properties
        public string Naam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Onderneming> VolgendeOndernemingen { get; set; } //Ondernemingen die de gebruiker volgt


        #endregion
        #region Constructors
        public IngelogdeGebruiker()
        {
        }
        public IngelogdeGebruiker(string naam, string gebruikersnaam, string wachtwoord, string mail)
        {
            Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Email = mail;
        } 
        #endregion
    }
}
