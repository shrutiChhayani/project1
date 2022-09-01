using demo.Areas.Admin.Models;
using demo.Areas.Admin.Models.datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        // GET: Admin/SubCategory

      
        public ActionResult Index()
        {
            subcategoryModel locategoryListViewModel = new subcategoryModel
            {

                loCList = CommonFunction.getlistcategory()

            };

            return View("~/Areas/Admin/Views/SubCategory/Index.cshtml", locategoryListViewModel);
        }
        [HttpGet]
        public ActionResult GetSubCategory()
        {
            projectConnectionString lodatabase = new projectConnectionString();
            List<subcategoryModel> loGetsubcategoryResultViewModel = new List<subcategoryModel>();
            loGetsubcategoryResultViewModel = lodatabase.getsubcategory();
            return View("~/Areas/Admin/Views/SubCategory/_GetSubCategory.cshtml", loGetsubcategoryResultViewModel);
        }

        [HttpGet]
        public ActionResult AddSubCategory()
        {
            subcategoryModel locategoryListViewModel = new subcategoryModel
            {

                loCList = CommonFunction.getlistcategory()

            };

            return View("~/Areas/Admin/Views/SubCategory/AddSubCategory.cshtml", locategoryListViewModel);

        }
       
        [HttpPost]
        public ActionResult AddSubCategoryDetails(subcategoryModel subcategory)
        {


            projectConnectionString lodatabase = new projectConnectionString();

            var id = lodatabase.AddSubCategory(subcategory.SubCategoryName, subcategory.Categoryid.Value);


            return RedirectToAction("Index",id);
         
        }
        [HttpGet]
        
        public ActionResult EditsubCategory(RequestSubCategoryModel loeditmodel)
        {
            projectConnectionString lodatabase = new projectConnectionString();

            List<RequestSubCategoryModel> loRequestSubCategoryModel = new List<RequestSubCategoryModel>();
            List<CategoryModel> loCategoryModel = new List<CategoryModel>();

            loRequestSubCategoryModel = lodatabase.getsubcategoryid(loeditmodel.SubCategoryid);
            loCategoryModel = lodatabase.getcategoryid(loRequestSubCategoryModel[0].Categoryid);
            var subCategoryId = loRequestSubCategoryModel[0].SubCategoryid;
            var subCategoryName = loRequestSubCategoryModel[0].SubCategoryName;
            var categoryId = loCategoryModel[0].Categoryid;
            var categoryName = loCategoryModel[0].CategoryName;
            string[] myNumbers = { subCategoryId.ToString(), subCategoryName, categoryId.ToString(), categoryName };

            return Json(myNumbers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditsubCategory(subcategoryModel losubcategoryModel)
        {
            projectConnectionString lodatabase = new projectConnectionString();

            List<subcategoryModel> loeditModel = new List<subcategoryModel>();


            lodatabase.updatesubcategory(losubcategoryModel);

            return View("losubcategoryModel");

        }


        [HttpGet]
        public ActionResult deletesubcategory(int CId)
        {
            projectConnectionString lodatabase = new projectConnectionString();
            lodatabase.deletesubcategory(CId);
            return View("~/Areas/Admin/Views/SubCategory/Index.cshtml");
        }
    }



}