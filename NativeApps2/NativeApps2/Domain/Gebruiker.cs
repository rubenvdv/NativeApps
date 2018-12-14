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
        public string Initialen { get { return Naam.Substring(0, 1) + "" + Voornaam.Substring(0, 1); } }
        #endregion

        public Gebruiker()
        {

        }

        public Gebruiker(string naam="Doe", string voornaam="John", string gebruikersnaam="", string ww="", string mail="")
        {
            Naam = naam;
            Voornaam = voornaam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = ww;
            Email = mail;
            ProfielFoto = "/Images/anoniem.png";
        }

        /* public override bool Equals(object obj)
         {
             Gebruiker g;
             if (obj is Gebruiker)
             {
                 g = (Gebruiker)obj;
                 return this.Gebruikersnaam.Equals(g.Gebruikersnaam);
             }
             return base.Equals(obj);
         }*/

        /*public override bool Equals(object obj)
        {
            Gebruiker g = (Gebruiker)obj;
            return this.Gebruikersnaam.Equals(g.Gebruikersnaam);
        }

        public override int GetHashCode()
        {
            var hashCode = 354631125;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Voornaam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Gebruikersnaam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Wachtwoord);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProfielFoto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Initialen);
            return hashCode;
        }*/
    }
}
