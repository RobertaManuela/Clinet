using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using ProjetoIntegradorTelas.Models;
using ProjetoIntegradorTelas.Context;

namespace ProjetoIntegradorTelas.Controllers
{
    public class PaginassController : Controller
    {
        private static IList<contatoform> mensagens = new List<contatoform>();
        EFContext context = new EFContext(); 
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
        //GET : loginloginecadastro
        public ActionResult loginloginecadastro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult loginloginecadastro(paciente register) {
            if (!context.Cadastros.Any()) register.UserID = 1;
            else register.UserID = context.Cadastros.Select(m => m.UserID).Max() + 1;
            context.Cadastros.Add(register);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginForm(paciente register)
        {
            if (!context.Cadastros.Where(m => m.username == register.username).Any())
            {
                return HttpNotFound();
            }
            paciente attemp = context.Cadastros.Where(m => m.username == register.username).First();
            if (attemp.password != register.password) {
                return HttpNotFound();
            }
            return RedirectToAction("pacientePagInicial");
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

        public ActionResult medicocadastrar() {
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

        public ActionResult secretariaPagInicial()
        {
            return View();
        }

        public ActionResult secretaria_listarmedico()
        {
            return View(context.Medicos.OrderBy(m => m.medicoID));
        }

        public ActionResult secretaria_cadastrarmedico()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult secretaria_cadastrarmedico(medico register) {
            if (!context.Medicos.Any())
            {
                register.medicoID = 1;
            }
            else register.medicoID = context.Medicos.Select(m => m.medicoID).Max() + 1;
            context.Medicos.Add(register);
            context.SaveChanges();
            return RedirectToAction("secretariaPagInicial");
        }

        public ActionResult secretaria_CRUDmedico(int id)
        {
            medico updates = context.Medicos.Where(m => m.medicoID == id).First();
            return View(updates);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload_medico(medico register) {
            if (ModelState.IsValid) {
                context.Entry(register).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("secretaria_listarmedico");
            }
            return RedirectToAction("secretariaPagInicial");
        }

        public ActionResult Delete_medico(int idm) {
            medico register = context.Medicos.Where(m => m.medicoID == idm).First();
            context.Medicos.Remove(register);
            context.SaveChanges();
            return RedirectToAction("secretariaPagInicial");   
        }

    }
}