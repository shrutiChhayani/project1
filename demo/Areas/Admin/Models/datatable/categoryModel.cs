using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }



    }

}