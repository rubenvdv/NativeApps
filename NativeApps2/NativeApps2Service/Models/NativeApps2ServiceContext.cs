using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NativeApps2Service.Models
{
    public class NativeApps2ServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NativeApps2ServiceContext() : base("name=NativeApps2ServiceContext")
        {
        }

        public System.Data.Entity.DbSet<NativeApps2Service.Models.Evenement> Evenements { get; set; }

        public System.Data.Entity.DbSet<NativeApps2Service.Models.Ondernemer> Ondernemers { get; set; }

        public System.Data.Entity.DbSet<NativeApps2Service.Models.Onderneming> Ondernemings { get; set; }

        public System.Data.Entity.DbSet<NativeApps2Service.Models.IngelogdeGebruiker> IngelogdeGebruikers { get; set; }

        public System.Data.Entity.DbSet<NativeApps2Service.Models.Promotie> Promoties { get; set; }

        public System.Data.Entity.DbSet<NativeApps2Service.Models.IngelogdeGebruikerOndernemings> VolgendeOndernemingen { get; set; }

    }
}
