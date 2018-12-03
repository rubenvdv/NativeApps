using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Onderneming
    {
        #region properties
        public int OndernemingID { get; set; }
        public string Naam { get; set; }
        public string Categorie { get; set; }
        public string Adres { get; set; }
        public string Openingsuren { get; set; }
        public string Logo { get; set; }

        public virtual Ondernemer Ondernemer { get; set; }
        public int OndernemerID { get; set; }
        public virtual ICollection<Evenement> Evenementen { get; set; }
        #endregion

        public Onderneming(string naam, string cat, string adres, string openingsuren, string logo)
        {
            Naam = naam;
            Categorie = cat;
            Adres = adres;
            Openingsuren = openingsuren;
            Logo = "/Images/" + logo;
        }
    }
}
