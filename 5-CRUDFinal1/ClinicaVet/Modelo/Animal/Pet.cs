using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Animal;
using Modelos.Users;

namespace Modelos.Animal
{
    public class Pet
    {
        [Required]
        public long PetId { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public TipoSexo Sexo { get; set; }
        public enum TipoSexo
        {
            Feminino,
            Masculino
        }

        // Especie
        public long? EspecieId { get; set; }
        public Especie Especie { get; set; }

        // Dono
        public long? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}