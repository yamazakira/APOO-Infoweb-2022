using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Animal;

namespace Modelos.Animal
{
    public class Pet
    {
        [Required]
        public long PetId { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
        public long? EspecieId { get; set; }
        public Especie Especie { get; set; }
    }
}