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
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel(Navigation);
            
        }


        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            Navigation.PushAsync(new ItemsDetailPage());
        }

        //private void search_bar(object sender, TextChangedEventArgs e)
        //{
        //    getItems.ItemsSource = GetItems.Where(a => a.item_name.StartsWith(e.NewTextValue));
        //}
    }
} 