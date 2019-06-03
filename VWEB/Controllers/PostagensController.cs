using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VWEB.Models;

namespace VWEB.Controllers
{
    public class PostagensController : Controller
    {
        private VWEBContext db = new VWEBContext();

        // GET: Postagens
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Index()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Postagems.ToList());
        }

        // GET: Postagens/Details/5
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
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // GET: Postagens/Create
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Postagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create([Bind(Include = "Id,Titulo,Codigo,Descricao,Texto")] Postagem postagem, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    file = this.Request.Files[0];
                }
                string _FileName = Path.GetFileName(file.FileName);
                string _Path = Path.Combine(Server.MapPath("~/Uploads"), _FileName);
                file.SaveAs(_Path);

                MD5 md5hash = MD5.Create();

                postagem.Data = DateTime.Now;
                postagem.Codigo = GetMd5Hash(md5hash, postagem.Titulo);
                postagem.ImagemCapa = "Uploads/" + file.FileName;
                postagem.UsuarioId = 1;
                db.Postagems.Add(postagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postagem);
        }

        // GET: Postagens/Edit/5
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
        [OutputCache(NoStore = true, Duration = 0)]

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
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // POST: Postagens/Delete/5
        [OutputCache(NoStore = true, Duration = 0)]

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
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
