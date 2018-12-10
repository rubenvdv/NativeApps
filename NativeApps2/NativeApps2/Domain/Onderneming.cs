using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Onderneming : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region properties
        private int ondernemingID;
        public int OndernemingID { get { return ondernemingID; } set { this.ondernemingID = value; RaisePropertyChanged(); } }
        private string naam;
        public string Naam { get { return naam; } set { this.naam = value; RaisePropertyChanged(); } }
        private string categorie;
        public string Categorie { get { return categorie; } set { this.categorie = value; RaisePropertyChanged(); } }
        private string adres;
        public string Adres { get { return adres; } set { this.adres = value; RaisePropertyChanged(); } }
        private string openingsuren;
        public string Openingsuren { get { return openingsuren; } set { this.openingsuren = value; RaisePropertyChanged(); } }

        public virtual Ondernemer Ondernemer { get; set; }
        private int ondernemerID;
        public int OndernemerID { get { return ondernemerID; } set { this.ondernemerID = value; RaisePropertyChanged(); } }
        public virtual ICollection<Evenement> Evenementen { get; set; }
        #endregion

        
        /*public Onderneming(string naam, string cat, string adres, string openingsuren)
        {
            Naam = naam;
            Categorie = cat;
            Adres = adres;
            Openingsuren = openingsuren;
        }

        public void VoegEvenementToe(string naam, string omschr, DateTime start, DateTime einde)
        {
            Evenementen.Add(new Evenement(naam, omschr, start, einde, this));
        }*/
    }
}
