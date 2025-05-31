using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai4.Controllers
{
    public class TienDienController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate()
        {
            // Lấy thông tin từ form
            int startConsumption = Convert.ToInt32(Request["sc"]); // Số điện cũ
            int endConsumption = Convert.ToInt32(Request["sm"]); // Số điện mới
            string type = Request["loaidien"]; // Loại điện
            string ownerName = Request["ht"]; // Họ tên chủ hộ

            // Kiểm tra tính hợp lệ của dữ liệu
            if (endConsumption < startConsumption)
            {
                ModelState.AddModelError("", "Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.");
                return View("Index");
            }

            int consumption = endConsumption - startConsumption;

            double totalAmount = CalculateElectricityBill(consumption, type);

            // Lưu thông tin vào ViewBag
            ViewBag.TotalAmount = totalAmount;
            ViewBag.OwnerName = ownerName; // Lưu tên chủ hộ
            ViewBag.Type = type; // Lưu loại điện
            ViewBag.Consumption = consumption; // Lưu mức tiêu thụ

            return View("Result");
        }
        private double CalculateElectricityBill(int consumption, string type)
        {
            double amount = 0;

            // Tính tiền điện theo mức tiêu thụ
            if (consumption <= 100)
            {
                amount = consumption * 2000;
            }
            else if (consumption <= 150)
            {
                amount = (100 * 2000) + ((consumption - 100) * 2500);
            }
            else if (consumption <= 200)
            {
                amount = (100 * 2000) + (50 * 2500) + ((consumption - 150) * 3000);
            }
            else
            {
                amount = (100 * 2000) + (50 * 2500) + (50 * 3000) + ((consumption - 200) * 4000);
            }

            // Tính toán theo loại điện sử dụng
            if (type == "Kinh doanh")
            {
                amount *= 1.2; // Tăng 20%
            }
            else if (type == "Sản xuất")
            {
                amount *= 1.3; // Tăng 30%
            }


            return amount;
        }
    }
}