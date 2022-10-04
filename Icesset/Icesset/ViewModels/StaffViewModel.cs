using Icesset.Helps;
using Icesset.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels 
{
    public class StaffViewModel : BaseViewModel
    {
        private List<Result> staff;
        public List<Result> Staff
        {
            get => staff;
            set
            {
                staff = value;
                OnPropertyChanged(nameof(Staff));
            }
        }

        internal static IEnumerable Where(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        private string searchEntry;
        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;
                SearchEntryTextChangedCommand.Execute(searchEntry);
                OnPropertyChanged(nameof(SearchEntry));
            }
        }
        private List<Result> AllItems = new List<Result>();

        public Command SearchEntryTextChangedCommand => new Command<string>((_entryTxt) => SearchBar_TextChanged(_entryTxt));
        private void SearchBar_TextChanged(string _searchEntry)
        {
            if (_searchEntry.Length >= 1 && Staff.Count() >= 1)
            {
                var _newList = Staff.Where(x => x.firstName.Contains(_searchEntry, StringComparison.OrdinalIgnoreCase));
                Staff = new List<Result>(_newList);
            }
            else if (AllItems != null)
            {
                Staff = null;
                Staff = new List<Result>(AllItems);
            }
            else
            {
                return;
            }
        }
        public StaffViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = GetStaffExecute();

            StaffCommand = new Command(async () => await GetStaffExecute());
        }
        public Command StaffCommand { get; }
        public async Task GetStaffExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

            string url = Constant.StaffUrl;

                HttpResponseMessage response = await client.GetAsync(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                response = await client.GetAsync(url);
                //response = await client.GetAsync(url + Helps.Constant.user_id);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<StaffModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    AllItems = data.data.result;
                    Staff = new List<Result>(data.data.result);
                    Console.WriteLine(Staff);
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
