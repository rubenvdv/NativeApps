using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public virtual ICollection<Evenement> Evenementen { get; set; }
    }
}