using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VWEB.Models;

namespace VWEB.Controllers
{
    public class LoginController : Controller
    {

        private VWEBContext db = new VWEBContext();

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            if (Session["email"] != null && Session["senha"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in db.Usuarios.ToList())
                {
                    if (usuario.Email == item.Email && usuario.Senha == item.Senha)
                    {
                        Session["email"] = usuario.Email;
                        Session["senha"] = usuario.Senha;
                        return RedirectToAction("Index", "Alunos");
                    }
                }
            }
            return View();
        }
    }
}