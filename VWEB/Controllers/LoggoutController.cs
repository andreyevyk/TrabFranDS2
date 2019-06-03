using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VWEB.Controllers
{
    public class LoggoutController : Controller
    {
        // GET: Loggout
        public ActionResult Deslogar()
        {
            Session.Remove("email");
            Session.Remove("senha");
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}