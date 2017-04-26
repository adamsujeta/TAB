using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    public class TABprojektContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TABprojektContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Druzyna> Druzyna { get; set; }
        public DbSet<Kary> Kary { get; set; }
        public DbSet<Kontuzje> Kontuzje { get; set; }
        public DbSet<Kraj> Kraj { get; set; }
        public DbSet<Liga> Liga { get; set; }
        public DbSet<Mecze> Mecze { get; set; }
        public DbSet<Sedzia> Sedzia { get; set; }
        public DbSet<Stadion> Stadion { get; set; }
        public DbSet<Statystyki> Statystyki { get; set; }
        public DbSet<Trener> Trener { get; set; }
        public DbSet<Zawodnik> Zawodnik { get; set; }

        public static TABprojektContext Create()
        {
            return new TABprojektContext();
        }
    }
}
