using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Models.datatable
{
    //[Table("SubCategory")]
    public class subcategoryModel
    {
     
       
         [Key]
        public int SubCategoryid { get; set; }
        public string SubCategoryName { get; set; }
        public int? Categoryid { get; set; }
        public string CategoryName { get; set; }
        [NotMapped]
        public List<SelectListItem> loCList { get; set; }



    }

}
