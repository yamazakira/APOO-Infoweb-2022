using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Animal;
using Persistencia.DAL.Animal;

namespace Servico.Animal
{
    public class EspeciesServico
    {
        private EspecieDAL EspecieDAL = new EspecieDAL();
        public IQueryable<Especie> ObterEspeciesClassificadosPorNome()
        {
            return EspecieDAL.ObterEspeciesClassificadosPorNome();
        }

        public Especie ObterEspeciePorId(long id)
        {
            return EspecieDAL.ObterEspeciePorId(id);
        }

        public IQueryable<Especie> ObterEspeciesPorId()
        {
            return EspecieDAL.ObterEspeciesPorId();
        }

        public void GravarEspecie(Especie Especie)
        {
            EspecieDAL.GravarEspecie(Especie);
        }
        public Especie EliminarEspeciePorId(long id)
        {
            Especie Especie = EspecieDAL.ObterEspeciePorId(id);
            EspecieDAL.EliminarEspeciePorId(id);
            return Especie;
        }
    }
}