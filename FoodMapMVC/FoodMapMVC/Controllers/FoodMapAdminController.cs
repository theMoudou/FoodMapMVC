using FoodMapMVC.Managers;
using FoodMapMVC.Models;
using FoodMapMVC.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodMapMVC.Controllers
{
    [Authorize]
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
            if (id.HasValue)
            {
                var model = this._mgr.GetAdminMap(id.Value);
                return View(model);
            }
            else
            {
                MapContent model = new MapContent()
                {
                    Longitude = 23.5,
                    Latitude = 123.8
                };
                return View(model);
            }
        }

        // POST: FoodMapAdmin/Create
        [HttpPost]
        public ActionResult Create(FoodMapViewModel vModel)
        {
            try
            {
                var model = new MapContent()
                {
                    Title = vModel.Title,
                    Body = vModel.Body,
                    CoverImage = "/FileDownload/MapContent/R.jpg",
                    Latitude = vModel.Latitude,
                    Longitude = vModel.Longitude,
                    IsEnable = vModel.IsEnable
                };
                this._mgr.CreateFoodMap(model);
                return RedirectToAction("Details", new { id = model.ID });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: FoodMapAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FoodMapViewModel vModel)
        {
            try
            {
                var model = new MapContent()
                {
                    ID = vModel.ID,
                    Title = vModel.Title,
                    Body = vModel.Body,
                    CoverImage = "/FileDownload/MapContent/R.jpg",
                    Latitude = vModel.Latitude,
                    Longitude = vModel.Longitude,
                    IsEnable = vModel.IsEnable
                };
                this._mgr.EditFoodMap(model);

                return RedirectToAction("Details", new { id = model.ID });
            }
            catch
            {
                return View();
            }
        }

        // POST: FoodMapAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                this._mgr.DeleteFoodMap(id);
                this.TempData["AlertMsg"] = "刪除成功";

                var list = this._mgr.GetAdminMapList();
                return View("Index", list);
            }
            catch
            {
                return View();
            }
        }
    }
}
