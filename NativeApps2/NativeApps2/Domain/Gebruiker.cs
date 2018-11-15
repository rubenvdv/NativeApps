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
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        #endregion

        public Gebruiker()
        {
            Naam = "Anoniem";
            Gebruikersnaam = "";
            Wachtwoord = "";
            Email = "";
        }
    }
}
