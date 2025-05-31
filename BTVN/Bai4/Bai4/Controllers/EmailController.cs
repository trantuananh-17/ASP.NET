using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai4.Models;

namespace Bai4.Controllers
{
    public class EmailController : Controller
    {
        // Danh sách email tạm thời lưu trên server
        private static List<EmailInfo> emailList = new List<EmailInfo>();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string from, string to, string subject, string notes, IEnumerable<HttpPostedFileBase> attachments)
        {
            try
            {
                // Tạo một đối tượng EmailInfo để lưu thông tin
                var email = new EmailInfo
                {
                    From = from,
                    To = to,
                    Subject = subject,
                    Notes = notes,
                    Attachments = new List<string>()
                };

                // Lưu file đính kèm vào thư mục trên server
                string uploadPath = Server.MapPath("~/Files/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                if (attachments != null)
                {
                    foreach (var file in attachments)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            file.SaveAs(Path.Combine(uploadPath, fileName));
                            email.Attachments.Add(fileName);
                        }
                    }
                }

                // Lưu email vào danh sách
                emailList.Add(email);
                TempData["Message"] = "Files sent successfully!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error: " + ex.Message;
            }

            return RedirectToAction("SendEmail");
        }
    }
}