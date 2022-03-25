using FoodMapMVC.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodMapMVC.Controllers
{
    public class FoodMapAdminController : Controller
    {
        private FoodMapManager _mgr = new FoodMapManager();

        // GET: FoodMapAdmin
        public ActionResult Index()
        {
            var list = this._mgr.GetAdminMapList();
            return View(list);
        }

        // GET: FoodMapAdmin/Details/5
        public ActionResult Details(Guid? id)
        {
            return View();
        }

        // POST: FoodMapAdmin/Create
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

        // POST: FoodMapAdmin/Edit/5
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

        // POST: FoodMapAdmin/Delete/5
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
