using Icesset.Utiliy;
using System;
using Icesset.Models;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Icesset.Helps;
using Icesset.Views;
using Newtonsoft.Json;
using System.Net.Http;

namespace Icesset.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel(INavigation navigation)
        {
            Navigation = navigation;

            PasswordResetCommand = new Command(async () => await ProfileViewModelExecute());
        }

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

        private string currentPassword;

        public string CurrentPassword
        {
            get => currentPassword;
            set
            {
                currentPassword = value;
                OnPropertyChanged(nameof(CurrentPassword));
            }
        }
        private string newPassword;

        public string NewPassword
        {
            get => newPassword;
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string userId = Constant.user_id;

        public string UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public Command PasswordResetCommand { get; }

        private async Task ProfileViewModelExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(CurrentPassword))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "You need to fill your current password";
                    await Task.Delay(2000);
                    Console.WriteLine("hgjdshfg");
                    IsMessageVisible = false;
                    return;
                }


                if (string.IsNullOrWhiteSpace(NewPassword))
                {
                    IsMessageVisible = true;
                    MessageLabel = "Provide your new password";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                IsBtnEnabled = true;
                IsBusy = true;
                HttpClient client = new HttpClient();
                ProfileRequestModel request = new ProfileRequestModel(CurrentPassword, NewPassword, UserId);

                string body = JsonConvert.SerializeObject(request);

                string url = Constant.ChangePasswordUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helps.Constant.accessToken}");

                HttpResponseMessage response;
                response = await client.PutAsync(url, content);

                var test = Constant.accessToken;
                Console.WriteLine(test);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    successModel data = JsonConvert.DeserializeObject<successModel>(result);
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                    await Navigation.PushAsync(new LoginPage());
                    //MessageLabel = "Password change Successfully.";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    successModel data = JsonConvert.DeserializeObject<successModel>(result);
                    MessageLabel = data.message;
                    IsMessageVisible = true;
                    //MessageLabel = "Please input correct password";
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                }
                else
                {
                    successModel data = JsonConvert.DeserializeObject<successModel>(result);
                    MessageLabel = data.message;
                    //MessageLabel = "Something went wrong. Please try again later.";
                    IsMessageVisible = false;
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($" An error with {ex.Message} occured here");
            }
            finally
            {
                IsMessageVisible = false;
                IsBtnEnabled = false;
                IsBusy = false;
            }
        }
    }
}
