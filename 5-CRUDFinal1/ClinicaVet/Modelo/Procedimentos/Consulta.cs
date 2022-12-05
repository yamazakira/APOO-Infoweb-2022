using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Users;
using Modelos.Animal;

namespace Modelos.Procedimentos
{
    public class Consulta
    {
        public long ConsultaId { get; set; }

        public string Sintomas { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data da Consulta")]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public DateTime? ConsultaData { get; set; }
        //public virtual ICollection<Exame> Exames { get; set; }
        public long? VeterinarioId { get; set; }
        public long? ClienteId { get; set; }
        public long? PetId { get; set; }
        public Veterinario Veterinario { get; set; }
        public Cliente Cliente { get; set; }
        public Pet Pet{ get; set; }
    }
}