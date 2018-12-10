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
    public class Ondernemer : Gebruiker, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region properties
        public ObservableCollection<Onderneming> bedrijven = new ObservableCollection<Onderneming>();

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

        #endregion
        #region Constructors
        /*public Ondernemer()
        {
            //constructor van gebruiker
        }
        public Ondernemer(string naam, string voornaam, string gebruikersnaam, string wachtwoord, string mail) : base(naam, voornaam, gebruikersnaam, wachtwoord, mail)
        {
            Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
            Email = mail;
        }*/
        #endregion

        /*public void VoegOndernemingToe(string naam, string cat, string adres, string openingsuren)
        {
            bedrijven.Add(new Onderneming(naam, cat, adres, openingsuren));
        }*/
    }
}
