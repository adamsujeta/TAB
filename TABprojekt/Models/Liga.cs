using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Liga")]
    public class Liga
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public Kraj kraj { get; set; }
        public virtual ICollection<Druzyna> druzyna { get; set; }
    }
}