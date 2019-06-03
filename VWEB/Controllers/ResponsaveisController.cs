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
    public class ResponsaveisController : Controller
    {
        private VWEBContext db = new VWEBContext();

        // GET: Responsaveis
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Responsavels.ToList());
        }

        // GET: Responsaveis/Details/5
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
            Responsavel responsavel = db.Responsavels.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // GET: Responsaveis/Create
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Responsaveis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create([Bind(Include = "Id,Email,Senha,Nome,Sobrenome,Endereco,EndNumero,EndComplemento,Telefone,Telefone2,Observacao,UltimoAcesso,PrimeiroAcesso,TipoResponsavel")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Responsavels.Add(responsavel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsavel);
        }

        // GET: Responsaveis/Edit/5
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
            Responsavel responsavel = db.Responsavels.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsaveis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Edit([Bind(Include = "Id,Email,Senha,Nome,Sobrenome,Endereco,EndNumero,EndComplemento,Telefone,Telefone2,Observacao,UltimoAcesso,PrimeiroAcesso,TipoResponsavel")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsavel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsavel);
        }

        // GET: Responsaveis/Delete/5
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
            Responsavel responsavel = db.Responsavels.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult DeleteConfirmed(int id)
        {
            Responsavel responsavel = db.Responsavels.Find(id);
            db.Responsavels.Remove(responsavel);
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
