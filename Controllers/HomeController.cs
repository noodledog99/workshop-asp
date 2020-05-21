using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using workshop_asp.Data;
using workshop_asp.Models;
using workshop_asp.Utils;

namespace workshop_asp.Controllers
{
    public class HomeController : Controller
    {
        private AppDb db = new AppDb();
        private CartFunc cart = new CartFunc();
        public HomeController()
        {
            ViewBag.CountCart = cart.CountItemCart();
        }

        public ActionResult Index()
        {
            var product = db.Products.ToList().Any() ? db.Products.ToList() : new List<Product>();
            ViewBag.CountCart = cart.CountItemCart();
            return View(product);
        }











    }
}