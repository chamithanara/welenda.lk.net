using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index(string id)
        {
            var execute = new ExecuteQueries();
            var result = execute.GetItemsFromCart(id);

            ViewBag.productsList = result.cartProductList;
            return View();
        }
    }
}