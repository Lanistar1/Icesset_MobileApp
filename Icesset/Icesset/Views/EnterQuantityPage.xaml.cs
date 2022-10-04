using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icesset.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterQuantityPage : ContentPage
    {
        public EnterQuantityPage(ObservableCollection<ItemData> selectedItems)
        {
            InitializeComponent();
            BindingContext = new EnterQuantityViewModel(Navigation, selectedItems);

        }

        //private void Continue(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new WayBillPage());

        //}

    }
}