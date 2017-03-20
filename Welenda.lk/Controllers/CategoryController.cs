using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string catergory)
        {
            var execute = new ExecuteQueries();
            var result = execute.GetProductsForCategory(catergory);

            ViewBag.results = result.ElectornicsProducts;
            ViewBag.categoryTitle = result.categoryTitle;

            return View();
        }
    }
}