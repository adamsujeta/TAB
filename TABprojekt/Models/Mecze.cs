using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Mecze")]
    public class Mecze
    {
        public int id { get; set; }

        public Druzyna druzyna1 { get; set; }
        public Druzyna druzyna2 { get; set; }

        public Stadion stadion { get; set; }

        public DateTime data { get; set; }
        public string wynikPolowa { get; set; }

        public string wynikKoniec { get; set; }

        public virtual ICollection<Sedzia> sedzia { get; set; }
    }
}