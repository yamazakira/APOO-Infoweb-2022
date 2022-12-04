using Modelos.Animal;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persistencia.DAL.Animal
{
    public class EspecieDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Especie> ObterEspeciesClassificadosPorNome()
        {
            return context.Especies.OrderBy(b => b.Nome);
        }

        public Especie ObterEspeciePorId(long id)
        {
            return context.Especies.Where(p => p.EspecieId == id).First();
        }

        public IQueryable<Especie> ObterEspeciesPorId()
        {
            return context.Especies.OrderBy(b => b.EspecieId);
        }

        public void GravarPet(Pet pet)
        {
            if (pet.PetId == null)
            {
                context.Pets.Add(pet);
            }
            else
            {
                context.Entry(pet).State = EntityState.Modified;
            }
            context.SaveChanges();
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