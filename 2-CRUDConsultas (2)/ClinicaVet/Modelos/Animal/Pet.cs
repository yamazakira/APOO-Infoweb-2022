using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Modelos.Animal
{
    public class Pet
    {
        [Required]
        private long PetId { get; set; }

        private string Nome { get; set; }

        private int Idade { get; set; }
    }
}