using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Icesset.Models
{
    public class StaffData
    {
        public int total_users { get; set; }
        public List<Result> result { get; set; }
        public List<Results> results { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object mobilePhone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userStatus { get; set; }
        public object image_url { get; set; }
        public DateTime dateCreated { get; set; }

        public  string thefullname { get {
                return this.firstName + " " + this.lastName;
            } }

    }


    public class Results
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object mobilePhone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userStatus { get; set; }
        public object image_url { get; set; }
        public DateTime dateCreated { get; set; }

    }

    public class StaffModel
    {
        public string message { get; set; }
        public StaffData data { get; set; }
    }







    //public class StaffData
    //{
    //    public string user_id { get; set; }
    //    public string firstName { get; set; }
    //    public string lastName { get; set; }
    //    public object mobilePhone { get; set; }
    //    public string email { get; set; }
    //    public string password { get; set; }
    //    public string role { get; set; }
    //    public string userStatus { get; set; }
    //    public DateTime dateCreated { get; set; }

    //    public static implicit operator ObservableCollection<object>(StaffData v)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

//    public class StaffModel
//    {

//        public string message { get; set; }
//        public ObservableCollection<StaffData> data { get; set; }
//    }
}
