using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.Web.Models
{
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public URole Level { get; set; }
        public string Country { get; set; }
    }
}