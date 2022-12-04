using System.Net;
using System.Web.Mvc;
using Servico.Procedimentos;
using Modelos.Procedimentos;
using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;

namespace ClinicaVet.Controllers
{
    public class ExamesController : Controller
    {
        private EFContext context = new EFContext();

        private ExamesServico examesServico = new ExamesServico();
        private ConsultasServico consultaServico = new ConsultasServico();


        // GET: Exames
        public ActionResult Index()
        {
            return View(examesServico.ObterExamesClassificadosPorNome());
        }


        // GET: Exames/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Exames/Create
        [HttpPost]
        public ActionResult Create(Exame exame)
        { 
            return GravarExame(exame);
        }

        // GET: Exames/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(examesServico.ObterExamePorId((long)id));
            return ObterVisaoExamesPorId(id);
        }

        // POST: Exames/Edit/5
        [HttpPost]
        public ActionResult Edit(Exame exames)
        {
            return GravarExame(exames);
        }

        // GET: Exames/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoExamesPorId(id);
        }

        // GET: Exames/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoExamesPorId(id);
        }

        // POST: Exames/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Exame exame = examesServico.EliminarExamePorId(id);
                try
                {
                    TempData["Message"] = "Exame " + exame.Nome.ToUpper() + " foi removido";
                }
                catch
                {
                    TempData["Message"] = "O exame foi removido";
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoExamesPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = examesServico.ObterExamePorId((long)id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // Metodo Privado
        private void PopularViewBag(Exame exame = null)
        {
            if (exame == null)
            {
                ViewBag.ConsultaId = new SelectList(consultaServico.ObterConsultasClassificadasPorData(),
                "ConsultaId", "ConsultaData");
            }
            else
            {
                ViewBag.ConsultaId = new SelectList(consultaServico.ObterConsultasClassificadasPorData(),
                "ConsultaId", "ConsultaData", exame.ConsultaId);
            }
        }

        // Metodo Privado
        private ActionResult GravarExame(Exame exames)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    examesServico.GravarExame(exames);
                    return RedirectToAction("Index");
                }
                PopularViewBag(exames);
                return View(exames);
            }
            catch
            {
                return View(exames);
            }
        }
    }
}