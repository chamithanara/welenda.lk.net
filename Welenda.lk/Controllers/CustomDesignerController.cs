using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class CustomDesignerController : Controller
    {
        // GET: AndumDesigner
        public ActionResult Index(int productId)
        {
            ViewBag.productId = productId;
            return View(ViewBag);
        }

        public JsonResult saveOrder(int productId, string object1, string object2, string object3, string object4)
        {
            var execute = new ExecuteQueries();
            var result = execute.saveOrder();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProducts()
        {
            var execute = new ExecuteQueries();
            var result = execute.getProducts();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSubImages(int prodId)
        {
            var execute = new ExecuteQueries();
            var result = execute.getSubImages(prodId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}