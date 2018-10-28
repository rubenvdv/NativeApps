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
        public string Naam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Mail { get; set; }
        #endregion
        #region Constructors
        public Ondernemer()
        {
            //constructor van gebruiker
        }
        public Ondernemer(string naam, string gebruikersnaam, string wachtwoord, string mail)
        {
            Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Mail = mail;
        }
        #endregion
    }
}
