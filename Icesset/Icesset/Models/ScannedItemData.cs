using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{

    public class ScannedItemData
    {
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string description { get; set; }
        public string qyt_loc_id { get; set; }
        public string store_name { get; set; }
        public int quantity { get; set; }
        public int trans_quantity { get; set; }
    }


}
