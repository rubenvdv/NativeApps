using System.Collections.ObjectModel;

namespace NativeApps2.Domain
{
    public class Ondernemer : Gebruiker
    {
        #region properties
        public ObservableCollection<Onderneming> bedrijven = new ObservableCollection<Onderneming>();

        public int OndernemerID { get; set; }

        #endregion
        #region Constructors
        public Ondernemer()
        {
            
        }
        public Ondernemer(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail) : base(naam, voornaam, gebruikersnaam, wachtwoord, mail)
        {
            Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Email = mail;
        }
        #endregion

       
    }
}
