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

        /*public override bool Equals(object obj)
        {
            Ondernemer o = (Ondernemer)obj;
            return this.OndernemerID.Equals(o.OndernemerID);
        }

        public override int GetHashCode()
        {
            var hashCode = -176717849;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<Onderneming>>.Default.GetHashCode(bedrijven);
            hashCode = hashCode * -1521134295 + OndernemerID.GetHashCode();
            return hashCode;
        }*/
    }
}
