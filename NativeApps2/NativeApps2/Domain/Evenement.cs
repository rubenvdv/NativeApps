using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Evenement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public string Logo { get; set; }

        private int evenementID;
        public int EvenementID { get { return evenementID; } set { this.evenementID = value; RaisePropertyChanged(); } }
        private string naam;
        public string Naam { get { return naam; } set { this.naam = value; RaisePropertyChanged(); } }
        private string omschrijving;
        public string Omschrijving { get { return omschrijving; } set { this.omschrijving = value; RaisePropertyChanged(); } }
        private DateTime begindatum;
        public DateTime Begindatum { get { return begindatum; } set { this.begindatum = value; RaisePropertyChanged(); } }
        private DateTime einddatum;
        public DateTime Einddatum { get { return einddatum; } set { this.einddatum = value; RaisePropertyChanged(); } }
        private int ondernemingID;
        public int OndernemingID { get { return ondernemingID; } set { this.ondernemingID = value; RaisePropertyChanged(); } }


        public virtual Onderneming Onderneming { get; set; }

        /*public Evenement(string naam, string omschrijving, DateTime start, DateTime einde, Onderneming onderneming)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Begindatum = start;
            Einddatum = einde;
            Onderneming = onderneming;
            //Logo = this.Onderneming.Logo;
        }*/
    }
}
