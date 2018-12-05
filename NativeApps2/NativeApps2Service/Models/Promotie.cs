using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeApps2Service.Models
{
    public class Promotie
    {
        public int PromotieID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }

        public int OndernemingID { get; set; }
        public string Korting { get; set; }

        public virtual Onderneming Onderneming { get; set; }
    }
}