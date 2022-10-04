using System;
using System.Collections.Generic;


namespace Icesset.Models
{
    public class ProfileData
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobilePhone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userStatus { get; set; }
        public string dateCreated { get; set; }

    }
    //public class ProfileModel
    //{
    //    public string message { get; set; }
    //    public List<ProfileData> data { get; set; }
    //}

}
