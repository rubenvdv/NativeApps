using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class Promotie
    {
        public int PromotieID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int OndernemingID { get; set; }
        public string Korting { get; set; }

        public virtual Onderneming Onderneming { get; set; }

        public Promotie()
        {
               
        }

        public Promotie(string naam, string omschrijving, DateTime start, DateTime einde, int ondernemingId, string korting)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Begindatum = start;
            Einddatum = einde;
            OndernemingID = ondernemingId;
            Korting = korting;
        }

        public override bool Equals(object obj)
        {
            Promotie p = (Promotie)obj;
            return this.Naam.Equals(p.Naam);
        }
    }
}
