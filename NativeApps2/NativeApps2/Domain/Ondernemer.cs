using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Ondernemer : Gebruiker
    {
        #region properties
        public ObservableCollection<Onderneming> bedrijven = new ObservableCollection<Onderneming>();

        public int OndernemerID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        #endregion
        #region Constructors
        public Ondernemer()
        {
            //constructor van gebruiker
        }
        public Ondernemer(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail) : base(naam, voornaam, gebruikersnaam, wachtwoord, mail)
        {
            /*Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Email = mail;*/
        }
        #endregion

        /*public void VoegOndernemingToe(string naam, string cat, string adres, string openingsuren)
        {
            bedrijven.Add(new Onderneming(naam, cat, adres, openingsuren));
        }*/
    }
}
