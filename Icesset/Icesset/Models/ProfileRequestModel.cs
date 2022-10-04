using Icesset.Helps;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Icesset.Models
{


    //public class profilerequestmodel
    //{
    //    public string userid { get; set; }
    //    public string currentpassword { get; set; }
    //    public string newpassword { get; set; }
    //}



    public class ProfileRequestModel
    {

        public ProfileRequestModel(string current, string change, string user)
        {
            //string userId = Constant.user_id;
            currentPassword = current;
            newPassword = change;
            userId = user;
        }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
        public string userId { get; set; }

    }
}
