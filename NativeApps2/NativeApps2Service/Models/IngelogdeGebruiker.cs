using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NativeApps2Service.Models
{
    public class IngelogdeGebruiker
    {
        
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        [Key]
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        
        public string Email { get; set; }

        public virtual ICollection<Onderneming> VolgendeOndernemingen { get; set; } //Ondernemingen die de gebruiker volgt
    }
}