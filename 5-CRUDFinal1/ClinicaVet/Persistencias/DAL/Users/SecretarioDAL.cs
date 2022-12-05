using Modelos.Users;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persistencia.DAL.Users
{
    public class SecretarioDAL : UsuarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Secretario> ObterSecretariosClassificadosPorData()
        {
            return context.Secretarios.OrderBy(b => b.dt_admissao);
        }
    }
}