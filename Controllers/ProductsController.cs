using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using workshop_asp.Data;
using workshop_asp.Models;
using workshop_asp.Utils;

namespace workshop_asp.Controllers
{
    public class ProductsController : Controller
    {
        private AppDb db = new AppDb();
        private Product modelProduct = new Product();
        private CartFunc cart = new CartFunc();

        public ProductsController()
        {
            ViewBag.CountCart = cart.CountItemCart();
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"D:\workshop-asp\My First Project-fc65b82dffda.json");
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product modelProduct, HttpPostedFileBase ImagePath)
        {
            modelProduct.ImagePath = ImagePath != null ? UploadFile("storage-image-test", ImagePath) : "";
            modelProduct.Created_at = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Products.Add(modelProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", modelProduct.CategoryId);
            return View(modelProduct);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,ImagePath,UnitPrice,UnitsInStock,UnitsOnOrder,Created_at,Updated_at,Deleted_at")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                var objectName = product.ImagePath.Split(new[] { "/", "%", "2F", "?" }, StringSplitOptions.None);
                DeleteObject("storage-image-test", $"{objectName[9]}/{objectName[11]}");
                product.ImagePath = UploadFile("storage-image-test", ImageFile);
            }

            if (ModelState.IsValid)
            {
                product.Updated_at = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductView(int id)
        {
            var product = db.Products.FirstOrDefault(it => it.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult ProductView(int ProductId, int Qty, string UnitPrice)
        {
            var item = cart.GetCartDetail().ToList().FirstOrDefault(it => it.ProductId == ProductId);
            var products = db.Products.ToList();
            if (item != null)
            {
                item.Quantity += Qty;
                item.SubTotal += Convert.ToDecimal(UnitPrice) * Qty;
            }
            else
            {
                var p = products.FirstOrDefault(it => it.ProductId == ProductId);
                cart.AddItem(ProductId, p, Qty, UnitPrice);
            }
            ViewBag.CountCart = cart.CountItemCart();
            var product = products.FirstOrDefault(it => it.ProductId == ProductId);
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private string UploadFile(string bucketName, HttpPostedFileBase localPath)
        {
            var time = (int)(DateTime.UtcNow.ToLocalTime() - new DateTime(2020, 1, 1)).TotalSeconds;
            var objectName = $"test/{time.ToString()}.png";
            var storage = StorageClient.Create();
            storage.UploadObject(bucketName, objectName, null, localPath.InputStream);
            var storageObject = storage.GetObject(bucketName, objectName);
            return storageObject.MediaLink;
        }

        private void DeleteObject(string bucketName, string objectName)
        {
            var storage = StorageClient.Create();
            storage.DeleteObject(bucketName, objectName, null);
            Console.WriteLine($"Deleted {objectName}.");
        }
    }
}
