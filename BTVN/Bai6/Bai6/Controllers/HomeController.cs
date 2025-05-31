using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai6.Controllers
{
    public class HomeController : Controller
    {
        // Trang Giới thiệu
        public ActionResult Introduction()
        {
            return View();
        }

        // Trang Tuyển sinh
        public ActionResult Admission()
        {
            return View();
        }

        // Trang Đào tạo
        public ActionResult Training()
        {
            return View();
        }

    }
}