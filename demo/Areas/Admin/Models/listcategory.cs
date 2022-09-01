using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Models
{
    public class listcategory
    {
        [Key]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> loBestTimeVisit { get; set; }
       


    }
}