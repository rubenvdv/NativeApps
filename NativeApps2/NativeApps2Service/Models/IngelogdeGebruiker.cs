using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NativeApps2Service.Models
{
    public class IngelogdeGebruiker
    {
        [Key]
        public int IngelogdeGebruikerID{get; set;}
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        
        public string Email { get; set; }

        public virtual ICollection<Onderneming> VolgendeOndernemingen { get; set; } //Ondernemingen die de gebruiker volgt
    }
}