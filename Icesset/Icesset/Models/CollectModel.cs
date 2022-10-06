using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Icesset.Models
{
    public class Batchinfoinner: BatchInfo
    {
        public Batchinfoinner(string receivedBy, string storedIn, string transaction_id )
        {
            this.receivedBy = receivedBy;
            this.storedIn = storedIn;
            this.transaction_id = transaction_id;
        }

    }
    public class BatchInfo
    {
      
        public string receivedBy { get; set; }
        public string storedIn { get; set; }
        public string transaction_id { get; set; }
    }


    

    public class NewLotDetail
    {
        //public NewLotDetail(string store_id, string store_name, string user_id, string user_name, string qyt_loc_id)
        //{
        //    this.store_id = store_id;
        //    this.store_name = store_name;
        //    this.user_id = user_id;
        //    this.user_name = user_name;
        //    this.qyt_loc_id = qyt_loc_id;
        //}

        public string store_id { get; set; }
        public string store_name { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string qyt_loc_id { get; set; }

        //public static implicit operator List<object>(NewLotDetail v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class CollectModel
    {
        //public CollectModel(BatchInfo batch, List<NewLotDetail> newLot)
        //{
        //    batchInfo = batch;
        //    newLotDetails = newLot;
        //}

        public BatchInfo batchInfo { get; set; }
        public List<NewLotDetail> newLotDetails { get; set; }
        //public NewLotDetail newLotDetails { get; set; }


    }
    

}
