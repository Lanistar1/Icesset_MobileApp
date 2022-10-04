using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{

    public class StoreData
    {
        public int total_stores { get; set; }
        public List<StoreResult> result { get; set; }
    }

    public class StoreResult
    {
        public int id { get; set; }
        public string store_id { get; set; }
        public string store_name { get; set; }
        public string dateAdded { get; set; }
    }

    public class PopupModel
    {
        public string message { get; set; }
        public StoreData data { get; set; }
    }


}
