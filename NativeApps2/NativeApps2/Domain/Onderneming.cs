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
        public string _naam { get; set; }
        public string _categorie { get; set; }
        public string _adres { get; set; }
        public string _openingsuren { get; set; } 
        #endregion

        public Onderneming(string naam, string cat, string adres, string openingsuren)
        {
            _naam = naam;
            _categorie = cat;
            _adres = adres;
            _openingsuren = openingsuren;
        }
    }
}
