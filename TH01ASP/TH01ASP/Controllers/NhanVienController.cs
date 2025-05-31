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
        List<NhanVien> li = new List<NhanVien>();
        List<NhanVien> li1 = new List<NhanVien>();
        List<NhanVien> li2 = new List<NhanVien>();

        public NhanVienController() {
            li.Add(new NhanVien("tran", "anh", "nam", "12", "2004", "Sport", 2000, 24));
            li.Add(new NhanVien("tran", "kim", "nu", "12", "2004", "Sport", 2000, 24));
            li.Add(new NhanVien("anh", "anh", "nam", "12", "2004", "Sport", 2000, 24));
            li.Add(new NhanVien("cuong", "anh", "nu", "12", "2004", "Sport", 2000, 24));
            li.Add(new NhanVien("hoang", "anh", "nam", "12", "2004", "Sport", 2000, 24));
            li.Add(new NhanVien("kim", "anh", "nu", "12", "2004", "Sport", 2000, 24));
        }

        public ActionResult XuatList()
        {
            foreach(var item in li)
            {
                if (item.luong > 300) li1.Add(item);
            }
            foreach(var item in li)
            {
                if(item.gioitinh == "nam") li2.Add(item);
            }
            ViewBag.li1 = li1;
            ViewBag.li2 = li2;
            return View();
        }

        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nhap(NhanVien nv)
        {

            return View();
        }

        public ActionResult Xuat(NhanVien nv)
        {
            ViewBag.firstname = nv.firstname;
            ViewBag.lastname = nv.lastname;
            ViewBag.gioitinh = nv.gioitinh;
            ViewBag.thangsinh = nv.thangsinh;
            ViewBag.namsinh = nv.namsinh;
            ViewBag.luong = nv.luong;
            ViewBag.sothich = nv.sothich;
            ViewBag.ngaylv = nv.ngaylv;
            ViewBag.luongthuc = nv.luongthuc;
            return View();
        }
    }
}