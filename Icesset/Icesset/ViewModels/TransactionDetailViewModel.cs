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
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class TransactionDetailViewModel : BaseViewModel
    {
        //NewLotDetail LotBill;
        //BatchInfo BatchDetails;


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


        //private bool collectVisible = false;
        //public bool CollectVisible
        //{
        //    get => collectVisible;
        //    set
        //    {
        //        collectVisible = value;
        //        OnPropertyChanged(nameof(CollectVisible));
        //    }
        //}


        public ObservableCollection<Response> selectedItems;
        public ObservableCollection<Response> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }


        public TransactionDetailViewModel(INavigation navigation, ObservableCollection<Response> selectedItems)
        {

            Navigation = navigation;

            //RefreshCommand = new Command(async () => await RefreshCommandExecute());

            //GetShowPopupExecute();

            //ShowPopupCommand = new Command(async () => await GetShowPopupExecute());

            //TransactCommand = new Command(async () => await GetTransactExecute());

            IsBusy = true;
            SelectedItems = selectedItems;
            Constant.ItemSelected = null;
            Constant.ItemSelected = SelectedItems;
           
            //LotBill = newLotDetail;
            //BatchDetails = batchInfo;
            Transact = new ObservableCollection<Response>(SelectedItems);
            
            foreach (var item in Transact)
            {
                item.data = new ObservableCollection<TransactItemData>(item.data);
                //if ( item.created_by_id != item.user_id)
                //{
                //    item.CollectVisible = true;
                //}
                if (item.transaction_status == "pending")
                {
                    item.CollectVisible = true;
                }
                else
                {
                    item.CollectVisible = false;
                }
                
                //if (item.transaction_status == "pending" && item.created_by_id != item.user_id)
                //{
                //    item.CollectVisible = true;
                //}
                //else
                //{
                //    item.CollectVisible = false;
                //}
            }
            Console.WriteLine(Transact);

           
        }

        public Command RefreshCommand { get; }

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


        //public Command ShowPopupCommand { get; }

        //public async Task GetShowpopupExecute()
        //{
        //    await Navigation.PushAsync(new PopUpView(selectedItems));
        //}

        //public Command TransactCommand { get; }
        //public async Task GetTransactExecute()
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();

        //        string url = Constant.TransactionDetailUrl;

        //        Console.WriteLine(url);

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

        //        var test = Constant.accessToken;
        //        Console.WriteLine(test);

        //        //var rest = url + Helps.Constant.user_id;
        //        //Console.WriteLine(rest);
        //        response = await client.GetAsync(url);
        //        //response = await client.GetAsync(url + Helps.Constant.user_id);


        //        Console.WriteLine(response);

        //        string result = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(result);
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var data = JsonConvert.DeserializeObject<TransactionModel>(result);
        //            Console.WriteLine("passedjiojiojiojio");
        //            Console.WriteLine(data.data);
        //            var transacts = data.data.response;
        //            foreach (var item in transacts)
        //            {
        //                item.data = new ObservableCollection<TransactItemData>(item.data);
        //                //item.newTransact = new ObservableCollection<TransactItemData>(item.data);
        //            }
        //            Console.WriteLine(transacts);
        //            Transact = new ObservableCollection<Response>(transacts);
        //            Helps.Constant.Transact = new ObservableCollection<Response>(transacts);
        //            Console.WriteLine(Transact);
        //            Console.WriteLine("vdhvg hdsh");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Someting went wrong");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}

    }
}
