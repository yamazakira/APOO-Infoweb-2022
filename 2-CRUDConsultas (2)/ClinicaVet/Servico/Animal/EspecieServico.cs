using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servico.Animal
{
    public class EspeciesServico
    {
        private EspeciesDAL EspecieDAL = new EspeciesDAL();
        public IQueryable<Especie> ObterEspeciesClassificadasPorData()
        {
            return EspecieDAL.ObterEspeciesClassificadasPorData();
        }

        public Especie ObterEspeciePorId(long id)
        {
            return EspecieDAL.ObterEspeciePorId(id);
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