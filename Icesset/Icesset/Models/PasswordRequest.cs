using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class PasswordRequest
    {
        public PasswordRequest( string mail)
        {
            email = mail;
            redirectUrl = "https://icesset.netlify.app/reset-password";
        }
        public string email { get; set; }
        public string redirectUrl { get; set; }
    }
}

