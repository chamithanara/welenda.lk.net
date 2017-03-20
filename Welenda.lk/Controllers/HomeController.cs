using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetHotProducts()
        {
            var execute = new ExecuteQueries();
            var result = execute.GetHotProducts();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetElectronicsProducts()
        {
            var execute = new ExecuteQueries();
            var result = execute.GetElectronicsProducts();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetToyProducts()
        {
            var execute = new ExecuteQueries();
            var result = execute.GetToyProducts();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}