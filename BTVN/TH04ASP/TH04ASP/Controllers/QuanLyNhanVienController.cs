using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH04ASP.Models;

namespace TH04ASP.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        List<NhanVien> list = new List<NhanVien>();
        List<NhanVien> list1 = new List<NhanVien>();
        List<NhanVien> list2 = new List<NhanVien>();

        public QuanLyNhanVienController()
        {
            list.Add(new NhanVien("Nv01", "Tran Tuan ANh", "Ha noi", 15, 200000));
            list.Add(new NhanVien("Nv02", "Tran Tuan ANh", "Ha noi", 27, 250000));
            list.Add(new NhanVien("Nv03", "Tran Tuan ANh", "Ha noi", 18, 250000));
            list.Add(new NhanVien("Nv04", "Tran Tuan ANh", "Ha noi", 26, 190000));
            list.Add(new NhanVien("Nv05", "Tran Tuan ANh", "Ha noi", 20, 170000));
        }

        public ActionResult ViewList()
        {
            foreach (var item in list)
            {
                if (item.songaylam < 20) list1.Add(item);
                if (item.luongngay > 190000) list2.Add(item);
            }
            ViewBag.list1 = list1;
            ViewBag.list2 = list2;

            return View();
        }

        // GET: QuanLyNhanVien
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nhap()
        {
            

            return View(); // hoặc truyền model sẵn có
        }

        [HttpPost]
        public ActionResult Xuat(NhanVien nv)
        {


            return View(nv); // hoặc truyền model sẵn có
        }
    }
}