using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VWEB.Models;

namespace VWEB.Controllers
{
    public class HomeController : Controller
    {
        private VWEBContext db = new VWEBContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                bool toGo = false;
                foreach (var item in db.Usuarios.ToList())
                {
                    if (usuario.Email == item.Email)
                    {
                        if (usuario.Senha == item.Senha)
                        {
                            toGo = true;
                            break;
                        }
                    }

                }
                if (toGo)
                {
                    return RedirectToAction("Index", "Alunos");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}