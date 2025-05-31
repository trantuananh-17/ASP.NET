using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai6.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Calculator()
        {
            return View();
        }

        // POST: Calculator
        [HttpPost]
        public ActionResult Calculator(double number1, double number2, string operation)
        {
            double result = 0;

            // Thực hiện phép toán dựa trên lựa chọn của người dùng
            switch (operation)
            {
                case "add":
                    result = number1 + number2;
                    break;
                case "subtract":
                    result = number1 - number2;
                    break;
                case "multiply":
                    result = number1 * number2;
                    break;
                case "divide":
                    if (number2 != 0)
                        result = number1 / number2;
                    else
                        ViewData["Error"] = "Không thể chia cho 0!";
                    break;
            }

            // Trả kết quả về view
            ViewData["Result"] = result;
            return View();
        }
    }
}