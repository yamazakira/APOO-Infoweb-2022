using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistencia.DAL.Animal
{
    public class EspecieDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Especie> ObterEspeciesClassificadosPorNome()
        {
            return context.Especies.Include(c => c.Consulta).OrderBy(b => b.Nome);
        }

        public Especie ObterEspeciePorId(long id)
        {
            return context.Especies.Where(p => p.EspecieId == id).Include(c => c.Consulta).First();
        }

        public void GravarEspecie(Especie especie)
        {
            if (especie.EspecieId == 0)
            {
                context.Especies.Add(especie);
            }
            else
            {
                context.Entry(especie).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Especie EliminarEspeciePorId(long id)
        {
            Especie especie = ObterEspeciePorId(id);
            context.Especies.Remove(especie);
            context.SaveChanges();
            return especie;
        }
    }
}