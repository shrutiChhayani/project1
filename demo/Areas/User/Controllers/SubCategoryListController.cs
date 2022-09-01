using demo.Areas.Admin.Models;
using demo.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.User.Controllers
{
    public class SubCategoryListController : Controller
    {
        // GET: User/SubCategory
        public ActionResult Index()
        {

            return View("~/Areas/User/Views/SubCategoryList/Index.cshtml");
        }
        [HttpGet]
        public ActionResult GetSubCategory()
        {
            projectConnectionString lodatabase = new projectConnectionString();
            UserSessionModel lousersessionmodel = (UserSessionModel)Session["user_session"];
            subcategorylist losubcategorylist = new subcategorylist();
            var abc = lodatabase.getsublistbyuid(lousersessionmodel.UserId ?? 0);
            return View("~/Areas/User/Views/SubCategoryList/_GetSubCategory.cshtml", abc);
        }
    }
}