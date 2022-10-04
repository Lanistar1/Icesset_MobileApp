using System;
using System.Collections.Generic;
using System.Text;

namespace Icesset.Models
{
    public class TransferRequestModel
    {
        public WaybillDetails waybillDetails { get; set; }
        public TransactionDetails transactionDetails { get; set; }
        public List<TransactionItem> transactionItem { get; set; }
    }

    public class TransactionDetails
    {
        public TransactionDetails(string transaction_type, string created_by_id, string created_by_name, string exp_delivery_date)
        {
            this.transaction_type = transaction_type;
            this.created_by_id = created_by_id;
            this.created_by_name = created_by_name;
            this.exp_delivery_date = exp_delivery_date;
        }

        public string transaction_type { get; set; }
        public string created_by_id { get; set; }
        public string created_by_name { get; set; }
        public string exp_delivery_date { get; set; }
    }

    public class TransactionItem
    {
        public TransactionItem(string item_id, string qyt_loc_id, int quantity)
        {
            this.item_id = item_id;
            this.qyt_loc_id = qyt_loc_id;
            this.quantity = quantity;
        }

        public string item_id { get; set; }
        public string qyt_loc_id { get; set; }
        public int quantity { get; set; }
    }

    public class WaybillDetails
    {
        public WaybillDetails(string destination,string sent_to_id, string sent_to_name, string courier_name, string courier_contact, string note)
        {
            this.destination = destination;
            this.sent_to_id = sent_to_id;
            this.sent_to_name = sent_to_name;
            this.courier_name = courier_name;
            this.courier_contact = courier_contact;
            this.note = note;
        }
        public string destination { get; set; }
        public string sent_to_id { get; set; }
        public string sent_to_name { get; set; }
        public string courier_name { get; set; }
        public string courier_contact { get; set; }
        public string note { get; set; }
    }


}
