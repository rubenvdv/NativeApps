using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Domain
{
    class Evenement
    {
        public string _naam { get; set; }
        public string _omschrijving { get; set; }
        public DateTime _begindatum { get; set; }
        public DateTime _einddatum { get; set; }

        public Evenement(string naam, string omschrijving, DateTime start, DateTime einde)
        {
            _naam = naam;
            _omschrijving = omschrijving;
            _begindatum = start;
            _einddatum = einde;
        }
    }
}
