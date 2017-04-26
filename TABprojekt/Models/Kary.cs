using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Kary")]
    public class Kary
    {
        public int id { get; set; }
        public string rodzaj { get; set; }
        public string opis { get; set; }

        public DateTime data { get; set; }
        public Zawodnik zawodnik { get; set; }

    }
}