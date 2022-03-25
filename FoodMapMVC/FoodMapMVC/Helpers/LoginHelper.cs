using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace FoodMapMVC.Helpers
{
    public class LoginHelper
    {
        public static bool IsLogined()
        {
            return HttpContext.Current.Request.IsAuthenticated;
        }

        public static void Login(string account, Guid userID)
        {
            bool isPersistance = false;
            TimeSpan timeout = new TimeSpan(3, 0, 0);

            FormsAuthentication.SetAuthCookie(account, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
            (
                1,                  // 版本
                account,            // 帳號
                DateTime.Now,       // 發證時間
                DateTime.Now.Add(timeout), // 逾期時間
                isPersistance,
                userID.ToString()              // UserData (目前放 id)
            );

            // 設定目前登入者至 Cookie
            string encryptedText = FormsAuthentication.Encrypt(ticket);
            HttpCookie loginCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedText);
            loginCookie.HttpOnly = true;
            loginCookie.Expires = DateTime.Now.Add(timeout);
            HttpContext.Current.Response.Cookies.Add(loginCookie);

            // 設定目前登入者至 Current User
            FormsIdentity identity = new FormsIdentity(ticket);
            GenericPrincipal gp = new GenericPrincipal(identity, new string[] { });
            HttpContext.Current.User = gp;
        }

        public static void Logout()
        {
            var loginCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (loginCookie != null)
            {
                loginCookie.Expires = DateTime.Now.AddHours(-24);
                loginCookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Add(loginCookie);
            }
            FormsAuthentication.SignOut();
        }
    }
}