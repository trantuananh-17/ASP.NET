using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai4.Models;

namespace Bai4.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorModel model)
        {
            if (model.Operation == "Add")
                model.Result = model.Number1 + model.Number2;
            else if (model.Operation == "Subtract")
                model.Result = model.Number1 - model.Number2;
            else if (model.Operation == "Multiply")
                model.Result = model.Number1 * model.Number2;
            else if (model.Operation == "Divide" && model.Number2 != 0)
                model.Result = model.Number1 / model.Number2;
            else
                model.Result = 0;

            return View("Result", model); // Redirect to the result view
        }
    }


}