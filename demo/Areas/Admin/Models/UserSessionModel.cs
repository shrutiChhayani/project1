﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Areas.Admin.Models
{
    public class UserSessionModel
    {


        public string Name { get; set; }

        public string Password { get; set; }

        public int? IsAdmin { get; set; }

        public int? UserId { get; set; }


    }
}