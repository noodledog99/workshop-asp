using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
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
            return View(product);
        }

        public ActionResult CategoryKeyCapsView()
        {
            var products = db.Products.Include(o => o.CategoryId).Where(it => it.category.CategoryName == "Keycaps").Select(it => it).ToList();
            return PartialView(products);
        }

        public ActionResult CategoryKeyboardsView()
        {
            var products = db.Products.Include(o => o.CategoryId).Where(it => it.category.CategoryName == "Keyboard").Select(it => it).ToList();
            return PartialView(products);
        }
    }
}