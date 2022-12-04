using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Users;
using Persistencia.DAL.Users;

namespace Servico.Users
{
    public class SecretarioServico
    {
        private SecretarioDAL SecretarioDAL = new SecretarioDAL();
        public IQueryable<Secretario> ObterVetsClassificadosPorData()
        {
            return SecretarioDAL.ObterSecretariosClassificadosPorData();
        }
    }
}