using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Stadion")]
    public class Stadion
    {
        public int id { get; set; }
        public string nazwa { get; set; }

        public string adres { get; set; }
        [DisplayName("Kraj")]
        public Kraj kraj { get; set; }

        public int pojemnosc { get; set; }
        public virtual ICollection<Druzyna> druzyna { get; set; }
    }
}