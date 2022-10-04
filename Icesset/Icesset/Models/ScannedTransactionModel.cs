using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{

    public class ScannedData
    {
        public string transaction_id { get; set; }
        public string transaction_status { get; set; }
        public string transaction_type { get; set; }
        public string waybill_id { get; set; }
        public string transactionDate { get; set; }
        public string created_by_id { get; set; }
        public string created_by_name { get; set; }
        public string receivedBy { get; set; }
        public string stored_in { get; set; }
        public string transaction_item_id { get; set; }
        public string item_name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string supplier { get; set; }
        public string supplierContact { get; set; }
        public DateTime dateCreated { get; set; }
        public string store_id { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string destination { get; set; }
        public string sent_to_id { get; set; }
        public string sent_to_name { get; set; }
        public string courier_name { get; set; }
        public long courier_contact { get; set; }
        public string note { get; set; }
        public List<ScannedItemData> data { get; set; }
        public string item_id { get; set; }
        public string qyt_loc_id { get; set; }
        public string store_name { get; set; }
        public int quantity { get; set; }
        public int trans_quantity { get; set; }
    }

    public class ScannedTransactionModel
    {
        public string message { get; set; }
        public List<ScannedData> data { get; set; }
    }



   
}
