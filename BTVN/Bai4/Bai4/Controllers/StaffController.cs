using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai4.Models;

namespace Bai4.Controllers
{
    public class StaffController : Controller
    {
        // Danh sách nhân viên (giả lập database)
        private static List<Staff> staffList = new List<Staff>();

        [HttpGet]
        public ActionResult InputImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(HttpPostedFileBase fileImage, string id, string name, DateTime dob, decimal salary)
        {
            if (fileImage != null && fileImage.ContentLength > 0)
            {
                // Lưu file ảnh
                string filename = Path.GetFileName(fileImage.FileName);
                string uploadPath = Server.MapPath("~/Images/") + filename;
                fileImage.SaveAs(uploadPath);

                // Tạo đối tượng Staff và lưu vào danh sách
                Staff staff = new Staff
                {
                    Id = id,
                    Name = name,
                    DateOfBirth = dob,
                    Salary = salary,
                    ImageName = filename
                };
                staffList.Add(staff);

                TempData["Message"] = "Staff information saved successfully!";
            }
            else
            {
                TempData["Message"] = "Please select a valid image!";
            }

            return RedirectToAction("InputImage");
        }

        [HttpGet]
        public ActionResult Open()
        {
            ViewBag.Data = staffList;
            return View("InputImage");
        }
    }
}
