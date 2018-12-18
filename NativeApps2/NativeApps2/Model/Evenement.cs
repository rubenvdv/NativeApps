using System;
using System.ComponentModel;

namespace NativeApps2.Domain
{
    public class Evenement : INotifyPropertyChanged
    {
        private int evenementID;
        private string naam;
        private string omschrijving;
        private DateTime begindatum;
        private DateTime einddatum;
        private int ondernemingID;

        private Onderneming onderneming;

        public int EvenementID
        {
            get
            {
                return evenementID;
            }
            set
            {
                if (evenementID != value)
                {
                    evenementID = value;
                    RaisePropertyChanged("EvenementID");
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
