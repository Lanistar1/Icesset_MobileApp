using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Icesset.ViewModels;
using Newtonsoft.Json;

namespace Icesset.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TransactData : BaseViewModel
    {
        public int total_transaction { get; set; }
        public ObservableCollection<Response> response { get; set; }
        public Response responses { get; set; }

        public string item_id { get; set; }
        

        

       

        //public List<TransactItemData> data { get; set; }

    }

    public class Response : BaseViewModel
    {
        public int id { get; set; }
        public string transaction_id { get; set; }
        public string transaction_status { get; set; }
        public string transaction_type { get; set; }
        public string waybill_id { get; set; }
        public string transactionDate { get; set; }
        public string created_by_id { get; set; }
        public string created_by_name { get; set; }
        public string exp_delivery_date { get; set; }
        public string receivedBy { get; set; }
        public object stored_in { get; set; }
        public int transaction_item_id { get; set; }
        public DateTime dateCreated { get; set; }
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


        private bool collectVisible = false;
        public bool CollectVisible
        {
            get => collectVisible;
            set
            {
                collectVisible = value;
                OnPropertyChanged(nameof(CollectVisible));
            }
        }

    }


    //public class Responses : BaseViewModel
    //{
    //    public int id { get; set; }
    //    public string transaction_id { get; set; }
    //    public string transaction_status { get; set; }
    //    public string transaction_type { get; set; }
    //    public string waybill_id { get; set; }
    //    public string transactionDate { get; set; }
    //    public string created_by_id { get; set; }
    //    public string created_by_name { get; set; }
    //    public string exp_delivery_date { get; set; }
    //    public string receivedBy { get; set; }
    //    public object stored_in { get; set; }
    //    public int transaction_item_id { get; set; }
    //    public DateTime dateCreated { get; set; }
    //    public string store_id { get; set; }
    //    public string destination { get; set; }
    //    public string sent_to_id { get; set; }
    //    public string sent_to_name { get; set; }
    //    public object sent_to_phone { get; set; }
    //    public string courier_name { get; set; }
    //    public long courier_contact { get; set; }
    //    public string note { get; set; }
    //    public string item_name { get; set; }
    //    public string qyt_loc_id { get; set; }
    //    public string category { get; set; }
    //    public string store_name { get; set; }
    //    public int quantity { get; set; }
    //    public string unit { get; set; }
    //    public DateTime date_in_loc { get; set; }
    //    public string description { get; set; }
    //    public string supplier_name { get; set; }
    //    public object supplier_phone { get; set; }
    //    public string supplier_email { get; set; }
    //    public string user_id { get; set; }
    //    public string user_name { get; set; }
    //    public string item_condition { get; set; }
    //    public string item_status { get; set; }
    //    public string availability { get; set; }
    //    public int trans_quantity { get; set; }
    //    public bool isSelected { get; set; }
    //    public ObservableCollection<TransactItemData> data { get; set; }
    //}








        public class TransactionModel
    {
        public string message { get; set; }
        public TransactData data { get; set; }
    }

    //public class Root
    //{
    //    public string message { get; set; }
    //    public Data data { get; set; }
    //}






    //public class TransactData : BaseViewModel
    //{
    //    public int total_transaction { get; set; }
    //    public List<Response> response { get; set; }
    //    public string item_id { get; set; }
    //    public string item_name { get; set; }
    //    public string qyt_loc_id { get; set; }
    //    public string category { get; set; }
    //    public string store_name { get; set; }
    //    public int quantity { get; set; }
        //public string unit { get; set; }
        //public DateTime date_in_loc { get; set; }
        //public string description { get; set; }
        //public string supplier_name { get; set; }
        //public object supplier_phone { get; set; }
        //public string supplier_email { get; set; }
        //public string user_id { get; set; }
        //public string user_name { get; set; }
        //public string item_condition { get; set; }
        //public string item_status { get; set; }
        //public string availability { get; set; }
        //public int trans_quantity { get; set; }
        //public bool isSelected { get; set; }
        //public string receivedBy { get; set; }
        //public int id { get; set; }
        //public string transaction_id { get; set; }
        //public string transaction_status { get; set; }
        //public string transaction_type { get; set; }
        //public string waybill_id { get; set; }
        //public string transactionDate { get; set; }
        //public string created_by_id { get; set; }
        //public string created_by_name { get; set; }
        //public DateTime exp_delivery_date { get; set; }
        //public object stored_in { get; set; }
        //public int transaction_item_id { get; set; }
        //public DateTime dateCreated { get; set; }
        //public string store_id { get; set; }
        //public string destination { get; set; }
        //public string sent_to_id { get; set; }
        //public string sent_to_name { get; set; }
        //public object sent_to_phone { get; set; }
        //public string courier_name { get; set; }
        //public long courier_contact { get; set; }
        //public string note { get; set; }
        //public List<TransactItemData> data { get; set; }


        //private bool collectVisible = false;
        //public bool CollectVisible
        //{
        //    get => collectVisible;
        //    set
        //    {
        //        collectVisible = value;
        //        OnPropertyChanged(nameof(CollectVisible));
        //    }
        //}

        //public ObservableCollection<TransactItemData> newTransact { get; set; }
    }

    //public class Response
    //{
        
       
    //}

    ////public class TransactionModel
    ////{
    ////    public string message { get; set; }
    ////    public List<TransactData> data { get; set; }
    ////}





    //public class TransactionModel
    //{
    //    public string message { get; set; }
    //    public Data data { get; set; }
    //}


    //public class TransactData : BaseViewModel
    //{
    //public int id { get; set; }
    //public string transaction_id { get; set; }
    //public string transaction_status { get; set; }
    //public string transaction_type { get; set; }
    //public string waybill_id { get; set; }
    //public string transactionDate { get; set; }
    //public string created_by_id { get; set; }
    //public string created_by_name { get; set; }
    //public string exp_delivery_date { get; set; }
    //public string receivedBy { get; set; }
    //public object stored_in { get; set; }
    //public string transaction_item_id { get; set; }
    //public string category { get; set; }
    //public string dateCreated { get; set; }
    //public string store_id { get; set; }
    //public string unit { get; set; }
    //public string user_id { get; set; }
    //public string user_name { get; set; }
    //public string item_status { get; set; }
    //public string availability { get; set; }
    //public string supplier_name { get; set; }
    //public long supplier_phone { get; set; }
    //public string supplier_email { get; set; }
    //public string item_condition { get; set; }
    //public string date_in_loc { get; set; }
    //public string destination { get; set; }
    //public string sent_to_id { get; set; }
    //public string sent_to_name { get; set; }
    //public string courier_name { get; set; }
    //public long courier_contact { get; set; }
    //public string note { get; set; }
    //public List<TransactItemData> data { get; set; }
    //public string item_id { get; set; }
    //public string item_name { get; set; }
    //public string qyt_loc_id { get; set; }
    //public string store_name { get; set; }
    //public int quantity { get; set; }
    //public string description { get; set; }
    //public int trans_quantity { get; set; }
    //public bool isSelected { get; set; }


    //private bool collectVisible = false;
    //public bool CollectVisible
    //{
    //    get => collectVisible;
    //    set
    //    {
    //        collectVisible = value;
    //        OnPropertyChanged(nameof(CollectVisible));
    //    }
    //}



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
    //public ObservableCollection<TransactItemData> newTransact { get; set; }
    //}

    //public class TransactionModel
    //{
    //    public string message { get; set; }
    //    public List<TransactData> data { get; set; }
    //}

//}
