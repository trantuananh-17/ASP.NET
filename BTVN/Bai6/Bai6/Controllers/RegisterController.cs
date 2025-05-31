using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai6.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(string firstName, string lastName, string email, string password, string city, string gender)
        {
            // Gửi dữ liệu đã nhập trở lại View thông qua ViewData hoặc ViewBag
            ViewData["FirstName"] = firstName;
            ViewData["LastName"] = lastName;
            ViewData["Email"] = email;
            ViewData["Password"] = password;
            ViewData["City"] = city;
            ViewData["Gender"] = gender;

            return View();
        }
    }
}