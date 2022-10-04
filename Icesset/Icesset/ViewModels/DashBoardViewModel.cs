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
using System.Transactions;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        //private ObservableCollection<DashBoardModel> listView;
        //private INavigation Navigation;

        //public ObservableCollection<DashBoardModel> ListView
        //{
        //    get => listView;
        //    set
        //    {
        //        listView = value;

        //    }
        //}

        //public DashBoardViewModel(INavigation navigation)
        //{
        //    Navigation = navigation;

        //    ListView = new ObservableCollection<DashBoardModel>{
        //        new DashBoardModel { Location = "@Warri,Delta", Status="Pending", To="Tolani Emmanuel" },
        //        new DashBoardModel { Location = "@Warri,Delta", Status="Pending", To="Tolani Emmanuel"  },
        //        new DashBoardModel { Location = "@Warri,Delta", Status="Pending", To="Tolani Emmanuel"  },
        //        new DashBoardModel { Location = "@Warri,Delta", Status="Pending", To="Tolani Emmanuel"  },
        //        new DashBoardModel { Location = "@Warri,Delta", Status="Pending", To="Tolani Emmanuel"  },

        //    };
        //}

        //private List<DashBoardData> SelectedItems = new List<DashBoardData>();


        private int transaction;

        public int Transaction
        {
            get => transaction;
            set
            {
                transaction = value;
                OnPropertyChanged(nameof(Transaction));
            }
        }
        
        private int items;

        public int Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private List<DashBoardResponse> listView;
        public List<DashBoardResponse> ListView
        {
            get => listView;
            set
            {
                listView = value;
                OnPropertyChanged(nameof(ListView));
            }
        }

        private ObservableCollection<ItemData> getItems;
        public ObservableCollection<ItemData> GetItems
        {
            get => getItems;
            set
            {
                getItems = value;
                OnPropertyChanged(nameof(GetItems));
            }
        }

        private ObservableCollection<Response> transact;
        public ObservableCollection<Response> Transact
        {
            get => transact;
            set
            {
                transact = value;
                OnPropertyChanged(nameof(Transact));
            }
        }

        public DashBoardViewModel(INavigation navigation)
        {
            Navigation = navigation;

            //TappedCommand = new Command<DashBoardData>(async (model) => await TappedCommandExecute(model));

            //if (Constant.GetItems != null)
            //{
            //    ObservableCollection<ItemData> itemCount = Constant.GetItems;
            //    //Console.WriteLine(itemCount.Count);
            //    Transaction = itemCount.Count;

            //}

            //Console.WriteLine(Transaction);

            Task _task = GetDashBoardExecute();
            Task _tasks = GetItemExecute();
            Task _taskss = GetTransactExecute();


            DashBoardCommand = new Command(async () => await GetDashBoardExecute());
            ItemCommand = new Command(async () => await GetItemExecute());
            TransactCommand = new Command(async () => await GetTransactExecute());
        }

        //private async Task TappedCommandExecute(DashBoardData model)
        //{
        //    try
        //    {
        //        var mod = model;
        //        model.isSelected = model.isSelected ? false : true;
        //        SelectedItems.Add(model);

        //        Console.WriteLine(mod);

        //        await Navigation.PushAsync(new TransactionDetailsPage(SelectedItems), true);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}


        public Command DashBoardCommand { get; }
        public Command ItemCommand { get; }
        //public Command<DashBoardData> TappedCommand { get; }

        public Command TransactCommand { get; }


        public async Task GetTransactExecute()
        {
            //try
            //{
                HttpClient client = new HttpClient();

                string url = Constant.TransactionUrl;

                Console.WriteLine(url);

                HttpResponseMessage response = await client.GetAsync(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                var test = Constant.accessToken;
                Console.WriteLine(test);

                //var rest = url + Helps.Constant.user_id;
                //Console.WriteLine(rest);
                response = await client.GetAsync(url);
                //response = await client.GetAsync(url + Helps.Constant.user_id);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<TransactionModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    Console.WriteLine(data.data);
                    var transacts = data.data.response;
                    Transact = new ObservableCollection<Response>(transacts);
                    //Transact = data.data.response;
                    Constant.Transact = data.data.response;
                  //  Constant.Transaction = data.data.responses;
                    Console.WriteLine(Transact);

                    if (Constant.Transact != null)
                    {
                         ObservableCollection<Response> TransactCount = Constant.Transact;
                        //Console.WriteLine(itemCount.Count);
                        Items = TransactCount.Count;

                    }
                    Console.WriteLine(Transact);
                    Console.WriteLine("vdhvg hdsh");
                }
                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }


        private async Task GetItemExecute()
        {
            //try
            //{

                HttpClient client = new HttpClient();

                string url = Constant.GetItemsUrl;

                HttpResponseMessage response = await client.GetAsync(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Constant.accessToken}");

                response = await client.GetAsync(url);

                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<ItemResponseModel>(result);
                    Console.WriteLine(data);
                    Console.WriteLine("passedjiojiojiojio");
                    GetItems = new ObservableCollection<ItemData>(data.data);
                    Constant.GetItems = new ObservableCollection<ItemData>(data.data);
                    Console.WriteLine(GetItems);

                    if (Constant.GetItems != null)
                    {
                        ObservableCollection<ItemData> itemCount = Constant.GetItems;
                        //Console.WriteLine(itemCount.Count);
                        Transaction = itemCount.Count;

                    }
                }
                else
                {
                    Console.WriteLine("Someting went wrong");
                }
           // }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    

        public async Task GetDashBoardExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Constant.TransactionUrl;

                var test = Constant.accessToken;
                Console.WriteLine(test);

                HttpResponseMessage response; 

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                response = await client.GetAsync(url);
                //response = await client.GetAsync(url + Helps.Constant.user_id);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<DashBoardModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    ListView = data.data.response;

                    var transacts = data.data.response;
                    //Transact = new ObservableCollection<Response>(transacts);
                    //Transact = data.data.response;
                    Console.WriteLine(ListView);
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
