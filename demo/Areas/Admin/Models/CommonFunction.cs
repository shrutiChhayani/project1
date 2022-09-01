using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Models
{
    public class CommonFunction
    {
        public static List<SelectListItem> getlistcategory (bool flgIsNeededSelectOption = true)
        
        {
            List<SelectListItem> loCList = new List<SelectListItem>();
          projectConnectionString loprojectconnection = new projectConnectionString();

            List<listcategory> loCAList = loprojectconnection.getlistcategory();

            if (flgIsNeededSelectOption)
                loCList.Add(new SelectListItem() {  });

            foreach (listcategory loBestTimeVisitmodel in loCAList)
                loCList.Add(new SelectListItem() { Text = loBestTimeVisitmodel.CategoryName, Value = loBestTimeVisitmodel.Categoryid.ToString() });

            return loCList;
           
        }

        //public static List<SelectListItem> getlistuser(bool flgIsNeededSelectOption = true)
        //{
        //    List<SelectListItem> loBestTimeVisit = new List<SelectListItem>();
        //    projectConnectionString loprojectconnection = new projectConnectionString();

        //    List<listcategory> loBestTimeVisitList = loprojectconnection.getlistcategory();

        //    if (flgIsNeededSelectOption)
        //        loBestTimeVisit.Add(new SelectListItem() { Text = "Select Best Time to Visit", Value = "0" });

        //    foreach (listcategory loBestTimeVisitmodel in loBestTimeVisitList)
        //        loBestTimeVisit.Add(new SelectListItem() { Text = loBestTimeVisitmodel.CategoryName, Value = loBestTimeVisitmodel.Categoryid.ToString() });

        //    return loBestTimeVisit;
        //}
    }
}