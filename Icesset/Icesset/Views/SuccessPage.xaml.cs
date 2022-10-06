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
        public SuccessPage()
        {
            InitializeComponent();
            BindingContext = new SuccessViewModel(Navigation);
        }

        public NavigationPage MainPage { get; private set; }

        private void Done(object sender, EventArgs e)
        {
            MainPage = new NavigationPage(new ItemsPage());
            //Navigation.PushAsync(new ItemsPage());
        }
    }
}