using System;
using System.ComponentModel;

namespace NativeApps2.Domain
{
    public class Promotie : INotifyPropertyChanged
    {
        /*
        public int PromotieID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int OndernemingID { get; set; }
        public string Korting { get; set; }

        public virtual Onderneming Onderneming { get; set; }

        public Promotie()
        {
               
        }

        public Promotie(string naam, string omschrijving, DateTime start, DateTime einde, int ondernemingId, string korting)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Begindatum = start;
            Einddatum = einde;
            OndernemingID = ondernemingId;
            Korting = korting;
        }*/

        
        private int promotieID;
        private string naam;
        private string omschrijving;
        private DateTime begindatum;
        private DateTime einddatum;
        private int ondernemingID;
        private string korting;

        private Onderneming onderneming;

        public int PromotieID
        {
            get
            {
                return promotieID;
            }
            set
            {
                if (promotieID != value)
                {
                    promotieID = value;
                    RaisePropertyChanged("PromotieID");
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

        public string Omschrijving
        {
            get
            {
                return omschrijving;
            }
            set
            {
                if (omschrijving != value)
                {
                    omschrijving = value;
                    RaisePropertyChanged("Omschrijving");
                }
            }
        }

        public DateTime Begindatum
        {
            get
            {
                return begindatum;
            }
            set
            {
                if (begindatum != value)
                {
                    begindatum = value;
                    RaisePropertyChanged("Begindatum");
                }
            }
        }

        public DateTime Einddatum
        {
            get
            {
                return einddatum;
            }
            set
            {
                if (einddatum != value)
                {
                    einddatum = value;
                    RaisePropertyChanged("Einddatum");
                }
            }
        }

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

        public string Korting
        {
            get
            {
                return korting;
            }
            set
            {
                if (korting != value)
                {
                    korting = value;
                    RaisePropertyChanged("Korting");
                }
            }
        }

        public virtual Onderneming Onderneming
        {
            get
            {
                return onderneming;
            }
            set
            {
                if (onderneming != value)
                {
                    onderneming = value;
                    RaisePropertyChanged("Onderneming");
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
