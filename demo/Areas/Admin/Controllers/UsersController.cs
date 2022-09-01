using AutoMapper;
using demo.Areas.Admin.Models;
using demo.Areas.Admin.Models.datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {

        public ActionResult Index()
        {
            UsersModel loPatientViewModel = new UsersModel()
            {
                loBestTimeVisit = CommonFunction.getlistcategory()
            };
            //ViewBag.Categoryid = loPatientViewModel;
            //ViewData["loBestTimeVisitmodel"] = loPatientViewModel;

            return View("~/Areas/Admin/Views/Users/Index.cshtml", loPatientViewModel);
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            projectConnectionString lodatabase = new projectConnectionString();
            List<UsersModel> loUsersModel = new List<UsersModel>();

            loUsersModel = lodatabase.getusersrecored();
            return View("~/Areas/Admin/Views/Users/_GetUsers.cshtml", loUsersModel);
        }

        [HttpGet]

        public ActionResult EditUsers(int? UserId)
        {
            if(UserId == null)
            {
                return View("~/Areas/Admin/Views/Users/EditUsers.cshtml", new UsersModel());
            }
            projectConnectionString lodatabase = new projectConnectionString();
            UsersModel lousermodel = new UsersModel();
            lousermodel = lodatabase.getusersid(UserId).FirstOrDefault();
            lousermodel.loBestTimeVisit = CommonFunction.getlistcategory();
            UsersModel lousermodels = new UsersModel
            {
                loBestTimeVisit = CommonFunction.getlistcategory()

            };

            foreach (var item in lousermodel.loBestTimeVisit)
            {
                if (lousermodel.CategoryIds != null)
                {
                    // database saved category items
                    var categoryIds = lousermodel.CategoryIds.ToString().Split(',').ToList();

                    var isExistInDatabase = categoryIds.Where(a => a == item.Value).Any();

                    item.Selected = isExistInDatabase;

                }

            }
                return View("~/Areas/Admin/Views/Users/EditUsers.cshtml", lousermodel);

            
        }

        [HttpPost]
        public ActionResult EditUsers(UsersModel lousermodel, List<int> CategoryIds)
        {
            projectConnectionString lodatabase = new projectConnectionString();
            List<UsersModel> loeditModel = new List<UsersModel>();
            lodatabase.updateusers(lousermodel);

            lodatabase.updateusercategorydelete(lousermodel.UserId??0);


            foreach (var itemid in CategoryIds)
            {
                lodatabase.InsertUserCategory(itemid, lousermodel.UserId ?? 0);

            }

            return View("~/Areas/Admin/Views/Users/Index.cshtml");

        }
        [HttpGet]
        public ActionResult deleteuser(int CId)
        {
            projectConnectionString lodatabase = new projectConnectionString();
            lodatabase.userdelete(CId);
            return View("~/Areas/Admin/Views/Users/Index.cshtml");
        }


        [HttpGet]
        public ActionResult AddUser()
        {
            UsersModel loPatientViewModel = new UsersModel
            {
                loBestTimeVisit = CommonFunction.getlistcategory()
            };
            return View("~/Areas/Admin/Views/Users/AddUser.cshtml", loPatientViewModel);

        }



        [HttpPost]
        public ActionResult AddUser(UsersModel usermodel, List<int> Categoryid)
        {


            projectConnectionString lodatabase = new projectConnectionString();
            var returnUserId = lodatabase.insertUser(usermodel.Name, usermodel.Phone, usermodel.Email, usermodel.Password);
            foreach (var itemid in Categoryid)
            {
                lodatabase.InsertUserCategory(itemid, returnUserId);

            }
            return View("~/Areas/Admin/Views/Users/Index.cshtml");

            //return RedirectToAction("Users/Index", id);


        }


    }
}