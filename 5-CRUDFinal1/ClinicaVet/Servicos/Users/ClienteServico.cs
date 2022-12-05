using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Users;
using Persistencia.DAL.Users;

namespace Servico.Users
{
    public class ClienteServico
    {
        private ClientesDAL ClienteDAL = new ClientesDAL();
        public IQueryable<Cliente> ObterClientesClassificadosPorCpf()
        {
            return ClienteDAL.ObterClientesClassificadosPorCpf();
        }
    }
}