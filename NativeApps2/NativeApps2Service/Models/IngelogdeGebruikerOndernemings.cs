using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NativeApps2Service.Models
{
    public class IngelogdeGebruikerOndernemings
    {
        [Key, Column(Order =0)]
        public string Gebruikersnaam { get; set; }
        [Key, Column(Order = 1)]
        public int OndernemingsId { get; set; }

    }
}