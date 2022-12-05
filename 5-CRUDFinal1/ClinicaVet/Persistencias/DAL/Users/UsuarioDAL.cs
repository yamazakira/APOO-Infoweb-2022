using Modelos.Users;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persistencia.DAL.Users
{
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Usuario> ObterUsuariosClassificadosPorNome()
        {
            return context.Usuarios.OrderBy(b => b.Nome);
        }

        public Usuario ObterUsuarioPorId(long id)
        {
            return context.Usuarios.Where(p => p.UsuarioId == id).First();
        }

        public IQueryable<Usuario> ObterUsuarioPorId()
        {
            return context.Usuarios.OrderBy(b => b.UsuarioId);
        }

        public void GravarUsuario(Usuario usuario)
        {
            if (usuario.UsuarioId == 0)
            {
                context.Usuarios.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario usuario = ObterUsuarioPorId(id);
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }
    }
}