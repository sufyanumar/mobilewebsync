using System;
using System.Collections.Generic;
using System.Text;

namespace ApexChat.Models
{
    public class Credentials
    {
        public string Company { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Credentials(string cmpy, string user, string pass)
        {
            Company = cmpy;
            UserName = user;
            Password = pass;
        }
    }
}
