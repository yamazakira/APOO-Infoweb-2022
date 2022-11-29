using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Pets;
using Persistencia.DAL.Animal;

namespace Servico.Animal
{
    public class EspeciesServico
    {
        private PetDAL EspecieDAL = new PetDAL();
        public IQueryable<Especie> ObterEspeciesClassificadasPorNome()
        {
            return EspecieDAL.ObterEspeciesClassificadosPorNome();
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