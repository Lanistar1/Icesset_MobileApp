using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Icesset.Models
{
    public class UserData
    {
        public string accessToken { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public Info info { get; set; }
    }

    public class Info
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long mobilePhone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userStatus { get; set; }
        public string dateCreated { get; set; }

        public string fullname
        {
            get
            {
                return this.firstName + " " + this.lastName;
            }
        }
    }
    public class LoginResponseModel
    {
        public string message { get; set; }
        public UserData data { get; set; }
    }
}
