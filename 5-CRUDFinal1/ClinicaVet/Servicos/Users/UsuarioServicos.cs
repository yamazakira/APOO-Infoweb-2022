using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Users;
using Persistencia.DAL.Users;

namespace Servico.Users
{
    public class UsuarioServico
    {
        private UsuarioDAL UsuarioDAL = new UsuarioDAL();
        public IQueryable<Usuario> ObterUsuariosClassificadosPorNome()
        {
            return UsuarioDAL.ObterUsuariosClassificadosPorNome();
        }

        public Usuario ObterUsuarioPorId(long id)
        {
            return UsuarioDAL.ObterUsuarioPorId(id);
        }

        public IQueryable<Usuario> ObterUsuarioPorId()
        {
            return UsuarioDAL.ObterUsuarioPorId();
        }

        public void GravarUsuario(Usuario Usuario)
        {
            UsuarioDAL.GravarUsuario(Usuario);
        }
        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario Usuario = UsuarioDAL.ObterUsuarioPorId(id);
            UsuarioDAL.EliminarUsuarioPorId(id);
            return Usuario;
        }
    }
}