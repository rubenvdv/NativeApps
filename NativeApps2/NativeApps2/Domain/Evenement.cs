using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    public class Evenement
    {
        public int EvenementID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int OndernemingID { get; set; }
        public string Logo { get; set; }

        public virtual Onderneming Onderneming { get; set; }

        public Evenement()
        {

        }

        public Evenement(string naam, string omschrijving, DateTime start, DateTime einde, int ondernemingId)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Begindatum = start;
            Einddatum = einde;
            OndernemingID = ondernemingId;
            //Logo = this.Onderneming.Logo;
        }

        public override bool Equals(object obj)
        {
            Evenement e = (Evenement)obj;
            return this.Naam.Equals(e.Naam);
        }
    }
}
