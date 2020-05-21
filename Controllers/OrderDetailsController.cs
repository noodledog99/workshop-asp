using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using workshop_asp.Data;
using workshop_asp.Utils;

namespace workshop_asp.Controllers
{
    public class OrderDetailsController : Controller
    {
        AppDb db = new AppDb();
        private CartFunc cart = new CartFunc();

        public OrderDetailsController()
        {
            ViewBag.CountCart = cart.CountItemCart();
        }

        // GET: OrderDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderDetailPrview(string id)
        {
            ViewBag.Order_Status = db.Orders.Find(id).OrderStatus;
            var orderDetails = db.OrderDetails.Include(it => it.product).ToList()
                .Where(it => it.OrderId == id)
                .Select(it => it).ToList();
            return View(orderDetails);
        }
    }
}