
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using demo.Areas.Admin.Models;
using demo.Areas.Admin.Models.datatable;
using demo.Areas.User.Models;

namespace demo.Controllers
{
    public class EmployeeController : Controller
    {

        UserSessionModel moUserSessionModel = null;
        public ActionResult Index()
        {
            EmployeeModel loginviewModel = new EmployeeModel();
            if (Request.Cookies["dbcontextUserName"] != null && Request.Cookies["dbcontextPassword"] != null)
            {
                loginviewModel.Name = Request.Cookies["dbcontextUserName"].Value;
                loginviewModel.Password = Request.Cookies["dbcontextPassword"].Value;

            }
            else
            {
                loginviewModel.Name = "";
                loginviewModel.Password = "";
            }
            ViewData["MessageText"] = TempData["MessageText"];
            TempData["MessageText"] = "";

            return View("~/Areas/Admin/Views/Employee/Index.cshtml", loginviewModel);

        }
        [HttpPost]
        public ActionResult Login(EmployeeModel foLoginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (validateUserByUsername(foLoginViewModel) == true)
                {

                    if (moUserSessionModel.IsAdmin == 1)
                    {
                        return RedirectToAction("Index", "Home");


                    }
                    else
                    {

                        return RedirectToAction("Index","UserRecored", new { @id = moUserSessionModel.UserId } );

                    }
                }
                else
                {
                    ViewData["ErrorText"] = "Invalid Username/Password";
                    return View("~/Areas/Admin/Views/Employee/Index.cshtml", foLoginViewModel);
                }
            }
            else
            {
                return View("~/Areas/Users/Views/Employee/Index.cshtml", foLoginViewModel);

            }
        }

        [HttpGet]
        public bool validateUserByUsername(EmployeeModel foLoginViewModel)
        {
            bool lbIsValid = false;
            projectConnectionString loSalesRepDataContext = new projectConnectionString();
            validateusermodel lovalidateusermodel = loSalesRepDataContext.GetUserByUserName(foLoginViewModel.Name);

            if (lovalidateusermodel != null && lovalidateusermodel.Password != null && lovalidateusermodel.Password == foLoginViewModel.Password)
            {
                lbIsValid = true;
                moUserSessionModel = new UserSessionModel
                {

                    Name = lovalidateusermodel.Name,
                    Password = lovalidateusermodel.Password,
                    IsAdmin = lovalidateusermodel.IsAdmin,
                    UserId=lovalidateusermodel.UserId,
                };

                Session["user_session"] = moUserSessionModel;

            }
            return lbIsValid;
        }
        [HttpGet]
      public ActionResult Logout()
        {
            Session["user_session"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Employee");
        }



    }
}
