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
    public class ClienteController : Controller
    {
        private ClienteServico clienteServico = new ClienteServico();
        private UsuarioServico usuarioServico = new UsuarioServico();
        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario cliente = usuarioServico.ObterUsuarioPorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioServico.GravarUsuario(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(clienteServico.ObterClientesClassificadosPorCpf());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Usuario cliente = usuarioServico.EliminarUsuarioPorId(id);
                TempData["Message"] = "Cliente " + cliente.Nome + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}