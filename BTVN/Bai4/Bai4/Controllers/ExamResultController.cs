using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai4.Models;

namespace Bai4.Controllers
{
    public class ExamResultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(ExamResult model)
        {
            double regionBonus = model.Region == "A" ? 1 : model.Region == "B" ? 2 : 3;
            double policyBonus = model.IsPolicyFamily ? 1 : 0;

            model.TotalScore = model.MathScore + model.PhysicsScore + model.ChemistryScore + regionBonus + policyBonus;

            if (model.TotalScore >= 20)
                model.Result = "Đỗ đại học";
            else if (model.TotalScore >= 15)
                model.Result = "Đỗ cao đẳng";
            else if (model.TotalScore >= 10)
                model.Result = "Đỗ trung cấp";
            else
                model.Result = "Thi trượt";

            return View("ExamResult", model);
        }
    }

}