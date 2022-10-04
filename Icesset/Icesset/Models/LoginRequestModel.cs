using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class LoginRequestModel
    {
        public LoginRequestModel(string pass, string mail)
        {
            password = pass;
            email = mail;
        }
        public string password { get; set; }
        public string email { get; set; }
    }
}
