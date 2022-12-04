using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos.Users;
using Servico.Users;
using Persistencia.DAL.Users;
using System.Net;

namespace ClinicaVet.Controllers
{
    public class VeterinarioController : Controller
    {
        private VeterinarioServico vetsServico = new VeterinarioServico();
        private UsuarioServico usuarioServico = new UsuarioServico();
        private ActionResult ObterVisaoVeterinarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario vet = usuarioServico.ObterUsuarioPorId((long)id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        private ActionResult GravarVeterinario(Veterinario vet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioServico.GravarUsuario(vet);
                    return RedirectToAction("Index");
                }
                return View(vet);
            }
            catch
            {
                return View(vet);
            }
        }
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(vetsServico.ObterVetsClassificadosPorCrmv());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veterinario vet)
        {
            return GravarVeterinario(vet);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veterinario vet)
        {
            return GravarVeterinario(vet);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Usuario vet = usuarioServico.EliminarUsuarioPorId(id);
                TempData["Message"] = "Veterinario " + vet.Nome + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}