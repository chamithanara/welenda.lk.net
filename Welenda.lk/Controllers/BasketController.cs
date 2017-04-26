using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index(string id)
        {
            var execute = new ExecuteQueries();
            var result = execute.GetItemsFromCart(id);

            ViewBag.productsList = result.cartProductList;
            return View();
        }

        public JsonResult AddItemToBasket(int productId, int quantity, string userId, string name)
        {
            var execute = new ExecuteQueries();
            var result = execute.ProductAddToCart(productId, quantity, userId, name);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCartItemCount(string userId, string name)
        {
            var execute = new ExecuteQueries();
            var result = execute.GetCartItemCount(userId, name);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}