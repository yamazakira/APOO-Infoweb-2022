using Modelos.Users;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persistencia.DAL.Users
{
    public class VeterinarioDAL : UsuarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Veterinario> ObterVetsClassificadosPorCrmv()
        {
            return context.Veterinarios.OrderBy(b => b.crmv);
        }
    }
}