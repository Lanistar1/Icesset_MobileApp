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

        private void Done(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemsPage());
        }
    }
}