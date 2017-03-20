using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welenda.lk.Database;

namespace Welenda.lk.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        
    }
}