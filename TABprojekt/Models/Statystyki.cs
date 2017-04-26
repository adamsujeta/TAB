using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Statystyki")]
    public class Statystyki
    {
        public int id { get; set; }
        public int bramki { get; set; }
        public int kartkiCzerwone { get; set; }
        public int kartkiZolte { get; set; }
        public Zawodnik zawodnik { get; set; }

        public Mecze mecz { get; set; }
    }
}