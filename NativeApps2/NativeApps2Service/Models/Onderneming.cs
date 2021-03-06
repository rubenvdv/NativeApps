﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace NativeApps2Service.Models
{
    public class Onderneming
    {
        public int OndernemingID { get; set; }
        public string Naam { get; set; }
        public string Categorie { get; set; }
        public string Adres { get; set; }
        public string Openingsuren { get; set; }

        
        public virtual Ondernemer Ondernemer { get; set; }
        public int OndernemerID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Evenement> Evenementen { get; set; }

        [JsonIgnore]
        public virtual ICollection<IngelogdeGebruiker> volgendeGebruikers { get; set; }

        public Onderneming()
        {

        }
        
        public Onderneming(string naam, string cat, string adres, string openingsuren)
        {
            Naam = naam;
            Categorie = cat;
            Adres = adres;
            Openingsuren = openingsuren;
        }
    }
}