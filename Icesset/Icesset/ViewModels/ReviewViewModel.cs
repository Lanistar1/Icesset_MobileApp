using Icesset.Helps;
using Icesset.Models;
using Icesset.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        List<TransactionItem> SelectedItems;
        WaybillDetails WayBill;
        TransactionDetails TransDetails;

        private ObservableCollection<ItemData> select;
        public ObservableCollection<ItemData> Select
        {
            get => select;
            set
            {
                select = value;
                OnPropertyChanged(nameof(Select));
            }
        }

        public ReviewViewModel(INavigation navigation, WaybillDetails waybillDetails, TransactionDetails transactionDetails)
        {
            Navigation = navigation;
            var Items = Constant.SavedSelectedItems;
            Console.WriteLine(Items);
            WayBill = waybillDetails;
            TransDetails = transactionDetails;
            Select = Constant.SavedSelectedItems;
            UpdateViewBinding(Items);



            //Task _task = GetTransferExecute();

            TransferCommand = new Command(async () => await GetTransferExecute());
        }

        private void UpdateViewBinding(ObservableCollection<ItemData> items)
        {
            try
            {
                var _items = new List<TransactionItem>();
                foreach(var item in items)
                {
                    TransactionItem cmItems = new TransactionItem(item.item_id, item.qyt_loc_id, item.Quantity); 
                    _items.Add(cmItems);
                }
                SelectedItems = _items;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
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

        
        public Command TransferCommand { get; }

        public async Task GetTransferExecute()
        {
            try
            {
                HttpClient client = new HttpClient();
                ReviewModel request = new ReviewModel(WayBill, TransDetails, SelectedItems);

                string body = JsonConvert.SerializeObject(request);

                string url = Constant.CreateTransactionUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");
                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                var test = Constant.accessToken;
                Console.WriteLine(test);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //ProfileResponse data = JsonConvert.DeserializeObject<ProfileResponse>(result);
                    MessageLabel = "Items sent Successfully.";
                    Console.WriteLine(MessageLabel);
                    Console.WriteLine("gubkfuwgyliwerli");
                    await Navigation.PushAsync(new SuccessPage());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    IsMessageVisible = true;
                    MessageLabel = "You are not making your transfer correctly";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    MessageLabel = "Something went wrong. Please try again later.";
                    IsMessageVisible = false;
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
