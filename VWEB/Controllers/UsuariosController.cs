﻿using System;
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
    public class UsuariosController : Controller
    {
        private VWEBContext db = new VWEBContext();

        // GET: Usuarios
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
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
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create()
        {
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Email,Senha")] Usuario usuario)
        {
            foreach(var user in db.Usuarios)
            {
                if (user.Email == usuario.Email)
                {
                    ViewBag.JaExiste = "Já existe usuário com esse email";
                    return View(usuario);
                }
            }
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Edit/5
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
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Email,Senha")] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
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
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]

        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            
            foreach (var Postagem in db.Postagems)
            {
                if(Postagem.UsuarioId == (int)Session["idUser"])
                {
                    Postagem.UsuarioId = 1;
                }
            }
            if (db.Usuarios.Find(id).Id == (int)Session["idUser"])
            {
                Session.Remove("email");
                Session.Remove("senha");
                Session.Abandon();

                db.Usuarios.Remove(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            db.Usuarios.Remove(usuario);
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
