using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class Evenement
    {
        public int EvenementID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int OndernemingID { get; set; }

        public virtual Onderneming Onderneming { get; set; }

        public Evenement(string naam, string omschrijving, DateTime start, DateTime einde)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Begindatum = start;
            Einddatum = einde;
        }
    }
}
