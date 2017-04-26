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
        public virtual Kraj kraj { get; set; }
        public virtual Stadion stadion { get; set; }
        public virtual Liga liga { get; set; }
        public virtual Trener trener { get; set; }

        public virtual ICollection<Mecze> mecze { get; set; }
        public virtual ICollection<Zawodnik> zawodnicy { get; set; }

    }
}