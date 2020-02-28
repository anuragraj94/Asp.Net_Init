using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMVC.Models
{
    public class logIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class DataModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}