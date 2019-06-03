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
            if (Session["email"] == null && Session["senha"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Mensagens = db.Mensagems.Take(3).ToList();
            ViewBag.Postagens = db.Postagems.Take(3).ToList();

            return View();
        }
       
    }
}