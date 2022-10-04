using Icesset.Helps;
using Icesset.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class ScannerPage : ContentPage
    {
        ZXingScannerPage scanPage;
        Button buttonScanDefaultOverlay;

        //Task _task = GetTransactExecute();

        //TransactCommand = new Command(async () => await GetTransactExecute());


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

        public ObservableCollection<Response> selectedItems;
        public ObservableCollection<Response> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        public ScannerPage() : base()
        {
            buttonScanDefaultOverlay = new Button
            {
                Text = "Scan Barcode",
                AutomationId = "scanWithDefaultOverlay",
            };
            buttonScanDefaultOverlay.Clicked += async delegate
            {
                scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;

                    ZXing.BarcodeFormat barcodeFormat = result.BarcodeFormat;
                    string type = barcodeFormat.ToString();
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                        DisplayAlert("The Barcode type is : " + type, "The text is : " + result.Text, "OK");
                        //SearchURI.Navigate(new Uri("https://www.google.com/?gfe_rd=cr&ei=ccRwWIS7D8ao8weY9b_ADA#q=" + result.Text));
                        //Navigation.PushAsync(new TestPage(result.Text));
                        string[] test_result = result.Text.Split('/');
                        Console.WriteLine(test_result);
                        Console.WriteLine(test_result[test_result.Length - 1]);

                        var waybillresult = test_result[test_result.Length - 1];
                        Constant.waybillResult = test_result[test_result.Length - 1];
                        GetTransactExecute();

                        //PublicKey command TransactCommand { get; }



                        
                    });
                };


                await Navigation.PushAsync(scanPage);
            };


            var stack = new StackLayout();
            stack.Children.Add(buttonScanDefaultOverlay);

            Content = stack;
        }

        public async Task GetTransactExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Constant.TransactionDetailUrl;

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
                    var data = JsonConvert.DeserializeObject<ScannedTransactionModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    Console.WriteLine(data.data);
                    var Scannedtransacts = data.data;
                    //foreach (var item in transacts)
                    //{
                    //    item.data = new ObservableCollection<ScannedData>(item.);
                    //    //item.newTransact = new ObservableCollection<TransactItemData>(item.data);
                    //}
                    Console.WriteLine(Scannedtransacts);
                    //Transact = transacts;
                    //Console.WriteLine(Transact);
                    await Navigation.PushAsync(new ScannedWaybillPage(Scannedtransacts), true);
                    Console.WriteLine("vdhvg hdsh");

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













    //public partial class ScannerPage : ContentPage
    //{
    //    public ScannerPage()
    //    {
    //        InitializeComponent();
    //    }


    //private async void zxingscannerview_scannerview(ZXing.Result result)
    //{
    //    Device.BeginInvokeOnMainThread(() =>
    //    {
    //        onScanResult.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";

    //    });
    //}
    //}
