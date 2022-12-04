using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Animal;

namespace Modelos.Users
{
    public class Secretario : Usuario
    {
        [Required]
        public DateTime? dt_admissao { get; set; }
    }
}