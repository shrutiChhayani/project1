using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo.Areas.Admin.Models
{

    public class EmployeeModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Please enter between 3-50 characters username.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter password")]

        public string Password { get; set; }
       
        public int IsAdmin { get; set; }

        public int? UserId { get; set; }

    }
}