using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Animal;

namespace Modelos.Users
{
    public class Cliente : Usuario
    {
        [Required]
        public string cpf { get; set; }
    }
}