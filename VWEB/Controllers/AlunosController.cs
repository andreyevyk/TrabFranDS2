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
            ViewBag.ResponsavelId = new SelectList(db.Responsavels.OrderBy(r => r.Nome), "Id", "Nome");
            ViewBag.TurmaId = new SelectList(db.Turmas, "Id", "Nome").ToList();

            return View();
        }

        // POST: Alunos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Matricula,Observacao,Img")] Aluno aluno, HttpPostedFileBase file,int ResponsavelId, int TurmaId)
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

                aluno.Img = "Uploads/" + file.FileName;
                aluno.TurmaId = TurmaId;
                aluno.ReponsavelId = ResponsavelId;

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
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Matricula,Observacao,Img")] Aluno aluno, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;

                if (file == null)
                {
                    file = this.Request.Files[0];
                }
                string _FileName = Path.GetFileName(file.FileName);
                string _Path = Path.Combine(Server.MapPath("~/Uploads"), _FileName);
                file.SaveAs(_Path);

                aluno.Img = "Uploads/" + file.FileName;

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
