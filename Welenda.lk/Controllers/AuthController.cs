using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult CreateNewUser(string email, string password, string name)
        {
            var execute = new ExecuteQueries();
            var result = execute.CreateUser(email, password, name);

            return Json(result, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult LoginUser(string email, string password)
        {
            var execute = new ExecuteQueries();
            var result = execute.LoginUser(email, password);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}