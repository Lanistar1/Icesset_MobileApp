using Icesset.Helps;
using Icesset.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class SuccessViewModel : BaseViewModel
    {
        private int selected;
        public int Selected
        {
            get => selected;
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public ObservableCollection<ItemData> selectedItems;
        public ObservableCollection<ItemData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        //Constant.GetItems = new ObservableCollection<ItemData>(data.data);
        //            Console.WriteLine(GetItems);

        //            if (Constant.GetItems != null)
        //            {
        //                ObservableCollection<ItemData> itemCount = Constant.GetItems;
        ////Console.WriteLine(itemCount.Count);
        //Transaction = itemCount.Count;

        //}


        public SuccessViewModel(INavigation navigation)
        {
            Navigation = navigation;
            if (Constant.GetItems != null)
            {
                ObservableCollection<ItemData> Success = Constant.SavedSelectedItems;
                //Console.WriteLine(itemCount.Count);
                Selected = Success.Count;

            }


        }
    }
}
