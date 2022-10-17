using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icesset.Helps;
using Icesset.Models;
using Icesset.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WayBillPage : ContentPage
    {
        private string transType;
        private string userList;
        private string selectedUserId;
        public WayBillPage()
        {
            InitializeComponent();
            BindingContext = new WayBillViewModel(Navigation);
        }

        //private string transfer;
        //private bool consume;
        //private bool pickerVisible = false;
        //private bool sentVisible = false;
        //public string Transfer { get; private set; }
        //public bool Consume { get; private set; }
        //public bool PickerVisible { get; private set; }
        //public bool SentVisible { get; private set; }
        //public string External { get; private set; }

        private async void Click_Behind(object sender, EventArgs e)
        {
            string fullName = $"{Constant.CurrentUserData.info.firstName} {Constant.CurrentUserData.info.lastName}";
            string userId = Constant.CurrentUserData.info.user_id;
            string _expName = expName.Date.ToString("yyyy-MM-dd");
            //var SenttoId = Constant.UserList[0];
            TransactionDetails transactionDetails = new TransactionDetails(transType, userId, fullName, _expName);
            WaybillDetails waybillDetails = new WaybillDetails(NameTextBox.Text, selectedUserId, userList, CourierTextBox.Text, ContactTextBox.Text, NoteTextBox.Text);
            await Navigation.PushAsync(new ReviewTransactionPage(waybillDetails, transactionDetails));
        }

        private void transTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker= sender as Picker;
            transType = picker.SelectedItem.ToString();
        }

        private void userListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            if (picker.SelectedItem != null)
            {
                selectedUserId = (picker.SelectedItem as Result).user_id;
                userList = (picker.SelectedItem as Result).thefullname;

            }
        }
    }
}