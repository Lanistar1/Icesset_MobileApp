using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class ItemsDetail
    {
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public string qyt_loc_id { get; set; }
        public string store_id { get; set; }
        public string store_name { get; set; }
        public int quantity { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }

    }
    public class ItemDetailModel
    {
        public string message { get; set; }
        public List<ItemsDetail> data { get; set; }
    }
}
