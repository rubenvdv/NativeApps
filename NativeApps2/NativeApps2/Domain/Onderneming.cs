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

        public virtual Ondernemer Ondernemer { get; set; }
        public int OndernemerID { get; set; }
        public virtual ICollection<Evenement> Evenementen { get; set; }
        #endregion


        public Onderneming()
        {
            
        }
        public Onderneming(string naam, string cat, string adres, string openingsuren, int OndernemerId)
        {
            Naam = naam;
            Categorie = cat;
            Adres = adres;
            Openingsuren = openingsuren;
            OndernemerID = OndernemerID;
        }

        /*public override bool Equals(object obj)
        {
            Onderneming o = (Onderneming)obj;
            return this.OndernemingID.Equals(o.OndernemingID);
        }

        public override int GetHashCode()
        {
            var hashCode = 653169438;
            hashCode = hashCode * -1521134295 + OndernemingID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Categorie);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adres);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Openingsuren);
            hashCode = hashCode * -1521134295 + EqualityComparer<Ondernemer>.Default.GetHashCode(Ondernemer);
            hashCode = hashCode * -1521134295 + OndernemerID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Evenement>>.Default.GetHashCode(Evenementen);
            return hashCode;
        }*/
    }
}
