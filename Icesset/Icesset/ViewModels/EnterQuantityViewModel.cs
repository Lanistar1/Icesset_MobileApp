using Icesset.Helps;
using Icesset.Models;
using Icesset.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class EnterQuantityViewModel : BaseViewModel
    {
        public ObservableCollection<ItemData> selectedItems;
        public ObservableCollection<ItemData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        public Command<object> DeleteCommand { get; set; }
        public Command ContinueCommand { get; set; }

        private ObservableCollection<ItemData> enter_Quantity;
        public ObservableCollection<ItemData> Enter_Quantity
        {
            get => enter_Quantity;
            set
            {
                enter_Quantity = value;
            }
        }


        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                //EnterQuantityTextChangedCommad.Execute(quantity);
                OnPropertyChanged(nameof(Quantity));
            }
        }
        
        private int uniqueQuantity;
        public int UniqueQuantity
        {
            get => uniqueQuantity;
            set
            {
                uniqueQuantity = value;
                //EnterQuantityTextChangedCommad.Execute(quantity);
                OnPropertyChanged(nameof(UniqueQuantity));
            }
        }
        
        private string messageLabel;
        public string MessageLabel
        {
            get => messageLabel;
            set
            {
                messageLabel = value;
                OnPropertyChanged(nameof(MessageLabel));
            }
        }

        private bool isMessageVisible = false;

        public bool IsMessageVisible
        {
            get => isMessageVisible;
            set
            {
                isMessageVisible = value;
                OnPropertyChanged(nameof(IsMessageVisible));
            }
        }


        public EnterQuantityViewModel(INavigation navigation, ObservableCollection<ItemData> selectedItems)
        {
            Navigation = navigation;
            SelectedItems = selectedItems;

            //foreach (var item in SelectedItems)
            //{
            //    var UniqueQuantity = item.quantity;
            //    Console.WriteLine(UniqueQuantity);
            //}

            SelectedI(SelectedItems);
            Console.WriteLine(SelectedItems);

            var test = SelectedItems;
            Console.WriteLine(test);


            Enter_Quantity = new ObservableCollection<ItemData>(SelectedItems);
            DeleteCommand = new Command<object>(OnTapped);
            ContinueCommand = new Command(async () => await ContinueCommandExecute());
            //ContinueCommand = new Command(async () => await ContinueCommandExecute(test));





            RequestedQualityCommand = new Command<ItemData>(async (model) => await RequestedQualityCommandExecute(model));

        }

        private void SelectedI(ObservableCollection<ItemData> selectedItems)
        {
            var sItems = selectedItems;
            Constant.SavedSelectedItems = sItems;
            
        }

        private void OnTapped(object obj)
        {
            var itemdata = obj as ItemData;
            Enter_Quantity.Remove(itemdata);
            //App.Current.MainPage.DisplayAlert("Message", "Item Deleted :" + itemdata.item_name, "Ok");
        }

       
        public Command RequestedQualityCommand { get; set; }
        public Command EnterQuantityTextChangedCommad => new Command<string>((entryText) => EnterQuantityTextChanged(entryText));

        

        public async Task ContinueCommandExecute()
        {
            SelectedItems = selectedItems;
            foreach (var item in SelectedItems)
            {
                var quantity = item.quantity;
                var Quantity = item.Quantity;

                if (Quantity > quantity)
                {
                    Console.WriteLine("get out");
                    IsMessageVisible = true;
                    MessageLabel = " Input quantity is more than available quantity";
                    await Task.Delay(3000);
                    IsMessageVisible = false;
                    return;
                }
                else if (Quantity == 0)
                {
                    IsMessageVisible = true;
                    MessageLabel = " quantity cannot be equal to zero";
                    await Task.Delay(3000);
                    IsMessageVisible = false;
                    return ;
                }
                else
                {
                    await Navigation.PushAsync(new WayBillPage());
                }
            }
            //if (Quantity > quantity)
            //{
            //    Console.WriteLine("get out");
            //    MessageLabel = "quantity is more than available quantity";
            //}
            //else
            //{
            //    await Navigation.PushAsync(new WayBillPage());
            //}



            Console.WriteLine(Quantity);
            //Constant.SavedSelectedItems = selectedItems;


        }
        //public async Task ContinueCommandExecute(List<ItemData> selectedItems)
        //{
        //   //Constant.SavedSelectedItems = selectedItems;
        //    await Navigation.PushAsync(new WayBillPage());
        //}



        private async Task RequestedQualityCommandExecute(ItemData item)
        {
            var checkId = item.item_id;
            await Task.Delay(10);
        }
        private void EnterQuantityTextChanged(string entrytext)
        {

            var check = entrytext;
        }
    }
}
