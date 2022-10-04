using Icesset.Helps;
using Icesset.Models;
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
    public class ItemsDetailViewModel : BaseViewModel
    {
        //private ObservableCollection<ItemsDetailModel> details;

        //private INavigation Navigation;

        //public ObservableCollection<ItemsDetailModel> Details
        //{
        //    get => details;
        //    set
        //    {
        //        details = value;
        //    }
        //}
        //public ItemsDetailViewModel(INavigation navigation)
        //{
        //    Navigation = navigation;

        //    Details = new ObservableCollection<ItemsDetailModel>{
        //        new ItemsDetailModel { Item_Name="Solar Battery", Category="Electronics", Location="Warri, Delta State", Description="15kvA 20hrs capacity 15kvA 20hrs capacity 15kvA 20hrs capacity" },            

        //    };


        //}

        private List<ItemsDetail> details;
        public List<ItemsDetail> Details
        {
            get => details;
            set
            {
                details = value;
                OnPropertyChanged(nameof(Details));
            }
        }
        public ItemsDetailViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = GetItemExecute();

            ItemCommand = new Command(async () => await GetItemExecute());
        }
        public Command ItemCommand { get; }
        public Command GetItemCommand { get; }
        public async Task GetItemExecute()
        {
            try
            {

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
                    var data = JsonConvert.DeserializeObject<ItemDetailModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    Details = data.data;
                    Console.WriteLine(Details);
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
