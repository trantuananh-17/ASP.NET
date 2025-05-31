using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai4.Controllers
{
    public class UploadFileDemoController : Controller
    {
        [HttpGet]
        public ActionResult InputImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OutputImage(FormCollection fr)
        {
            // Lấy file ảnh từ request
            var f = Request.Files["img1"];
            string name = fr["name"];
            string filename = System.IO.Path.GetFileName(f.FileName);

            // Xác định đường dẫn để lưu file
            string uploadPath = Server.MapPath("~/Images/") + filename;

            // Lưu file lên thư mục Images
            f.SaveAs(uploadPath);

            // Trả về thông tin tên và tên ảnh đã tải lên
            ViewBag.name = name;
            ViewBag.imagename = filename;
            ViewBag.msg = "Upload Image is successful";

            // Quay lại trang InputImage
            return View("InputImage");
        }
    }
}