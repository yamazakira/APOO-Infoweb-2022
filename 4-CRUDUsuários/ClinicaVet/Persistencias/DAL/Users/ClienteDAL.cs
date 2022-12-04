using Modelos.Users;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persistencia.DAL.Users
{
    public class ClientesDAL : UsuarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cliente> ObterClientesClassificadosPorCpf()
        {
            return context.Clientes.OrderBy(b => b.cpf);
        }
    }
}