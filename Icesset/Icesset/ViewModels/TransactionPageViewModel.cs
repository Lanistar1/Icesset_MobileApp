using Icesset.Helps;
using Icesset.Models;
using Icesset.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class TransactionPageViewModel : BaseViewModel
    {
        //private ObservableCollection<TransactionModel> transact;
        //private INavigation Navigation;

        //public ObservableCollection<TransactionModel> Transact
        //{
        //    get => transact;
        //    set
        //    {
        //        transact = value;

        //    }
        //}

        //public TransactionPageViewModel(INavigation navigation)
        //{
        //    Navigation = navigation;

        //    Transact = new ObservableCollection<TransactionModel>{
        //        new TransactionModel { Sent=20-08-2022, Status="Pending", Name="Emmanuel Ola", Location="@ warri, Delta state", Quantity=4, Item_Name="Solar battery", Store="JoyceB, Ibadan store", Courier_Contact=07060012402, Courier_Name="Pelumi" },
        //        new TransactionModel { Sent=20-08-2022, Status="Pending", Name="Emmanuel Ola", Location="@ warri, Delta state", Quantity=4, Item_Name="Solar battery", Store="JoyceB, Ibadan store", Courier_Contact=07060012402, Courier_Name="Pelumi" },
        //        new TransactionModel { Sent=20-08-2022, Status="Pending", Name="Emmanuel Ola", Location="@ warri, Delta state", Quantity=4, Item_Name="Solar battery", Store="JoyceB, Ibadan store", Courier_Contact=07060012402, Courier_Name="Pelumi" },

        //     };
        //}


        private ObservableCollection<Response> SelectedItems = new ObservableCollection<Response>();



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



        private bool collectVisible = false;
        public bool CollectVisible
        {
            get => collectVisible;
            set
            {
                collectVisible = value;
                OnPropertyChanged(nameof(CollectVisible));
            }
        }


        public TransactionPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = GetTransactExecute();

            //TransactCommand = new Command(async () => await GetTransactExecute());
            TappedCommand = new Command<Response>(async (model) => await GetTappedExecute(model));
            //TransferCommand = new Command(async () => await GetTransferExecute());
        }


        public Command TappedCommand { get; }

        private async Task GetTappedExecute(Response model)
        {
            try
            {
                var mod = model;
                
                model.isSelected = model.isSelected ? false : true;
                SelectedItems.Add(model);

                if (model.receivedBy == model.user_id && model.transaction_status == "Pending" && model.created_by_id != model.user_id )
                {
                    CollectVisible = true;
                }
                else
                {
                    CollectVisible = false;
                }
                
                //if (model.receivedBy == model.user_id && model.transaction_status == "Pending" && model.created_by_id != model.user_id )
                //{
                //    CollectVisible = true;
                //}
                //else
                //{
                //    CollectVisible = false;
                //}

                await Navigation.PushAsync(new TransactionDetailsPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        //public Command TransactCommand { get; }
        public async Task GetTransactExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Constant.TransactionUrl;

                Console.WriteLine(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                HttpResponseMessage response = await client.GetAsync(url);

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
                    foreach (var item in transacts)
                    {
                        item.data = new ObservableCollection<TransactItemData>(item.data);
                        Constant.TransactItemData = item.data;
                        //item.newTransact = new ObservableCollection<TransactItemData>(item.data);
                    }
                    Console.WriteLine(transacts);
                    Transact = new ObservableCollection<Response> (transacts);
                    Helps.Constant.Transact = Transact;
                    //Helps.Constant.Transact = new ObservableCollection<Response>(transacts);
                    Console.WriteLine(Transact);
                    Console.WriteLine("vdhvg hdsh");
                }

                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
