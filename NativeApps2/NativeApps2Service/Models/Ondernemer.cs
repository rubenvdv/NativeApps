using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NativeApps2Service.Models
{
    public class Ondernemer
    {
        public ObservableCollection<Onderneming> bedrijven = new ObservableCollection<Onderneming>();

        public int OndernemerID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; } //Hierbij gaan we nog moeten kijken hoe we dit opslaan, want mag geen cleartext zijn
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Onderneming> Ondernemingen { get; set; }
    }
}