using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Modelos.Animal
{
    public class Especie
    {
        [Required]
        public long EspecieId { get; set; }

        public string Nome { get; set; }
    }
}