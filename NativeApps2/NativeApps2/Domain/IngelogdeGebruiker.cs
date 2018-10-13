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
        public string _naam { get; set; }
        public string _voornaam { get; set; }
        public string _gebruikersnaam { get; set; }
        public string _wachtwoord { get; set; }
        public string _mail { get; set; }
        #endregion
        #region Constructors
        public IngelogdeGebruiker()
        {
            //constructor van gebruiker
        }
        public IngelogdeGebruiker(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail)
        {
            _naam = naam;
            _voornaam = voornaam;
            _gebruikersnaam = gebruikersnaam;
            _wachtwoord = wachtwoord;
            _mail = mail;
        } 
        #endregion
    }
}
