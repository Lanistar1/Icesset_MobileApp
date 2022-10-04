using Icesset.Models;
using Icesset.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionDetailsPage : ContentPage
    {

        public TransactionDetailsPage(ObservableCollection<Response> selectedItems)
        {
            InitializeComponent();
            BindingContext = new TransactionDetailViewModel(Navigation, selectedItems);

        }

        private void ShowPopup(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopUpView());
        }



        //private void ClickToCollect(object sender, EventArgs e)
        //{
        //    popupCollect.IsVisible = true;
        //}

        //private void OnImageTap_CloseModal(object sender, EventArgs e)
        //{
        //    popupCollect.IsVisible = false;

        //}
    }
}