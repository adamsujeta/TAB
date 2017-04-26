
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Sedzia")]
    public class Sedzia
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string ranga { get; set; }
        public Kraj kraj { get; set; }

    }
}