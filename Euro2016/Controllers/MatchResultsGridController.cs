using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Euro2016.Models;
using Omu.AwesomeMvc;

namespace Euro2016.Controllers
{
    public class MatchResultsGridController : Controller
    {
        private static object MapToGridModel(MatchResult o)
        {
            return
                new
                {
                    o.Idt
                    , o.Number
                    , o.Group
                    , o.ScheduleDate
                    , o.Phase
                    , o.Stade
                    , o.Town
                    , Home = o.Home.Name + " " + o.Home.Flag
                    , Away = o.Away.Name + " " + o.Away.Flag
                };
        }

        public ActionResult GridGetItems(GridParams g, string search)
        {
            search = (search ?? "").ToLower();
            var items = Db.MatchResults.Where(o => o.Stade.ToLower().Contains(search)).AsQueryable();

            return Json(new GridModelBuilder<MatchResult>(items, g)
            {
                Key = "Idt", // needed for api select, update, tree, nesting, EF
                GetItem = () => Db.Get<MatchResult>(Convert.ToInt32(g.Key)), // called by the grid.api.update ( edit popupform success js func )
                Map = MapToGridModel
            }.Build());
        }

        //
        // GET: /MatchResultsGrid/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MatchResultsGrid/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MatchResultsGrid/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MatchResultsGrid/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MatchResultsGrid/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MatchResultsGrid/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MatchResultsGrid/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MatchResultsGrid/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
