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
    public partial class TestPage : ContentPage
    {
        private string text;

        public TestPage()
        {
            InitializeComponent();
        }

        public TestPage(string text)
        {
            Test_Result.BindingContext = text;
        }
    }
}