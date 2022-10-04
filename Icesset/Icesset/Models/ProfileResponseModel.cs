using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class success
    {
        public string userId { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }

    public class successModel
    {
        public string message { get; set; }
        public success data { get; set; }
    }
}
