using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Users;
using Persistencia.DAL.Users;

namespace Servico.Users
{
    public class VeterinarioServico
    {
        private VeterinarioDAL VeterinarioDAL = new VeterinarioDAL();
        public IQueryable<Veterinario> ObterVetsClassificadosPorCrmv()
        {
            return VeterinarioDAL.ObterVetsClassificadosPorCrmv();
        }
    }
}