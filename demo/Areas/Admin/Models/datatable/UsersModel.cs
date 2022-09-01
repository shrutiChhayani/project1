using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Areas.Admin.Models.datatable
{
    [Table("Users")]
    public class UsersModel
    {
      
    [Key]
        public int? UserId { get; set; }
        
        public string Name { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public List<int?> Categoryid { get; set; }
        public string CategoryIds { get; set; }


        public string CategoryName { get; set; }

        [NotMapped]
        public List<SelectListItem> loBestTimeVisit { get; set; }
    }

   
    //public class usercategorydetails
    //{
    //    public int? UserId { get; set; }

    //    public string Name { get; set; }
    //    public int? Phone { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }

    //    public int? Categoryid { get; set; }
    //    [NotMapped]
    //    public List<SelectListItem> loBestTimeVisit { get; set; }
    //}
}