using System.Net;
using System.Web.Mvc;
using Servico.Animal;
using Modelos.Animal;
using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Servico.Users;

namespace ClinicaVet.Controllers
{
    public class PetController : Controller
    {
        private EFContext context = new EFContext();

        private PetsServico petServico = new PetsServico();
        private EspeciesServico especieServico = new EspeciesServico();
        private ClienteServico clienteServico = new ClienteServico();


        // GET: Pets
        public ActionResult Index()
        {
            return View(petServico.ObterPetsClassificadasPorNome());
        }


        // GET: Pets/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            return GravarPet(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(petServico.ObterPetPorId((long)id));
            return ObterVisaoPetsPorId(id);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        public ActionResult Edit(Pet exames)
        {
            return GravarPet(exames);
        }

        // GET: Pets/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoPetsPorId(id);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoPetsPorId(id);
        }

        // POST: Pets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pet pet = petServico.EliminarPetPorId(id);
                try
                {
                    TempData["Message"] = "Pet " + pet.Nome.ToUpper() + " foi removido";
                }
                catch
                {
                    TempData["Message"] = "O pet foi removido";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoPetsPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = petServico.ObterPetPorId((long)id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // Metodo Privado
        private void PopularViewBag(Pet pet = null)
        {
            if (pet == null)
            {
                ViewBag.EspecieId = new SelectList(especieServico.ObterEspeciesClassificadosPorNome(),
                "EspecieId", "Nome");
                ViewBag.ClienteId = new SelectList(clienteServico.ObterClientesClassificadosPorCpf(),
                "cpf", "cpf");
            }
            else
            {
                ViewBag.EspecieId = new SelectList(especieServico.ObterEspeciesClassificadosPorNome(),
                "EspecieId", "Nome", pet.EspecieId);
                ViewBag.ClienteId = new SelectList(clienteServico.ObterClientesClassificadosPorCpf(),
                "cpf", "cpf", pet.ClienteId);
            }
        }

        // Metodo Privado
        private ActionResult GravarPet(Pet pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petServico.GravarPet(pet);
                    return RedirectToAction("Index");
                }
                PopularViewBag(pet);
                return View(pet);
            }
            catch
            {
                PopularViewBag(pet);
                return View(pet);
            }
        }
    }
}