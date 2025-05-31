using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai6.Controllers
{
    public class DisplayTimeController : Controller
    {
        // Trang hiển thị thời gian hiện tại
        public ActionResult TimeDisplay()
        {
            return View();
        }
    }
}