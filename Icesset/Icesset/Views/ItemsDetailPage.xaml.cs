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
    public partial class ItemsDetailPage : ContentPage
    {
        public ItemsDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemsDetailViewModel(Navigation);

        }
    }
}