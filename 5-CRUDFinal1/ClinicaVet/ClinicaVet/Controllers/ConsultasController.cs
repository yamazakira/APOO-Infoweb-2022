using Modelos.Procedimentos;
using Servico.Animal;
using Servico.Procedimentos;
using Servico.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVet.Controllers
{
    public class ConsultasController : Controller
    {
        private ConsultasServico consultasServico = new ConsultasServico();
        private VeterinarioServico vetsServico = new VeterinarioServico();
        private ClienteServico clienteServico = new ClienteServico();
        private UsuarioServico usuarioServico = new UsuarioServico();
        private PetsServico petServico = new PetsServico();

        private ActionResult ObterVisaoConsultaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultasServico.ObterConsultaPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        private ActionResult GravarConsulta(Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultasServico.GravarConsulta(consulta);
                    return RedirectToAction("Index");
                }
                PopularViewBag(consulta);
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(consultasServico.ObterConsultasClassificadasPorData());
        }

        // GET: Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {
            return GravarConsulta(consulta);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            PopularViewBag(consultasServico.ObterConsultaPorId((long)id));
            return ObterVisaoConsultaPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consulta consulta)
        {
            return GravarConsulta(consulta);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Consulta consulta= consultasServico.EliminarConsultaPorId(id);
                TempData["Message"] = "Consulta do dia " + consulta.ConsultaData+ " foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Metodo Privado
        private void PopularViewBag(Consulta consulta = null)
        {
            if (consulta == null)
            {
                ViewBag.VeterinarioId = new SelectList(vetsServico.ObterVetsClassificadosPorCrmv(),
                "crmv", "crmv");
                ViewBag.ClienteId = new SelectList(clienteServico.ObterClientesClassificadosPorCpf(),
                "cpf", "cpf");
                ViewBag.PetId = new SelectList(petServico.ObterPetsClassificadasPorNome(),
                "PetId", "Nome");
            }
            else
            {
                ViewBag.VeterinarioId = new SelectList(vetsServico.ObterVetsClassificadosPorCrmv(),
                "crmv", "crmv", consulta.VeterinarioId);
                ViewBag.ClienteId = new SelectList(clienteServico.ObterClientesClassificadosPorCpf(),
                "cpf", "cpf", consulta.ClienteId);
                ViewBag.PetId = new SelectList(petServico.ObterPetsClassificadasPorNome(),
                "PetId", "Nome", consulta.PetId);
            }
        }
    }
}