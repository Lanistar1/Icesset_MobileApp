using Icesset.Helps;
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
    public partial class SuccessPage : ContentPage
    {
        //private ItemsPage _itemsPage;

        public SuccessPage()
        {
            InitializeComponent();
            BindingContext = new SuccessViewModel(Navigation);
        }

        public NavigationPage MainPage { get; private set; }

        private async void Done(object sender, EventArgs e)
        {
            int backCount = 4;
            for (var counter = 1; counter < backCount; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();

        }
    }
}