using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NativeApps2.Domain
{
    public class Onderneming : INotifyPropertyChanged
    {
        /*
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
        */
        private int ondernemingID;
        private string naam;
        private string categorie;
        private string adres;
        private string openingsuren;

        private Ondernemer ondernemer;
        private int ondernemerID;
        private ICollection<Evenement> evenementen;


        public int OndernemingID
        {
            get
            {
                return ondernemingID;
            }
            set
            {
                if (ondernemingID != value)
                {
                    ondernemingID = value;
                    RaisePropertyChanged("OndernemingID");
                }
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                if (naam != value)
                {
                    naam = value;
                    RaisePropertyChanged("Naam");
                }
            }
        }

        public string Categorie
        {
            get
            {
                return categorie;
            }
            set
            {
                if (categorie != value)
                {
                    categorie = value;
                    RaisePropertyChanged("Categorie");
                }
            }
        }

        public string Adres
        {
            get
            {
                return adres;
            }
            set
            {
                if (adres != value)
                {
                    adres = value;
                    RaisePropertyChanged("Adres");
                }
            }
        }

        public string Openingsuren
        {
            get
            {
                return openingsuren;
            }
            set
            {
                if (openingsuren != value)
                {
                    openingsuren = value;
                    RaisePropertyChanged("Openingsuren");
                }
            }
        }

        public virtual Ondernemer Ondernemer
        {
            get
            {
                return ondernemer;
            }
            set
            {
                if (ondernemer != value)
                {
                    ondernemer = value;
                    RaisePropertyChanged("Ondernemer");
                }
            }
        }

        public int OndernemerID
        {
            get
            {
                return ondernemerID;
            }
            set
            {
                if (ondernemerID != value)
                {
                    ondernemerID = value;
                    RaisePropertyChanged("OndernemerID");
                }
            }
        }

        public virtual ICollection<Evenement> Evenementen
        {
            get
            {
                return evenementen;
            }
            set
            {
                if (evenementen != value)
                {
                    evenementen = value;
                    RaisePropertyChanged("Evenementen");
                }
            }
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
