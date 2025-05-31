using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ObjectsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Objects
        public ActionResult XemDanhSach(decimal? tim, string ten, decimal? giatu, decimal? giaden, string sx)
        {
            var products = db.Products.Include(p => p.Catalogy);
            ViewBag.sapxeptheoten = sx == "name_asc" ? "name_desc" : "name_asc";

            switch (sx)
            {
                case "name_asc":
                    products = products.OrderBy(p => p.ProductName);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductID);
                    break;
            }


            if (tim.HasValue)
            {
                products = products.Where(p => p.Price > tim.Value);
            }

            // Tìm theo tên (không phân biệt chữ hoa thường)
            if (!string.IsNullOrEmpty(ten))
            {
                products = products.Where(p => p.ProductName.ToLower().Contains(ten.ToLower()));
            }

            // Lọc theo giá từ
            if (giatu.HasValue)
            {
                products = products.Where(p => p.Price >= giatu.Value);
            }

            // Lọc theo giá đến
            if (giaden.HasValue)
            {
                products = products.Where(p => p.Price <= giaden.Value);
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
        public ActionResult ThemDuLieu()
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDuLieu([Bind(Include = "ProductID,ProductName,Description,PurchasePrice,Price,Quantity,Vintage,CatalogyID,Image,Region")] Product product)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["FileName"];
                if (f != null && f.ContentLength > 0)
                {
                    string tenFile = Path.GetFileName(f.FileName);
                    string duongDan = Path.Combine(Server.MapPath("~/Images/"), tenFile);
                    f.SaveAs(duongDan);
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
                var b = db.Products.AsNoTracking().SingleOrDefault(p => p.ProductID == product.ProductID);
                var f = Request.Files["FileName"];
                if (f != null && f.ContentLength > 0)
                {
                    string tenFile = Path.GetFileName(f.FileName);
                    string duongDan = Path.Combine(Server.MapPath("~/Images/"), tenFile);
                    f.SaveAs(duongDan);
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
        public ActionResult XoaDuLieu(int? id)
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
        [HttpPost, ActionName("XoaDuLieu")]
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
