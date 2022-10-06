using Icesset.Helps;
using Icesset.Models;
using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpView : Popup
    {
        //private readonly BatchInfo batchInfo;
        private string storeType;
        private string selectedStoreId;
        private ObservableCollection<Response> selectedItems;

        public PopUpView()
        {
            InitializeComponent();
            BindingContext = new PopupViewModel(Navigation);
        }
        //public PopUpView(ObservableCollection<Response> selectedItems)
        //{
        //    InitializeComponent();
        //    BindingContext = new PopupViewModel(Navigation, selectedItems);
        //}

        

        private void userListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            if (picker.SelectedItem != null)
            {
                storeType = (picker.SelectedItem as StoreResult).store_name;
                selectedStoreId = (picker.SelectedItem as StoreResult).store_id;

            }
            //storeType = picker.SelectedItem.ToString();
            Constant.selectedStore = storeType;
            Constant.selectedStoreId = selectedStoreId;
        }
    }
}