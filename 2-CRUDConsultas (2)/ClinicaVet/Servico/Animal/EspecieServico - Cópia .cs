using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Animal;
using Persistencia.DAL.Animal;

namespace Servico.Animal
{
    public class PetsServico
    {
        private PetDAL PetDAL = new PetDAL();
        public IQueryable<Pet> ObterPetsClassificadasPorNome()
        {
            return PetDAL.ObterPetsClassificadosPorNome();
        }

        public Pet ObterPetPorId(long id)
        {
            return PetDAL.ObterPetPorId(id);
        }
        public void GravarPet(Pet pet)
        {
            EspecieDAL.GravarPet(pet);
        }
        public Pet EliminarPetPorId(long id)
        {
            Pet pet = PetDAL.ObterPetPorId(id);
            PetDAL.EliminarPetPorId(id);
            return pet;
        }
    }
}