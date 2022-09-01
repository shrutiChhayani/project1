using demo.Areas.Admin.Models;
using demo.Areas.Admin.Models.datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/Category/Index.cshtml");
        }
        [HttpGet]
        public ActionResult GetCategory()
        {
            projectConnectionString lodatabase = new projectConnectionString();
            List<CategoryModel> loGetcategoryResultViewModel = new List<CategoryModel>();
            loGetcategoryResultViewModel = lodatabase.getCategory();
             return View("~/Areas/Admin/Views/Category/_GetCategoryList.cshtml", loGetcategoryResultViewModel);
        }
        [HttpGet]
        public string EditCategory(int CId)
        {
            projectConnectionString lodatabase = new projectConnectionString();

            List<CategoryModel> loeditModel = new List<CategoryModel>();

            loeditModel = lodatabase.getcategorybyid(CId);
           
            return loeditModel[0].CategoryName;
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryModel loCategoryModel)
        {
            projectConnectionString lodatabase = new projectConnectionString();

            List<CategoryModel> loeditModel = new List<CategoryModel>();


            lodatabase.updatecategory(loCategoryModel);

            return View("loCategoryModel");

        }


        [HttpGet]
        public ActionResult AddCategory()
        {


         return View("~/Areas/Admin/Views/Category/AddCategory.cshtml");

        }

        [HttpPost]
        public ActionResult AddCategoryDetails(string CategoryName)
        {


           projectConnectionString lodatabase = new projectConnectionString();

             lodatabase.addcategory(CategoryName);
            return View("~/Areas/Admin/Views/Category/Index.cshtml");
            //return View("~/Areas/Admin/Views/Category/Index.cshtml",lodatabase);



        }
        [HttpGet]
        public ActionResult deletecategory(int CId)
        {
            projectConnectionString lodatabase = new projectConnectionString();
            lodatabase.deletecategory(CId);
            return View("~/Areas/Admin/Views/SubCategory/Index.cshtml");
        }



    }
}