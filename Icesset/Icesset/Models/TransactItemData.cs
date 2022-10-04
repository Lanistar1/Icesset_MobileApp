using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class TransactItemData
    {
        public string item_id { get; set; }
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
    }


    public class LottransactData
    {

        public LottransactData( string store_name, string user_id, string user_name, string qyt_loc_id)
        {
            this.store_name = store_name;
            this.user_id = user_id;
            this.user_name = user_name;
            this.qyt_loc_id = qyt_loc_id;
        }

        public string item_id { get; set; }
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
    }
}
