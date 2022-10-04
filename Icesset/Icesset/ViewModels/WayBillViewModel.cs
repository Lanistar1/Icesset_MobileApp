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
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class WayBillViewModel : BaseViewModel
    {
        private List<Result> userList;
        public List<Result> UserList
        {
            get => userList;
            set
            {
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }
        
        private Results home;
        public Results Home
        {
            get => home;
            set
            {
                home = value;
                OnPropertyChanged(nameof(Home));
            }
        }


        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        } 
        
        private List<Result> fullName;
        public List<Result> FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        
        private List<string> sentTo_Id;
        public List<string> SentTo_Id
        {
            get => sentTo_Id;
            set
            {
                sentTo_Id = value;
                OnPropertyChanged(nameof(SentTo_Id));
            }
        }

        public WayBillViewModel(INavigation navigation)
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
                    StaffModel data = JsonConvert.DeserializeObject<StaffModel>(result);
                    Console.WriteLine("passedjiojiojiojio");

                    //FirstName = data.firstName;
                    //LastName = data.lastName;
                    //FullName = $"{FirstName + LastName}";
                    //UserList = data;
                    Console.WriteLine(UserList);
                    UserList = new List<Result>(data.data.result);
                    FullName = UserList;

                    

                    //List<string> names = new List<string>();
                    //List<string> lists = new List<string>();
                    //List<Result> selectedId = new List<Result>();
                    //foreach (var item in UserList)
                    //{
                    //    Console.WriteLine(item);
                    //    var sentTo = item.user_id;
                    //    var userName = $"{item.firstName} {item.lastName}";
                    //    names.Add(userName.ToString());
                    //    lists.Add(sentTo);
                    //    lists.Add(strId);
                    //}


                    //FullName = UserList;
                    //SentTo_Id = new List<string>(lists);
                    //Constant.UserList = SentTo_Id;
                   
                    //for (int i = 0; i < UserList.Count; i++)
                    //{
                    //    Console.WriteLine(UserList[i]);         
                    //}

                    //Console.WriteLine(UserList);
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
