using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoIntegradorTelas.Models;

namespace ProjetoIntegradorTelas.Controllers
{
    public class PaginassController : Controller
    {
        private static IList<contatoform> mensagens = new List<contatoform>();
        // GET: Paginass
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult contato()
        {
            return View();
        }
        public ActionResult clinica()
        {
            return View();
        }
        public ActionResult loginloginecadastro()
        {
            return View();
        }
        public ActionResult histconsulta()
        {
            return View();
        }

        public ActionResult medicoPagInicial()
        {
            return View();
        }

        public ActionResult medico_dadospessoais()
        {
            return View();
        }

        public ActionResult clinicaMedico()
        {
            return View();
        }

        public ActionResult horariosMedico()
        {
            return View();
        }

        public ActionResult contatoMedico()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult contato(contatoform ctt) {
            string message = Request.Form["Mensagem"];
            ctt.mensagem = message;
            mensagens.Add(ctt);
            return RedirectToAction("Index");
        }

        public ActionResult pacientePagInicial()
        {
            return View();
        }

        public ActionResult paciente_dadospessoais()
        {
            return View();
        }

        public ActionResult paciente_marcacao()
        {
            return View();
        }



    }
}