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
        private ObservableCollection<string> meldingen;
        private ObservableCollection<Onderneming> bedrijven;
        #region properties
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Mail { get; set; }
        #endregion
        #region Constructors
        public IngelogdeGebruiker()
        {
            //constructor van gebruiker
        }
        public IngelogdeGebruiker(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail)
        {
            Naam = naam;
            Voornaam = voornaam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Mail = mail;
        } 
        #endregion
    }
}
