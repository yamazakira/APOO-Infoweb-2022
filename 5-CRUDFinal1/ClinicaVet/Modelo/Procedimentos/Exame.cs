using Modelos.Animal;
using Modelos.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelos.Procedimentos
{
    public class Exame
    {
        public long ExameId { get; set; }
        public string Nome { get; set; }
        public long? ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
        public long? VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }
        public long? PetId { get; set; }
        public Pet Pet { get; set; }
    }
}