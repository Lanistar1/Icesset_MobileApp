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
using System.Collections;

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
            var Items = Constant.ItemSelected;
            UpdateViewBinding(Items);





            Task _task = GetStoreExecute();
            //Task _tasks = GetCollectExecute();

            StoreCommand = new Command(async () => await GetStoreExecute());

            CollectCommand = new Command(async () => await GetCollectExecute());
        }

        //public PopupViewModel(INavigation navigation, ObservableCollection<Response> selectedItems) : this(navigation)
        //{
        //    this.selectedItems = selectedItems;
        //}

        private void UpdateViewBinding(ObservableCollection<Response> items)


        {
            try
            {

                //var LotQuantity = Constant.ItemSelected.FirstOrDefault().data;
                //var LotTransaction = Constant.ItemSelected;
                //List<string> LotTransact = new List<string>();
                ////foreach (var item in LotTransaction)
                ////{
                ////    var Lot = item.
                //// }

                //List<string> quantityLot = new List<string>();
                //foreach (var item in LotQuantity)
                //{
                //    var quantity = item.qyt_loc_id;
                //    quantityLot.Add(quantity);
                //}
                //quantityLoc = new List<string>(quantityLot);
                //Constant.QuantityLoc = quantityLot;



                //var _items = new List<NewLotDetail>();
                //var _item = new List<TransactItemData>();
                //var xItems = new NewLotDetail();
                //foreach (var item in items)
                //{

                //    NewLotDetail xitems = new NewLotDetail() { user_id = Constant.CurrentUserData.info.user_id, user_name = Constant.CurrentUserData.info.fullname, 
                //        qyt_loc_id = item.qyt_loc_id, store_id = Constant.selectedStoreId, store_name = Constant.selectedStore };
                //    _items.Add(xitems);

                //}

                //    item.newtransact = new observablecollection<transactitemdata>(item.data);
                //}
                //foreach (var item in items)
                //{

                //    xItems = new NewLotDetail() {qyt_loc_id = item.data.FirstOrDefault().qyt_loc_id };
                //    //foreach (var u in item.data)
                //    //{
                //    //}
                //    //item.newTransact = new ObservableCollection<TransactItemData>(item.data);
                //}
                //_items.Add(xItems);

                //foreach (var item in _item)
                //{
                //    NewLotDetail cmItems = new NewLotDetail(item[0]., item.data., item.user_id, item.user_name, item.qyt_loc_id);
                //    _items.Add(cmItems);
                //}
                //SelectedItems = _items;
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

        private List<string> quantityLoc;
        public List<string> QuantityLoc
        {
            get => quantityLoc;
            set
            {
                quantityLoc = value;
                OnPropertyChanged(nameof(QuantityLoc));
            }
        }
            
        private string newQuantityLoc;
        public string NewQuantityLoc
        {
            get => newQuantityLoc;
            set
            {
                newQuantityLoc = value;
                OnPropertyChanged(nameof(NewQuantityLoc));
            }
        }

        private string messageLabel;
        private ObservableCollection<Response> selectedItems;

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

                string transactionId = Constant.ItemSelected.FirstOrDefault().transaction_id;
                string receiveBy = Constant.CurrentUserData.info.fullname;
                string userId = Constant.CurrentUserData.info.user_id;
                string userName = Constant.CurrentUserData.info.fullname;
                string storeName = Constant.selectedStore;
                string storeId = Constant.selectedStoreId;
                var LotQuantity = Constant.ItemSelected.FirstOrDefault().data;
                var LotTransaction = Constant.ItemSelected;
                //List<string> LotTransact = new List<string>();
                //foreach (var item in LotTransaction)
                //{
                //    var Lot = item.
                // }

                List<string> quantityLot = new List<string>();
                CollectModel _listOfLotItems = new CollectModel();
                var x = new List<NewLotDetail>();
                foreach (var item in LotQuantity)
                {
                    var quantity = item.qyt_loc_id;
                    //quantityLoc = item.qyt_loc_id;
                    quantityLot.Add(quantity);
                    NewLotDetail newLotDetail = new NewLotDetail()
                    {
                        store_id = Constant.selectedStoreId,
                        qyt_loc_id = quantity,
                        store_name = Constant.selectedStore,
                        user_id = Constant.CurrentUserData.info.user_id,
                        user_name = Constant.CurrentUserData.info.fullname
                };
                    x.Add(newLotDetail);                  
                    //_listOfLotItems.newLotDetails.Add(newLotDetail);

                }
                quantityLoc = quantityLot;
                //quantityLoc.ForEach(item =>
                //{
                    
                //});
                //foreach (var item in quantityLoc)
                //{
                //    var NewQuantityLoc = 
                //}
                Constant.QuantityLoc = quantityLot;



                //string qtyInLoc = Constant.TransactItemData.FirstOrDefault().qyt_loc_id;

               

                
                //_listOfLotItems.newLotDetails.Add(newLotDetail);
                //List<NewLotDetail> listOfLotItems;
                //listOfLotItems.Add(newLotDetail);
                BatchInfo batchInfo = new BatchInfo() { receivedBy =receiveBy , storedIn =Constant.selectedStore  , transaction_id =transactionId  };

                //CollectModel requestPayload = new CollectModel() { batchInfo = batchInfo, newLotDetails = _listOfLotItems };
                CollectModel requestPayload = new CollectModel() { batchInfo = batchInfo, newLotDetails = x };

                string payloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(payloadJson);

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

                Console.WriteLine(response);

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
