using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.Contexts;
using Modelos.Consultas;
using System.Data.Entity;

namespace Persistencia.DAL.Consultas
{
    public class ExamesDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Exame> ObterExamesClassificadosPorNome()
        {
            return context.Exames.OrderBy(b => b.Nome);
        }

        public Exame ObterExamePorId(long id)
        {
            return context.Exames.Where(f => f.ExameId == id).First();
        }

        public void GravarExame(Exame exame)
        {
            if (exame.ExameId == 0)
            {
                context.Exames.Add(exame);
            }
            else
            {
                context.Entry(exame).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Exame EliminarExamePorId(long id)
        {
            Exame exame = ObterExamePorId(id);
            context.Exames.Remove(exame);
            context.SaveChanges();
            return exame;
        }
    }
}