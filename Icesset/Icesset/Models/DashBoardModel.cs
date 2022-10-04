using Icesset.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Icesset.Models
{

    public class DashBoardData : BaseViewModel
    {
        public int total_transaction { get; set; }
        public List<DashBoardResponse> response { get; set; }

        public string item_id { get; set; }

    }

    public class DashBoardResponse : BaseViewModel
    {
        public int id { get; set; }
        public string transaction_id { get; set; }
        public string transaction_status { get; set; }
        public string transaction_type { get; set; }
        public string waybill_id { get; set; }
        public string transactionDate { get; set; }
        public string dateCreated { get; set; }
        public string created_by_id { get; set; }
        public string created_by_name { get; set; }
        public string exp_delivery_date { get; set; }
        public string receivedBy { get; set; }
        public object stored_in { get; set; }
        public int transaction_item_id { get; set; }
        public string store_id { get; set; }
        public string destination { get; set; }
        public string sent_to_id { get; set; }
        public string sent_to_name { get; set; }
        public object sent_to_phone { get; set; }
        public string courier_name { get; set; }
        public long courier_contact { get; set; }
        public string note { get; set; }
        public string item_name { get; set; }
        public string qyt_loc_id { get; set; }
        public string category { get; set; }
        public string store_name { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public DateTime date_in_loc { get; set; }
        public string description { get; set; }
        public string supplier_name { get; set; }
        public object supplier_phone { get; set; }
        public string supplier_email { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string item_condition { get; set; }
        public string item_status { get; set; }
        public string availability { get; set; }
        public int trans_quantity { get; set; }
        public bool isSelected { get; set; }
        public ObservableCollection<TransactItemData> data { get; set; }

        public DateTime oDate
        {
            get
            {
                var newDate = Convert.ToDateTime(transactionDate);
                return newDate;
            }
            set
            {
                oDate = value;
            }
        }

        public String modifiedDate
        {
            get
            {
                var modDate = changeTime.TimeAgo(oDate);
                return modDate;
            }
            set
            {
                modifiedDate = value;
            }
        }

    }

    public class DashBoardModel
    {
        public string message { get; set; }
        public DashBoardData data { get; set; }
    }





    //public class DashBoardData
    //{
    //    public string transaction_id { get; set; }
    //    public string transaction_status { get; set; }
    //    public string transaction_type { get; set; }
    //    public string waybill_id { get; set; }
    //    public string dateCreated { get; set; }
    //    public string created_by_id { get; set; }
    //    public string created_by_name { get; set; }
    //    public string receivedBy { get; set; }
    //    public string stored_in { get; set; }

    //    [JsonProperty(" transaction_item_id")]
    //    public string TransactionItemId { get; set; }
        //public string item_name { get; set; }
        //public string category { get; set; }
        //public string description { get; set; }
        //public string supplier { get; set; }
        //public string supplierContact { get; set; }
        //public string destination { get; set; }
        //public string sent_to_id { get; set; }
        //public string sent_to_name { get; set; }
        //public string courier_name { get; set; }
        //public string courier_contact { get; set; }
        //public bool isSelected { get; set; }
        //public string note { get; set; }
        //public List<TransactData> data { get; set; }
        //public string item_id { get; set; }
        //public int quantity { get; set; }

        

        //public DateTime oDate
        //{
        //    get
        //    {
        //        var newDate = Convert.ToDateTime(dateCreated);
        //        return newDate;
        //    }
        //    set
        //    {
        //        oDate = value;
        //    }
        //}

        //public String modifiedDate
        //{
        //    get
        //    {
        //        var modDate = changeTime.TimeAgo(oDate);
        //        return modDate;
        //    }
        //    set
        //    {
        //        modifiedDate = value;
        //    }
        //}

    

    //public class DashBoardModel
    //{
    //    public string message { get; set; }
    //    public List<DashBoardData> data { get; set; }
    //}

    public static class changeTime
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("{0} minutes ago", timeSpan.Minutes) :
                    "a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("{0} hours ago", timeSpan.Hours) :
                    "an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("{0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("{0} months ago", timeSpan.Days / 30) :
                    "a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("{0} years ago", timeSpan.Days / 365) :
                    "a year ago";
            }

            return result;
        }

    }
}
