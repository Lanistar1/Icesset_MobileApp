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
using System.Linq;

namespace Icesset.ViewModels
{
    public class PopupViewModel : BaseViewModel
    {

        List<NewLotDetail> SelectedItems;


        private List<StoreResult> allStore;
        public List<StoreResult> AllStore
        {
            get => allStore;
            set
            {
                allStore = value;
                OnPropertyChanged(nameof(AllStore));
            }
        }

        private ObservableCollection<TransactItemData> transactItems;
        public ObservableCollection<TransactItemData> TransactItems
        {
            get => transactItems;
            set
            {
                transactItems = value;
                OnPropertyChanged(nameof(TransactItems));
            }
        }



        private List<string> store;
        public List<string> Store
        {
            get => store;
            set
            {
                store = value;
                OnPropertyChanged(nameof(Store));
            }
        }

        public PopupViewModel(INavigation navigation)
        {
            Navigation = navigation;
            var Items = Constant.Transact;
            UpdateViewBinding(Items);





            Task _task = GetStoreExecute();
            //Task _tasks = GetCollectExecute();

            StoreCommand = new Command(async () => await GetStoreExecute());

            CollectCommand = new Command(async () => await GetCollectExecute());
        }

        private void UpdateViewBinding(ObservableCollection<Response> items)


        {
            try
            {
                var _items = new List<NewLotDetail>();
                var _item = new List<TransactItemData>();
                var xItems = new NewLotDetail();
                //foreach (var item in items)
                //{

                //    xItems = new NewLotDetail() { user_id = item.data.FirstOrDefault().user_id, user_name = item.data.FirstOrDefault().user_name, qyt_loc_id = item.data.FirstOrDefault().qyt_loc_id, store_id = item.store_id, store_name = item.data.FirstOrDefault().store_name };
                //    //foreach (var u in item.data)
                //    //{
                //    //}
                //    //item.newTransact = new ObservableCollection<TransactItemData>(item.data);
                //}
                foreach (var item in items)
                {

                    xItems = new NewLotDetail() {qyt_loc_id = item.data.FirstOrDefault().qyt_loc_id };
                    //foreach (var u in item.data)
                    //{
                    //}
                    //item.newTransact = new ObservableCollection<TransactItemData>(item.data);
                }
                _items.Add(xItems);

                //foreach (var item in _item)
                //{
                //    NewLotDetail cmItems = new NewLotDetail(item[0]., item.data., item.user_id, item.user_name, item.qyt_loc_id);
                //    _items.Add(cmItems);
                //}
                SelectedItems = _items;
            }
            catch (Exception ex)
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


        public Command CollectCommand { get; }

        public async Task GetCollectExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string transactionId = Constant.Transact.FirstOrDefault().transaction_id;
                string receiveBy = Constant.Transact.FirstOrDefault().sent_to_name;
                string userId = Constant.Transact.FirstOrDefault().sent_to_id;
                string userName = Constant.Transact.FirstOrDefault().sent_to_name;
                string storeName = Constant.selectedStore;
                string storeId = Constant.selectedStoreId;
                string qtyInLoc = Constant.Transact.FirstOrDefault().qyt_loc_id;

                NewLotDetail newLotDetail = new NewLotDetail() {store_id = storeId, qyt_loc_id = qtyInLoc, store_name = storeName, user_id = userId, user_name = userName };

                BatchInfo batchInfo = new BatchInfo() { receivedBy =receiveBy , storedIn =Constant.selectedStore  , transaction_id =transactionId  };

                CollectModel requestPayload = new CollectModel() { batchInfo = batchInfo, newLotDetails = newLotDetail };

                string payloadJson = JsonConvert.SerializeObject(requestPayload);

                string url = Constant.CollectUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");
                //HttpResponseMessage response = null;
                //response = await client.Patch(url, content);
                var test = Constant.accessToken;
                Console.WriteLine(test);

                var method = new HttpMethod("PATCH");

                var request = new HttpRequestMessage(method, url)
                {
                    Content = content
                };

                var response = await client.SendAsync(request);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //ProfileResponse data = JsonConvert.DeserializeObject<ProfileResponse>(result);
                    MessageLabel = "Items Collect Successfully.";
                    Console.WriteLine(MessageLabel);
                    Console.WriteLine("gubkfuwgyliwerli");
                    await Navigation.PushAsync(new DashBoardPage());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    IsMessageVisible = true;
                    MessageLabel = "Please select where to store your items";
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









        public Command StoreCommand { get; }
        public async Task GetStoreExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Constant.StoreUrl;

                HttpResponseMessage response = await client.GetAsync(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                response = await client.GetAsync(url);
                //response = await client.GetAsync(url + Helps.Constant.user_id);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    PopupModel data = JsonConvert.DeserializeObject<PopupModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    AllStore = new List<StoreResult>(data.data.result);
                    Console.WriteLine(AllStore);
                    List<string> names = new List<string>();
                    foreach (var item in AllStore)
                    {
                        Console.WriteLine(item);
                        var storeName = item.store_name;
                        names.Add(storeName.ToString());
                    }
                    Store = new List<string>(names);
                    Console.WriteLine(Store);

                }

                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}
