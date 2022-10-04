 using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    //public class TransferResponseModel
    //{
    //    public string message { get; set; }
    //}

    public class ReviewModel 
    {
        public ReviewModel(WaybillDetails bill, TransactionDetails transact, List<TransactionItem> items)
        {
        waybillDetails = bill;
        transactionDetails = transact;
        transactionItem = items;
        }


        public WaybillDetails waybillDetails { get; set; }
        public TransactionDetails transactionDetails { get; set; }
        public List<TransactionItem> transactionItem { get; set; }

    }

    public class TransactionDetail
    {
        public string transaction_type { get; set; }
        public string created_by_id { get; set; }
        public string created_by_name { get; set; }
        public string exp_delivery_date { get; set; }
    }

    public class TransactionItems
    {
        public string item_id { get; set; }
        public string qyt_loc_id { get; set; }
        public int quantity { get; set; }
    }

    public class WaybillDetail
    {
        public string destination { get; set; }
        public string sent_to_id { get; set; }
        public string sent_to_name { get; set; }
        public string courier_name { get; set; }
        public string courier_contact { get; set; }
        public string note { get; set; }
    }


}
