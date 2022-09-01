using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


namespace demo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/Home/Index.cshtml");
        }
        
    }
}