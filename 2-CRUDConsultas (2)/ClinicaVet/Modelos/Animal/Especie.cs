using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Modelos.Pets
{
    public class Especie
    {
        [Required]
        private long EspecieId { get; set; }

        private string Nome { get; set; }
    }
}