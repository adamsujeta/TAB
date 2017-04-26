using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TABprojekt.Models
{
    [Table("Kraj")]
    public class Kraj
    {
        public int id { get; set; }

        public string nazwa { get; set; }

    }
}