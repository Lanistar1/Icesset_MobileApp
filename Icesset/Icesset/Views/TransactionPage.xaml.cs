using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionPage : ContentPage
    {
        public TransactionPage()
        {
            InitializeComponent();
            BindingContext = new TransactionPageViewModel(Navigation);

        }

        //private void Tap_Me(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new TransactionDetailsPage());
        //}
    }
}