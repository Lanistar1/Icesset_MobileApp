using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using Icesset.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();
            BindingContext = new DashBoardViewModel(Navigation);
        }

        private void See_All(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionPage());

        }

        //private void Tapped_Me(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new TransactionDetailsPage());
        //}

        private void Tapped_Transaction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionPage());

        }

        private void Tapped_Items(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemsPage());

        }

        //private void Tapped_Me(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new TransactionDetailsPage());
        //}
    }
}