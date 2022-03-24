using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ALPHA_DGS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexviewMORE()
        {
            ViewBag.Message = "Hello world";
            dynamic mymodel = new ExpandoObject();
            mymodel.
        }

        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
