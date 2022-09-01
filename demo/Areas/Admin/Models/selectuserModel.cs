using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Areas.User.Models
{
    public class selectuserModel
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string CategoryName { get; set; }

    }
}