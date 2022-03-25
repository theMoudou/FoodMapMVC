using FoodMapMVC.Helpers;
using FoodMapMVC.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodMapMVC.Controllers
{
    public class LoginController : Controller
    {
        private AccountManager _mgr = new AccountManager();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (LoginHelper.IsLogined())
                return RedirectToAction("Welcome", "Login");

            string account = collection["account"];
            string pwd = collection["pwd"];

            var acc = this._mgr.GetAccount(account);
            if (acc?.PWD == pwd)
            {
                LoginHelper.Login(acc.Account1, acc.ID);
                return RedirectToAction("Welcome", "Login");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            LoginHelper.Logout();
            return View("Index");
        }  

        public ActionResult Welcome()
        {
            if(!LoginHelper.IsLogined())
                return RedirectToAction("Index", "Login");

            return View();
        }
    }
}