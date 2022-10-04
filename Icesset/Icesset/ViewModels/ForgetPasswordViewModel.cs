using Icesset.Helps;
using Icesset.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class ForgetPasswordViewModel : BaseViewModel
    {
        public ForgetPasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            PasswordCommand = new Command(async () => await PasswordCommandsExecute());
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

        private bool IsBusy = false;
        public bool IsBuy
        {
            get => IsBusy;
            set
            {
                IsBusy = value;
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
            }
        }
        
        private string redirectUrl;

        public string RedirectUrl
        {
            get => redirectUrl;
            set
            {
                redirectUrl = value;
                OnPropertyChanged(nameof(RedirectUrl));
            }
        }
        
        public Command PasswordCommand { get; }

        #endregion
        private async Task PasswordCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(Email))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct email";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                //if (string.IsNullOrWhiteSpace(RedirectUrl))
                //{
                //    IsMessageVisible = true;
                //    MessageLabel = "Please enter a correct redirectUrl";
                //    await Task.Delay(2000);
                //    IsMessageVisible = false;
                //    return;
                //}
                IsBtnEnabled = true;
                IsBusy = true;
                HttpClient client = new HttpClient();
                PasswordRequest request = new PasswordRequest( Email);

                string body = JsonConvert.SerializeObject(request);

                string url = Constant.PasswordUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ForgetPasswordModel data = JsonConvert.DeserializeObject<ForgetPasswordModel>(result);
                    MessageLabel = "Email sent Successfully.";

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    IsMessageVisible = true;
                    MessageLabel = "Email does not exist";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    MessageLabel = "Something went wrong. Please try again later.";
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
                //IsBtnEnabled = false;
                IsBusy = false;
            }
        }
    }
}
