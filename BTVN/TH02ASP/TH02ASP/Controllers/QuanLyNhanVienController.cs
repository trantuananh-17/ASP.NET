using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH02ASP.Models;

namespace TH02ASP.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        List<NhanVien> list = new List<NhanVien>();
        List<NhanVien> list1 = new List<NhanVien>();
        List<NhanVien> list2 = new List<NhanVien>();

        public QuanLyNhanVienController()
        {
            list.Add(new NhanVien("Nv01", "Nguyen Van Anh", "Ha Noi", 15, 200000));
            list.Add(new NhanVien("Nv02", "Le Thu Ha", "Hai Phong", 27, 250000));
            list.Add(new NhanVien("Nv03", "Nguyen Van Hoang", "Ha Noi", 18, 250000));
            list.Add(new NhanVien("Nv04", "Tran Thu Huong", "Hai Phong", 25, 190000));
            list.Add(new NhanVien("Nv05", "Ngo Phuong Thao", "Quang Ninh", 20, 180000));
        }

        public ActionResult XuatList()
        {
            foreach (var item in list)
            {
                if (item.songaylam < 20) list1.Add(item);
            }
            foreach (var item in list)
            {
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
            return View();
        }


        public ActionResult Xuat(NhanVien nv)
        {
            return View(nv);
        }
    }
}