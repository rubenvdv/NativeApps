using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Gebruiker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region properties
        public string naam;
        public string Naam { get { return naam; } set { this.naam = value; RaisePropertyChanged(); } }
        public string voornaam;
        public string Voornaam { get { return voornaam; } set { this.voornaam = value; RaisePropertyChanged(); } }
        public string gebruikersnaam;
        public string Gebruikersnaam { get { return gebruikersnaam; } set { this.gebruikersnaam = value; RaisePropertyChanged(); } }
        public string wachtwoord;
        public string Wachtwoord { get { return wachtwoord; } set { this.wachtwoord = value; RaisePropertyChanged(); } }
        public string email;
        public string Email { get { return email; } set { this.email = value; RaisePropertyChanged(); } }
        //public string ProfielFoto { get; set; }
        #endregion

        /*public Gebruiker(string naam="Doe", string voornaam="John", string gebruikersnaam="", string ww="", string mail="")
        {
            Naam = naam;
            Voornaam = voornaam;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = ww;
            Email = mail;
            ProfielFoto = "/Images/anoniem.png";
        }*/
    }
}
