using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Models.datatable
{
    public class RequestSubCategoryModel
    {
        [Key]
        public int SubCategoryid { get; set; }
        public string SubCategoryName { get; set; }
        public int Categoryid { get; set; }

    }
}