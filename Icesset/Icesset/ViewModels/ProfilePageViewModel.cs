using Icesset.Helps;
using Icesset.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        private ProfileData  apple;
        public ProfileData  Apple
        {
            get => apple;
            set
            {
                apple = value;
                OnPropertyChanged(nameof(Apple));
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
        
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        
        private string mobilePhone;
        public string MobilePhone
        {
            get => mobilePhone;
            set
            {
                mobilePhone = value;
                OnPropertyChanged(nameof(MobilePhone));
            }
        }
        
        private string role;
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        
        private string userStatus;
        public string UserStatus
        {
            get => userStatus;
            set
            {
                userStatus = value;
                OnPropertyChanged(nameof(UserStatus));
            }
        }

        public ProfilePageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = ProfilePageExecute();

            ProfilePageCommand = new Command(async () => await ProfilePageExecute());
        }
        public Command ProfilePageCommand { get; }

        public async Task ProfilePageExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Constant.ProfileUrl;

                Console.WriteLine(url);

                HttpResponseMessage response;

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                var test = Constant.accessToken;
                Console.WriteLine(test);

                response = await client.GetAsync(url);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<ProfileData>(result);
                    Console.WriteLine(data);
                    FirstName = data.firstName;
                    LastName = data.lastName;
                    Email = data.email;
                    MobilePhone = data.mobilePhone;
                    UserStatus = data.userStatus;
                    Role = data.role;
                    Apple = data;
                    //Apple =  data.data;
                    Console.WriteLine("ffdjhhdh");
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
