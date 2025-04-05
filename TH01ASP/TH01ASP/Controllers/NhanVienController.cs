using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH01ASP.Models;

namespace TH01ASP.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nhap(NhanVien nv)
        {
            ViewBag.firstname = nv.firstname;
            ViewBag.lastname = nv.lastname;
            ViewBag.gender = nv.gioitinh;
            ViewBag.month = nv.thangsinh;
            ViewBag.year = nv.namsinh;
            ViewBag.luong = nv.luong;
            ViewBag.hobie = nv.sothich;
            ViewBag.ngaylv = nv.ngaylv;
            ViewBag.luongthuc = nv.luongthuc;
            return View();
        }
    }
}