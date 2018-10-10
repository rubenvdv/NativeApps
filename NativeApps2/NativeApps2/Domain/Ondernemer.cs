using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class Ondernemer : Gebruiker
    {
        public ObservableCollection<Onderneming> bedrijven = new ObservableCollection<Onderneming>();
        #region properties
        public string _naam { get; set; }
        public string _gebruikersnaam { get; set; }
        public string _wachtwoord { get; set; }
        public string _mail { get; set; }
        #endregion
        #region Constructors
        public Ondernemer()
        {
            //constructor van gebruiker
        }
        public Ondernemer(string naam, string gebruikersnaam, string wachtwoord, string mail)
        {
            _naam = naam;
            _gebruikersnaam = gebruikersnaam;
            _wachtwoord = wachtwoord;
            _mail = mail;
        }
        #endregion
    }
}
