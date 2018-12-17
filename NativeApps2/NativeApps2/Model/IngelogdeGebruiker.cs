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
       
        public virtual ObservableCollection<Onderneming> VolgendeOndernemingen { get; set; } //Ondernemingen die de gebruiker volgt
        
        #endregion
        #region Constructors
        public IngelogdeGebruiker()
        {

        }
        public IngelogdeGebruiker(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail) : base(naam, voornaam, gebruikersnaam, wachtwoord, mail)
        {
            VolgendeOndernemingen = new ObservableCollection<Onderneming>();
        }
        #endregion

        
    }
}
