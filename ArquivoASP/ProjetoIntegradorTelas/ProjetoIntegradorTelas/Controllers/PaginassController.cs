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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult contato(contatoform ctt) {
            string message = Request.Form["Mensagem"];
            ctt.mensagem = message;
            mensagens.Add(ctt);
            return RedirectToAction("Index");
        }

    }
}