using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(string productdId)
        {
            var execute = new ExecuteQueries();
            var result = execute.GetProductDetails(productdId);
            var prodInfo = execute.GetProductInfo(productdId);
            ViewBag.result = result.result;
            ViewBag.prodInfo = prodInfo.result;

            return View();
        }
    }
}