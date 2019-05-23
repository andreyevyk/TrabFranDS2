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
    public class PostagensController : Controller
    {
        private VWEBContext db = new VWEBContext();

        // GET: Postagens
        public ActionResult Index()
        {
            return View(db.Postagems.ToList());
        }

        // GET: Postagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // GET: Postagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Codigo,Descricao,Texto,Imagem,Data")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                postagem.Data = DateTime.Now;
                postagem.Codigo = postagem.Codigo.ToString().Replace(" ", "_");
                db.Postagems.Add(postagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(postagem);
        }

        // GET: Postagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // POST: Postagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Codigo,Descricao,Texto,Imagem,Data")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postagem);
        }

        // GET: Postagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // POST: Postagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postagem postagem = db.Postagems.Find(id);
            db.Postagems.Remove(postagem);
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
