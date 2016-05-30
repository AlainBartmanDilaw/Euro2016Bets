using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Euro2016.Controllers
{
    public class BetsController : Controller
    {
        //
        // GET: /Bets/

        public ActionResult Index()
        {
            ViewBag.Message = "Faites vos jeux !";
            return View();
        }

    }
}
