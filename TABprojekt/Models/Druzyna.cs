using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Druzyna")]
    public class Druzyna
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public Kraj kraj { get; set; }
        public Stadion stadion { get; set; }
        public Liga liga { get; set; }
        public Trener trener { get; set; }

        public virtual ICollection<Mecze> mecze { get; set; }
        public virtual ICollection<Zawodnik> zawodnicy { get; set; }

    }
}