using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class Onderneming
    {
        #region attributen
        private ObservableCollection<Evenement> evenementen;
        #endregion

        #region properties
        public string Naam { get; set; }
        public string Categorie { get; set; }
        public string Adres { get; set; }
        public string Openingsuren { get; set; } 
        #endregion

        public Onderneming(string naam, string cat, string adres, string openingsuren)
        {
            Naam = naam;
            Categorie = cat;
            Adres = adres;
            Openingsuren = openingsuren;
        }
    }
}
