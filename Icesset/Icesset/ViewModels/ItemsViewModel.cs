using Icesset.Helps;
using Icesset.Models;
using Icesset.Views;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private string selectedItemCount = "0";
        public string SelectedItemCount
        {
            get => selectedItemCount;
            set
            {
                selectedItemCount = value;
                OnPropertyChanged(nameof(SelectedItemCount));
            }
        }
        private bool showCounter = false;
        public bool ShowCounter
        {
            get => showCounter;
            set
            {
                showCounter = value;
                OnPropertyChanged(nameof(ShowCounter));
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
        
        private bool changeVisible = true;
        public bool ChangeVisible
        {
            get => changeVisible;
            set
            {
                changeVisible = value;
                OnPropertyChanged(nameof(ChangeVisible));
            }
        }

        private bool changeChecked = true;
        public bool ChangeChecked
        {
            get => changeChecked;
            set
            {
                changeChecked = value;
                OnPropertyChanged(nameof(ChangeChecked));
            }
        }

        private bool proceedVisible = true;
        public bool ProceedVisible
        {
            get => proceedVisible;
            set
            {
                proceedVisible = value;
                OnPropertyChanged(nameof(ProceedVisible));
            }
        }
        
        private bool frameChecked = true;
        public bool FrameChecked
        {
            get => frameChecked;
            set
            {
                frameChecked = value;
                OnPropertyChanged(nameof(FrameChecked));
            }
        }
        
        private bool imageChecked = false;
        public bool ImageChecked
        {
            get => imageChecked;
            set
            {
                imageChecked = value;
                OnPropertyChanged(nameof(ImageChecked));
            }
        }
        //private bool isRefreshing;
        //public bool IsRefreshing
        //{
        //    get => isRefreshing;
        //    set
        //    {
        //        isRefreshing = value;
        //        OnPropertyChanged(nameof(IsRefreshing));
        //    }
        //}

        // private ObservableCollection<ItemsModel> testing;

        //public ObservableCollection<ItemsModel> Testing
        //{
        //    get => testing;
        //    set
        //    {
        //        testing = value;
        //        OnPropertyChanged(nameof(Testing));
        //    }
        //}
        private ObservableCollection<ItemData>  SelectedItems = new ObservableCollection<ItemData>();
        private List<ItemData> AllItems = new List<ItemData>();

        private ObservableCollection<ItemData>  getItems;
        public ObservableCollection<ItemData>  GetItems
        {
            get => getItems;
            set
            {
                getItems = value;
                OnPropertyChanged(nameof(GetItems));
            }
        }
        public Command SearchEntryTextChangedCommand => new Command<string>((_entryTxt) => SearchBar_TextChanged(_entryTxt));
        private void SearchBar_TextChanged(string _searchEntry)
        {
            if (_searchEntry.Length >= 1 && GetItems.Count() >= 1)
            {
                var _newList = GetItems.Where(x => x.item_name.Contains(_searchEntry, StringComparison.OrdinalIgnoreCase));
                GetItems = new ObservableCollection<ItemData>(_newList);
            }
            else if (AllItems != null)
            {
                GetItems = null;
                GetItems = new ObservableCollection<ItemData>(AllItems);
            }
            else
            {
                return;
            }
        }
        public ItemsViewModel(INavigation navigation)
        {
            Navigation = navigation;

            TouchCommand = new Command(() => ChangeProperty());

            Task _task = GetItemExecute();
            ItemCheckedCommand = new Command<ItemData>(async (model)=> await ItemCheckedCommandExecute(model));
            ItemChangeCommand = new Command<ItemData>(async (model)=> await ItemChangeCommandExecute(model));

            ItemCommand = new Command(async () => await GetItemExecute());
            ProceedCommand = new Command(async () => await ProceedCommandExecute());
            //RefreshCommand = new Command(async () => await RefreshCommandExecute());


            //helpers.myitems = new ObservableCollection<ItemsModel> {
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //    new ItemsModel { Name = "Solar Battery", Category="Electronics", Location="Abuja", Number=4 },
            //};
        }
        public ICommand TouchCommand { get; }
        public ICommand ProceedCommand { get; }
        private async Task ProceedCommandExecute()
        {
            try
            {
                
                await Navigation.PushAsync(new EnterQuantityPage(SelectedItems), true);

                //SelectedItemCount = "0";
                //SelectedItems.Clear();
                ShowCounter = true;
                ChangeVisible = false;
                //ProceedVisible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ChangeProperty()
        {
            //ChangeVisible = false;
            //ChangeChecked = true;
            //ProceedVisible = true;
            //ShowCounter = true;

            Console.WriteLine(ChangeVisible);
            Console.WriteLine(ChangeChecked);
            Console.WriteLine(ProceedVisible);
        }
        #region commands
        private async Task ItemCheckedCommandExecute(ItemData model)
        {
            ChangeVisible = false;
            //ProceedVisible = true;
            ShowCounter = true;
            try
            {
                var mod = model;

                if (model.isSelected = false)
                {
                    model.FrameChecked = true;
                    model.ImageChecked = false;
                }
                else if(model.isSelected = true)
                {
                    model.FrameChecked = false;
                    model.ImageChecked = true;
                    model.ButtonShow = false;
                    model.ButtonHide = true;
                    SelectedItems.Add(model);
                } 
                
                else
                {
                    SelectedItems.Remove(model);

                }


                //model.isSelected = model.isSelected ? false : true;
                //SelectedItems.Add(model);
                SelectedItemCount = SelectedItems.Count.ToString();
                //ChangeChecked = false;

                await Task.Delay(10);          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private async Task ItemChangeCommandExecute(ItemData model)
        {
            ChangeVisible = false;
            //ProceedVisible = true;
            ShowCounter = true;
            try
            {
                var mod = model;

                if (model.isSelected = false)
                {
                    model.FrameChecked = false;
                    model.ImageChecked = true;
                }
                else if(model.isSelected = true)
                {
                    model.FrameChecked = true;
                    model.ImageChecked = false;
                    model.ButtonShow = true;
                    model.ButtonHide = false;
                    SelectedItems.Remove(model);
                } 
                
                else
                {
                    SelectedItems.Remove(model);

                }


                //model.isSelected = model.isSelected ? false : true;
                //SelectedItems.Add(model);
                SelectedItemCount = SelectedItems.Count.ToString();
                //ChangeChecked = false;

                await Task.Delay(10);          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public Command ItemCommand { get; }
        public Command ItemCheckedCommand { get; }
        public Command ItemChangeCommand { get; }

        public Command GetItemCommand { get; }
        //public Command RefreshCommand { get; }

        //public async Task RefreshCommandExecute()
        //{
        //    await GetItemExecute();

        //    // Stop refreshing
        //    IsRefreshing = false;
        //}

        #endregion
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
                    var data = JsonConvert.DeserializeObject<ItemResponseModel>(result);
                    Console.WriteLine(data);
                    Console.WriteLine("passedjiojiojiojio");
                    AllItems = data.data;
                    GetItems = new ObservableCollection<ItemData>(data.data);
                    Constant.GetItems = new ObservableCollection<ItemData>(data.data);

                    foreach (var item in GetItems)
                    {
                        item.isSelected = false;
                        item.icon = "checkbox.png";
                    }
                    Console.WriteLine(GetItems);
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
