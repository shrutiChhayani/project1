using demo.Areas.User.Models;
using demo.Areas.Admin.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.User
{
    public class UserRecoredController : Controller
    {
        [HttpGet]
        public ActionResult Index(int?id)
        {
            //TempData["data"] = "id";
            UserSessionModel lousersessionmodel = (UserSessionModel)Session["user_session"];

            //getusercategoryModel logetusercategoryModel = new getusercategoryModel();

            //int liUserID = lousersessionmodel.UserId??0;



            //projectConnectionString lodatabase = new projectConnectionString();

            //if (liUserID > 0)
            //{
            //    logetusercategoryModel = lodatabase.getusercategorybyid(liUserID);
            //}

                return View("~/Areas/User/Views/UserRecored/Index.cshtml");
            //return View("~/Areas/User/Views/UserRecored/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetCategory()
        {
            projectConnectionString lodatabase = new projectConnectionString();
            UserSessionModel lousersessionmodel = (UserSessionModel)Session["user_session"];
            getusersubcategoryModel logetusercategoryModel = new getusersubcategoryModel();
            var abc = lodatabase.getclistbyuid(lousersessionmodel.UserId ?? 0);
            return View("~/Areas/User/Views/UserRecored/_GetCategoryList.cshtml",abc);
        }
       
    }
}