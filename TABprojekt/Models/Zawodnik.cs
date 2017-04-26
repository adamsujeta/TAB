using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Zawodnik")]
    public class Zawodnik
    {
        public int id { get; set; }
        public string imie{ get; set; }

        public string nazwisko { get; set; }

        public int wzrost { get; set; }
        public int waga { get; set; }
        public string pozycja { get; set; }

        public int numer { get; set; }
        public Druzyna druzyna { get; set; }
        public DateTime data_urodzenia { get; set; }
        public Kraj kraj { get; set; }

        public virtual ICollection<Kary> kary { get; set; }
        public virtual ICollection<Kontuzje> kontuzje{ get; set; }
        public virtual ICollection<Statystyki> statystyki{ get; set; }

    }
}