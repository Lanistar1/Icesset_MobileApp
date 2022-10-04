using Icesset.Helps;
using Icesset.Models;
using Icesset.Utiliy;
using Icesset.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private Color emailBackgroundColor;
        public Color EmailBackgroundColor
        {
            get 
            {
                return emailBackgroundColor; 
            }
            set 
            {
                emailBackgroundColor = value;
                OnPropertyChanged(nameof(EmailBackgroundColor));
            }

        }


    public LoginPageViewModel(INavigation navigation)
        {
            Navigation = navigation;



            LoginCommand = new Command(async () => await LoginCommandsExecute());
        }

        #region Binding Properties
        private bool isBtnEnabled = false;

        public bool IsBtnEnabled
        {
            get => isBtnEnabled;
            set
            {
                isBtnEnabled = value;
                OnPropertyChanged(nameof(IsBtnEnabled));
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
        
        private string messageLabelColor;

        public string MessageLabelColor
        {
            get => messageLabelColor;
            set
            {
                messageLabelColor = value;
                OnPropertyChanged(nameof(MessageLabelColor));
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

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
                EmailBackgroundColor = RegexUtils.ValidEmailAddress().IsMatch(value) ? Color.Red : Color.White;
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        #endregion

        #region Binding Commands

        public Command LoginCommand { get; }

        #endregion

        #region Functions, Methods, Events and others
        private async Task LoginCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(Email))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabelColor = "Please enter a correct email";
                    await Task.Delay(5000);
                    Console.WriteLine("hgjdshfg");
                    IsMessageVisible = false;
                    return;
                }
                
                
                if (string.IsNullOrWhiteSpace(Password))
                {
                    IsMessageVisible = true;
                    MessageLabelColor = "Please enter a correct password";
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                    return;
                }
                IsBtnEnabled = true;
                IsBusy = true;
                IsMessageVisible = true;
                HttpClient client = new HttpClient();
                LoginRequestModel request = new LoginRequestModel(Password, Email);
                Console.WriteLine(request.password);
                Console.WriteLine(request.email);

                string body = JsonConvert.SerializeObject(request);
                Console.WriteLine(Email);
                Console.WriteLine(Password);
                
                string url = Constant.LoginUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                    Console.WriteLine(data.data.accessToken);
                    Helps.Constant.accessToken = data.data.accessToken;
                    Helps.Constant.user_id = data.data.info.user_id;
                    Helps.Constant.CurrentUserData = data.data;
                    //MessageLabel = data.message.profile.fullname;
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    Console.WriteLine(MessageLabel);
                    await Navigation.PushAsync(new MyFlyoutPage());

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                    IsMessageVisible = true;
                    //MessageLabel = data.message;
                    MessageLabelColor = data.message;
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                }
                else
                {
                    LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    response.Dispose();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($" An error with {ex.Message} occured here");
                MessageLabelColor = "Check your internet connection";

            }
            finally
            {
                IsMessageVisible = false;
                IsBtnEnabled = false;
                IsBusy = false;
            }
        }
        #endregion

    }
}
