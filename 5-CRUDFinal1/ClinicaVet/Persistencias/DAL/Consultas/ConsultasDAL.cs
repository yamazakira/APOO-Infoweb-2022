using System.Linq;
using Persistencia.Contexts;
using Modelos.Procedimentos;
using System.Data.Entity;

namespace Persistencia.DAL.Consultas
{
    public class ConsultasDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadasPorData()
        {
            return context.Consultas.Include(c => c.Veterinario).Include(c => c.Cliente).Include(c => c.Pet).OrderBy(b => b.ConsultaData);
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(f => f.ConsultaId == id).Include(c => c.Veterinario).Include(c => c.Cliente).Include(c => c.Pet).First();
        }

        public void GravarConsulta(Consulta Consulta)
        {
            if (Consulta.ConsultaId == 0)
            {
                context.Consultas.Add(Consulta);
            }
            else
            {
                context.Entry(Consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta Consulta = ObterConsultaPorId(id);
            context.Consultas.Remove(Consulta);
            context.SaveChanges();
            return Consulta;
        }
    }
}