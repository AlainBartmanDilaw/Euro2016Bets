using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Euro2016.Controllers
{
    public class ResultatsController : Controller
    {
        //
        // GET: /Resultat/

        public ActionResult Index()
        {
            ViewBag.Message = "Résultat";
            return View();
        }

    }
}

