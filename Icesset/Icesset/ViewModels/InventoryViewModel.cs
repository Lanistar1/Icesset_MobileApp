using Icesset.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class InventoryViewModel
    {
        private ObservableCollection<InventoryModel> searchResults;
        private INavigation Navigation;

        public ObservableCollection<InventoryModel> SearchResults
        {
            get => searchResults;
            set
            {
                searchResults = value;

            }
        }
        public InventoryViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SearchResults = new ObservableCollection<InventoryModel>{
                new InventoryModel { ItemName = "Hammer", Quantity = 10, Location = "Ibadan"  },
                new InventoryModel { ItemName = "Spanner", Quantity = 20, Location = "Abuja" },
                new InventoryModel { ItemName = "Battery", Quantity = 15, Location = "Lagos" },
                new InventoryModel { ItemName = "Cylinder", Quantity = 5, Location = "Warri" },

             };
        }
    }
}
