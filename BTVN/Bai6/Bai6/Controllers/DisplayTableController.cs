using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai6.Controllers
{
    public class DisplayTableController : Controller
    {
        // GET: DisplayTable
        public ActionResult DisplayTable()
        {
            // Tạo một danh sách các đối tượng với Name và Value
            var data = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Hanoi", "Vietnam"),
            new KeyValuePair<string, string>("Tokyo", "Japan"),
            new KeyValuePair<string, string>("London", "UK")
        };

            // Trả về View với dữ liệu
            return View(data);
        }
    }
}