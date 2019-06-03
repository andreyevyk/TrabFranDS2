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
    public class AlunosController : Controller
    {
        private VWEBContext db = new VWEBContext();

        // GET: Alunos
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Alunos.ToList());
        }

        // GET: Alunos/Details/5
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
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Create()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Alunos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Matricula,Observacao,Img,SenhaSei")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
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
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Matricula,Observacao,Img,SenhaSei")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
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
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
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
