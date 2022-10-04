using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Icesset.Models
{
    public class ItemData : BaseViewModel
    {
        public int id { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public string qyt_loc_id { get; set; }
        public string store_id { get; set; }
        public string store_name { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string item_status { get; set; }
        public string availability { get; set; }
        public string supplier_name { get; set; }
        public object supplier_phone { get; set; }
        public string supplier_email { get; set; }
        public string item_condition { get; set; }
        public DateTime date_in_loc { get; set; }
        public string requestedQuantity { get; set; }
        public int Quantity { get; set; }



        //public string item_id { get; set; }
        //public string item_name { get; set; }
        //public string category { get; set; }
        //public string description { get; set; }
        //public string supplier { get; set; }
        //public string supplierContact { get; set; }
        //public string dateCreated { get; set; }
        //public string qyt_loc_id { get; set; }
        //public string  store_id { get; set; }
        //public string store_name { get; set; }
        //public int quantity { get; set; }
        //public string user_id { get; set; }
        //public string user_name { get; set; }
        public bool isSelected { get; set; }

        private bool frameChecked = true;
        public bool FrameChecked
        {
            get => frameChecked;
            set
            {
                frameChecked = value;
                OnPropertyChanged(nameof(FrameChecked));
            }
        }

        private bool imageChecked = false;
        public bool ImageChecked
        {
            get => imageChecked;
            set
            {
                imageChecked = value;
                OnPropertyChanged(nameof(ImageChecked));
            }
        }
        
        private bool buttonShow = true;
        public bool ButtonShow
        {
            get => buttonShow;
            set
            {
                buttonShow = value;
                OnPropertyChanged(nameof(ButtonShow));
            }
        }
        
        private bool buttonHide = false;
        public bool ButtonHide
        {
            get => buttonHide;
            set
            {
                buttonHide = value;
                OnPropertyChanged(nameof(ButtonHide));
            }
        }
        public string icon { get; set; }

        internal static object Where(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemResponseModel
    {
        public string message { get; set; }
        public int total_items { get; set; }
        public List<ItemData> data { get; set; }
    }
}
