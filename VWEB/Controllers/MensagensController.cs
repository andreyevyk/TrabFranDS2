using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VWEB.Models;

namespace VWEB.Controllers
{
    public class MensagensController : Controller
    {
        private VWEBContext db = new VWEBContext();

        // GET: Mensagems
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var mensagems = db.Mensagems.Include(m => m.Responsavel);
            return View(mensagems.ToList());
        }

        // GET: Mensagems/Details/5
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Details(int? id)
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // GET: Mensagems/Create
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsavels.OrderBy(r => r.Nome), "Id", "Nome");
            return View();
        }

        // POST: Mensagems/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create([Bind(Include = "Id,Titulo,Texto,Data,TipoMensagem,ResponsavelId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                mensagem.Data = DateTime.Now;
                db.Mensagems.Add(mensagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsavels.OrderBy(r => r.Nome), "Id", "Nome");
            return View(mensagem);
        }

        // GET: Mensagems/Edit/5
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Edit(int? id)
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsavels, "Id", "Email", mensagem.ResponsavelId);
            return View(mensagem);
        }

        // POST: Mensagems/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Edit([Bind(Include = "Id,Titulo,Texto,Data,TipoMensagem,ResponsavelId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsavels, "Id", "Email", mensagem.ResponsavelId);
            return View(mensagem);
        }

        // GET: Mensagems/Delete/5
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Delete(int? id)
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // POST: Mensagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult DeleteConfirmed(int id)
        {
            Mensagem mensagem = db.Mensagems.Find(id);
            db.Mensagems.Remove(mensagem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
