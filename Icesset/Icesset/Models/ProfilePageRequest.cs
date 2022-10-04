using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class ProfilePageRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobilePhone { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }

}
