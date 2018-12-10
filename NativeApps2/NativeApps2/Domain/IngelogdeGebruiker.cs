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
    class IngelogdeGebruiker : Gebruiker,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region properties
        private string naam;
        public string Naam { get { return naam; } set { this.naam = value; RaisePropertyChanged(); } }
        private string voornaam;
        public string Voornaam { get { return voornaam; } set { this.voornaam = value; RaisePropertyChanged(); } }
        private string gebruikersnaam;
        public string Gebruikersnaam { get { return gebruikersnaam; } set { this.gebruikersnaam = value; RaisePropertyChanged(); } }
        private string wachtwoord;
        public string Wachtwoord { get { return wachtwoord; } set { this.wachtwoord = value; RaisePropertyChanged(); } }
        private string email;
        public string Email { get { return email; } set { this.email = value; RaisePropertyChanged(); } }

        public virtual ObservableCollection<Onderneming> VolgendeOndernemingen { get; set; } //Ondernemingen die de gebruiker volgt
        
        //public string ProfielFoto { get; set; }


        #endregion
        #region Constructors
        /*public IngelogdeGebruiker(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail) : base(naam, voornaam, gebruikersnaam, wachtwoord, mail)
        {
            Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Email = mail;
            VolgendeOndernemingen = new ObservableCollection<Onderneming>();
            ProfielFoto = "/Images/gebruiker1.png";
        }*/
        #endregion
    }
}
