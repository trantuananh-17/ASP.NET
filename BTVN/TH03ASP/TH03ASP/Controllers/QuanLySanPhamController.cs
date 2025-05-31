using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH03ASP.Models;

namespace TH03ASP.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        List<SanPham> list = new List<SanPham>();
        List<SanPham> list1 = new List<SanPham>();
        List<SanPham> list2 = new List<SanPham>();

        public QuanLySanPhamController() {
            list.Add(new SanPham("S01","San pham 1", 10, 100, 0));
            list.Add(new SanPham("S02","San pham 2", 20, 120, 1));
            list.Add(new SanPham("S03","San pham 3", 15, 200, 1));
            list.Add(new SanPham("S04","San pham 4", 30, 150, 0));
            list.Add(new SanPham("S05","San pham 5", 20, 50, 1));
        }

        // GET: QuanLySanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProduct()
        {
            foreach (var item in list)
            {
                if(item.giatien > 100) list1.Add(item);
                if(item.giamgia == 1) list2.Add(item);
            }
            ViewBag.list1 = list1;
            ViewBag.list2 = list2;
            return View();
        }

        public ActionResult Nhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Xuat(SanPham sp)
        {
            return View(sp);
        }
    }
}