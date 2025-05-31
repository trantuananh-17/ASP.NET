using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ObjectsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Objects
        public ActionResult XemDanhSach(string tim)
        {
            var products = db.Products.Include(p => p.Catalogy);
            if (!string.IsNullOrEmpty(tim))
            {
                decimal tim1 = 0;
                if(decimal.TryParse(tim, out tim1))
                {

                    products = products.Where(p => p.Price > tim1);
                }
            }
            return View(products.ToList());
        }

        // GET: Objects/Details/5
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

        // GET: Objects/Create
        public ActionResult Create()
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Description,PurchasePrice,Price,Quantity,Vintage,CatalogyID,Image,Region")] Product product)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["FileName"];
                if (f != null && f.ContentLength > 0)
                {
                    string tenFile = Path.GetFileName(f.FileName);
                    string duongdan = Path.Combine(Server.MapPath("~/Images/"), tenFile);
                    f.SaveAs(duongdan);
                    product.Image = tenFile;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("XemDanhSach");
            }

            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName", product.CatalogyID);
            return View(product);
        }

        // GET: Objects/Edit/5
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
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName", product.CatalogyID);
            return View(product);
        }

        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Description,PurchasePrice,Price,Quantity,Vintage,CatalogyID,Image,Region")] Product product)
        {
            if (ModelState.IsValid)
            {
                var b = db.Products.AsNoTracking().SingleOrDefault( s => s.ProductID == product.ProductID );
                var f = Request.Files["FileName"];
                if (f != null && f.ContentLength > 0)
                {
                    string tenFile = Path.GetFileName(f.FileName);
                    string duongdan = Path.Combine(Server.MapPath("~/Images/"), tenFile);
                    f.SaveAs(duongdan);
                    product.Image = tenFile;
                }
                else
                {
                    product.Image = b.Image;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("XemDanhSach");
            }
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName", product.CatalogyID);
            return View(product);
        }

        // GET: Objects/Delete/5
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

        // POST: Objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            try
            {
                db.Products.Remove(product);
                db.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Không thể xóa sản phẩm này. Có thể sản phẩm đang được sử dụng ở nơi khác.";
            }
            return RedirectToAction("XemDanhSach");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
