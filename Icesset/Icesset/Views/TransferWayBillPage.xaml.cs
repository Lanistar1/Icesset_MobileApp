using Icesset.Models;
using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferWayBillPage : ContentPage
    {
        public TransferWayBillPage(ObservableCollection<Response> selectedItems)
        {
            InitializeComponent();
            BindingContext = new TransferWayBillViewModel(Navigation, selectedItems);

        }
    }
}