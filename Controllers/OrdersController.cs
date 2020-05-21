using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using workshop_asp.Data;
using workshop_asp.Models;
using workshop_asp.Utils;

namespace workshop_asp.Controllers
{
    public class OrdersController : Controller
    {
        AppDb db = new AppDb();
        public CartFunc cart = new CartFunc();
        public List<OrderDetail> OrderDetail = new List<OrderDetail>();
        public Order Order = new Order();
        public Product Product = new Product();

        public OrdersController()
        {
            ViewBag.CountCart = cart.CountItemCart();
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderHistory()
        {
            var orders = db.Orders.ToList()
                .Where(it => it.UserId == User.Identity.GetUserId())
                .Select(it => it).ToList();
            return View(orders);
        }

        public ActionResult ShoppingCart()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(cart.GetCartDetail());
        }

        [HttpPost]
        public ActionResult ShoppingCart(CartDetail cartDetail)
        {
            var id = Guid.NewGuid().ToString();
            var prosucts = db.Products.ToList();
            if (cart.GetCartDetail().Any())
            {
                Order.OrderId = id;
                Order.FirstName = cartDetail.FirstName;
                Order.LastName = cartDetail.LastName;
                Order.Address = cartDetail.Address;
                Order.City = cartDetail.City;
                Order.Country = cartDetail.Country;
                Order.Province = cartDetail.Province;
                Order.PostalCode = cartDetail.PostalCode;
                Order.Phone = cartDetail.Phone;
                Order.OrderDate = DateTime.Now;
                Order.OrderStatus = "Pendding";
                Order.Total = cart.GetCartDetail().Sum(it => it.SubTotal);
                Order.UserId = User.Identity.GetUserId();

                db.Orders.Add(Order);

                foreach (var item in cart.GetCartDetail())
                {
                    OrderDetail.Add(new OrderDetail
                    {
                        OrderId = id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        SubTotal = item.SubTotal,
                    });

                    var ent = db.Set<Product>().Find(item.ProductId.Value);
                    ent.UnitsInStock = prosucts.FirstOrDefault(it => it.ProductId == item.ProductId).UnitsInStock - item.Quantity;
                    ent.UnitsOnOrder = prosucts.FirstOrDefault(it => it.ProductId == item.ProductId).UnitsInStock + item.Quantity;
                    db.SaveChanges();
                }

                db.OrderDetails.AddRange(OrderDetail);
                db.SaveChanges();
                cart.ClearCart();
                ViewBag.CountCart = cart.CountItemCart();
                var orders = db.Orders.ToList()
                     .Where(it => it.UserId == User.Identity.GetUserId())
                     .Select(it => it).ToList();

                return RedirectToAction("OrderHistory", orders);
            }
            return View(cart.GetCartDetail());
        }
    }
}