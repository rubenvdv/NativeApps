﻿using System;

namespace NativeApps2Service.Models
{
    public class Evenement
    {
        public int EvenementID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int OndernemingID { get; set; }

        public virtual Onderneming Onderneming { get; set; }
    }
}