using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Kontuzje")]
    public class Kontuzje
    {
        public int id { get; set; }
        public string rodzaj { get; set; }

        public DateTime data_od { get; set; }
        public DateTime data_do { get; set; }

        public Zawodnik zawodnik { get; set; }
    }
}